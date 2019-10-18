<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEmpOvertime
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpOvertime))
        Me.GCOvertime = New DevExpress.XtraGrid.GridControl()
        Me.GVOvertime = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BandedGridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BandedGridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BandedGridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RIMEMultiline = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn40 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.SBViewOD = New DevExpress.XtraEditors.SimpleButton()
        Me.SBViewCA = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.SLUEPayroll = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SLUEPayrollView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn51 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SLUEDepartement = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.XTCType = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPropose = New DevExpress.XtraTab.XtraTabPage()
        Me.XTCPropose = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPByRequest = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControlVerification = New DevExpress.XtraEditors.PanelControl()
        Me.SBVerification = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPByEmployee = New DevExpress.XtraTab.XtraTabPage()
        Me.GCProposeEmployee = New DevExpress.XtraGrid.GridControl()
        Me.GVProposeEmployee = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCIdEmployee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdDepartementSub = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeePosition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdEmployeeStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCToSalary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCConversionType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RISLUEType = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdOvertime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdOvertimeType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOvertimeType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIsDayOff = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCStartWork = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEndWork = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCBreakHours = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCTotalHours = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOvertimePropse = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCCreatedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCCreatedAt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPVerification = New DevExpress.XtraTab.XtraTabPage()
        Me.XTCVerification = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPByRequestVerification = New DevExpress.XtraTab.XtraTabPage()
        Me.GCVerification = New DevExpress.XtraGrid.GridControl()
        Me.GVVerification = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn47 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn38 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn43 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn44 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn45 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn46 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPByEmployeeVerification = New DevExpress.XtraTab.XtraTabPage()
        Me.GCVerificationEmployee = New DevExpress.XtraGrid.GridControl()
        Me.GVVerificationEmployee = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn36 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn37 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn39 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn48 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn49 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn50 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RISLUETypeVerification = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn54 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn55 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn56 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn57 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn58 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn59 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn60 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn61 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn62 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn63 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn64 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn65 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn66 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn67 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn68 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraScrollableControl1 = New DevExpress.XtraEditors.XtraScrollableControl()
        Me.PCEmployee = New DevExpress.XtraEditors.PanelControl()
        Me.SLUEEmployee = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit2View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PopupMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.BBIDuplicate = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        CType(Me.GCOvertime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOvertime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIMEMultiline, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.SLUEPayroll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUEPayrollView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUEDepartement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.XTCType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCType.SuspendLayout()
        Me.XTPPropose.SuspendLayout()
        CType(Me.XTCPropose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPropose.SuspendLayout()
        Me.XTPByRequest.SuspendLayout()
        CType(Me.PanelControlVerification, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlVerification.SuspendLayout()
        Me.XTPByEmployee.SuspendLayout()
        CType(Me.GCProposeEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProposeEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RISLUEType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPVerification.SuspendLayout()
        CType(Me.XTCVerification, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCVerification.SuspendLayout()
        Me.XTPByRequestVerification.SuspendLayout()
        CType(Me.GCVerification, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVVerification, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPByEmployeeVerification.SuspendLayout()
        CType(Me.GCVerificationEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVVerificationEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RISLUETypeVerification, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.PCEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCEmployee.SuspendLayout()
        CType(Me.SLUEEmployee.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit2View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCOvertime
        '
        Me.GCOvertime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOvertime.Location = New System.Drawing.Point(0, 52)
        Me.GCOvertime.MainView = Me.GVOvertime
        Me.GCOvertime.Name = "GCOvertime"
        Me.GCOvertime.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RIMEMultiline})
        Me.GCOvertime.Size = New System.Drawing.Size(992, 560)
        Me.GCOvertime.TabIndex = 0
        Me.GCOvertime.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOvertime})
        '
        'GVOvertime
        '
        Me.GVOvertime.ColumnPanelRowHeight = 32
        Me.GVOvertime.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.BandedGridColumn12, Me.BandedGridColumn11, Me.BandedGridColumn10, Me.GridColumn9, Me.GridColumn40, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12})
        Me.GVOvertime.GridControl = Me.GCOvertime
        Me.GVOvertime.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_hours", Nothing, "{0:N1}")})
        Me.GVOvertime.Name = "GVOvertime"
        Me.GVOvertime.OptionsBehavior.Editable = False
        Me.GVOvertime.OptionsFind.AlwaysVisible = True
        Me.GVOvertime.OptionsView.ColumnAutoWidth = False
        Me.GVOvertime.OptionsView.RowAutoHeight = True
        Me.GVOvertime.OptionsView.ShowFooter = True
        Me.GVOvertime.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "id_ot"
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
        Me.GridColumn3.Caption = "Overtime Type"
        Me.GridColumn3.FieldName = "ot_type"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 81
        '
        'BandedGridColumn12
        '
        Me.BandedGridColumn12.Caption = "BandedGridColumn12"
        Me.BandedGridColumn12.FieldName = "id_departement"
        Me.BandedGridColumn12.Name = "BandedGridColumn12"
        '
        'BandedGridColumn11
        '
        Me.BandedGridColumn11.Caption = "Departement"
        Me.BandedGridColumn11.FieldName = "departement"
        Me.BandedGridColumn11.Name = "BandedGridColumn11"
        Me.BandedGridColumn11.Visible = True
        Me.BandedGridColumn11.VisibleIndex = 2
        '
        'BandedGridColumn10
        '
        Me.BandedGridColumn10.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn10.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumn10.Caption = "Date"
        Me.BandedGridColumn10.ColumnEdit = Me.RIMEMultiline
        Me.BandedGridColumn10.FieldName = "ot_date"
        Me.BandedGridColumn10.Name = "BandedGridColumn10"
        Me.BandedGridColumn10.Visible = True
        Me.BandedGridColumn10.VisibleIndex = 3
        Me.BandedGridColumn10.Width = 33
        '
        'RIMEMultiline
        '
        Me.RIMEMultiline.Name = "RIMEMultiline"
        '
        'GridColumn9
        '
        Me.GridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn9.Caption = "Overtime Propose"
        Me.GridColumn9.ColumnEdit = Me.RIMEMultiline
        Me.GridColumn9.FieldName = "ot_note"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 4
        Me.GridColumn9.Width = 96
        '
        'GridColumn40
        '
        Me.GridColumn40.Caption = "GridColumn40"
        Me.GridColumn40.FieldName = "id_report_status"
        Me.GridColumn40.Name = "GridColumn40"
        Me.GridColumn40.Width = 76
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Report Status"
        Me.GridColumn10.FieldName = "report_status"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 5
        Me.GridColumn10.Width = 77
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Created By"
        Me.GridColumn11.FieldName = "created_by"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 6
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Created At"
        Me.GridColumn12.FieldName = "created_at"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 7
        '
        'PanelControl4
        '
        Me.PanelControl4.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl4.Appearance.Options.UseBackColor = True
        Me.PanelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl4.Controls.Add(Me.SBViewOD)
        Me.PanelControl4.Controls.Add(Me.SBViewCA)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl4.Location = New System.Drawing.Point(1257, 0)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(265, 40)
        Me.PanelControl4.TabIndex = 19
        '
        'SBViewOD
        '
        Me.SBViewOD.Location = New System.Drawing.Point(10, 9)
        Me.SBViewOD.Name = "SBViewOD"
        Me.SBViewOD.Size = New System.Drawing.Size(120, 23)
        Me.SBViewOD.TabIndex = 17
        Me.SBViewOD.Text = "View (Overtime Date)"
        '
        'SBViewCA
        '
        Me.SBViewCA.Location = New System.Drawing.Point(136, 9)
        Me.SBViewCA.Name = "SBViewCA"
        Me.SBViewCA.Size = New System.Drawing.Size(120, 23)
        Me.SBViewCA.TabIndex = 16
        Me.SBViewCA.Text = "View (Created At)"
        '
        'PanelControl3
        '
        Me.PanelControl3.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl3.Appearance.Options.UseBackColor = True
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.LabelControl7)
        Me.PanelControl3.Controls.Add(Me.SLUEPayroll)
        Me.PanelControl3.Controls.Add(Me.Label4)
        Me.PanelControl3.Controls.Add(Me.Label1)
        Me.PanelControl3.Controls.Add(Me.SLUEDepartement)
        Me.PanelControl3.Controls.Add(Me.DEStart)
        Me.PanelControl3.Controls.Add(Me.Label2)
        Me.PanelControl3.Controls.Add(Me.DEUntil)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(987, 40)
        Me.PanelControl3.TabIndex = 18
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(12, 14)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(72, 13)
        Me.LabelControl7.TabIndex = 28
        Me.LabelControl7.Text = "Payroll Period :"
        '
        'SLUEPayroll
        '
        Me.SLUEPayroll.Location = New System.Drawing.Point(93, 11)
        Me.SLUEPayroll.Name = "SLUEPayroll"
        Me.SLUEPayroll.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEPayroll.Properties.View = Me.SLUEPayrollView
        Me.SLUEPayroll.Size = New System.Drawing.Size(200, 20)
        Me.SLUEPayroll.TabIndex = 27
        '
        'SLUEPayrollView
        '
        Me.SLUEPayrollView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn29, Me.GridColumn51, Me.GridColumn31, Me.GridColumn30})
        Me.SLUEPayrollView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SLUEPayrollView.Name = "SLUEPayrollView"
        Me.SLUEPayrollView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SLUEPayrollView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn29
        '
        Me.GridColumn29.FieldName = "id_payroll"
        Me.GridColumn29.Name = "GridColumn29"
        '
        'GridColumn51
        '
        Me.GridColumn51.Caption = "GridColumn51"
        Me.GridColumn51.FieldName = "periode_start"
        Me.GridColumn51.Name = "GridColumn51"
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "GridColumn31"
        Me.GridColumn31.FieldName = "periode_end"
        Me.GridColumn31.Name = "GridColumn31"
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "Payroll Period"
        Me.GridColumn30.FieldName = "periode"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(715, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Departement :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(303, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "From : "
        '
        'SLUEDepartement
        '
        Me.SLUEDepartement.Location = New System.Drawing.Point(798, 11)
        Me.SLUEDepartement.Name = "SLUEDepartement"
        Me.SLUEDepartement.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEDepartement.Properties.View = Me.SearchLookUpEdit1View
        Me.SLUEDepartement.Size = New System.Drawing.Size(180, 20)
        Me.SLUEDepartement.TabIndex = 16
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn13, Me.GridColumn14})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "GridColumn13"
        Me.GridColumn13.FieldName = "id_departement"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Departement"
        Me.GridColumn14.FieldName = "departement"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(347, 11)
        Me.DEStart.Margin = New System.Windows.Forms.Padding(0)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Size = New System.Drawing.Size(150, 20)
        Me.DEStart.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(505, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Until : "
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(549, 11)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Size = New System.Drawing.Size(150, 20)
        Me.DEUntil.TabIndex = 15
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.XTCType)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 57)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1008, 672)
        Me.PanelControl2.TabIndex = 2
        '
        'XTCType
        '
        Me.XTCType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCType.Location = New System.Drawing.Point(2, 2)
        Me.XTCType.Name = "XTCType"
        Me.XTCType.SelectedTabPage = Me.XTPPropose
        Me.XTCType.Size = New System.Drawing.Size(1004, 668)
        Me.XTCType.TabIndex = 2
        Me.XTCType.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPropose, Me.XTPVerification})
        '
        'XTPPropose
        '
        Me.XTPPropose.Controls.Add(Me.XTCPropose)
        Me.XTPPropose.Name = "XTPPropose"
        Me.XTPPropose.Size = New System.Drawing.Size(998, 640)
        Me.XTPPropose.Text = "Proposed"
        '
        'XTCPropose
        '
        Me.XTCPropose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCPropose.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCPropose.Location = New System.Drawing.Point(0, 0)
        Me.XTCPropose.Name = "XTCPropose"
        Me.XTCPropose.SelectedTabPage = Me.XTPByRequest
        Me.XTCPropose.Size = New System.Drawing.Size(998, 640)
        Me.XTCPropose.TabIndex = 1
        Me.XTCPropose.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPByRequest, Me.XTPByEmployee})
        '
        'XTPByRequest
        '
        Me.XTPByRequest.Controls.Add(Me.GCOvertime)
        Me.XTPByRequest.Controls.Add(Me.PanelControlVerification)
        Me.XTPByRequest.Name = "XTPByRequest"
        Me.XTPByRequest.Size = New System.Drawing.Size(992, 612)
        Me.XTPByRequest.Text = "By Request"
        '
        'PanelControlVerification
        '
        Me.PanelControlVerification.Controls.Add(Me.SBVerification)
        Me.PanelControlVerification.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlVerification.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlVerification.Name = "PanelControlVerification"
        Me.PanelControlVerification.Size = New System.Drawing.Size(992, 52)
        Me.PanelControlVerification.TabIndex = 1
        '
        'SBVerification
        '
        Me.SBVerification.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBVerification.Image = CType(resources.GetObject("SBVerification.Image"), System.Drawing.Image)
        Me.SBVerification.Location = New System.Drawing.Point(889, 2)
        Me.SBVerification.Name = "SBVerification"
        Me.SBVerification.Size = New System.Drawing.Size(101, 48)
        Me.SBVerification.TabIndex = 0
        Me.SBVerification.Text = "Verification"
        '
        'XTPByEmployee
        '
        Me.XTPByEmployee.Controls.Add(Me.GCProposeEmployee)
        Me.XTPByEmployee.Name = "XTPByEmployee"
        Me.XTPByEmployee.Size = New System.Drawing.Size(992, 612)
        Me.XTPByEmployee.Text = "By Employee"
        '
        'GCProposeEmployee
        '
        Me.GCProposeEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProposeEmployee.Location = New System.Drawing.Point(0, 0)
        Me.GCProposeEmployee.MainView = Me.GVProposeEmployee
        Me.GCProposeEmployee.Name = "GCProposeEmployee"
        Me.GCProposeEmployee.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RISLUEType})
        Me.GCProposeEmployee.Size = New System.Drawing.Size(992, 612)
        Me.GCProposeEmployee.TabIndex = 1
        Me.GCProposeEmployee.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProposeEmployee})
        '
        'GVProposeEmployee
        '
        Me.GVProposeEmployee.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVProposeEmployee.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVProposeEmployee.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVProposeEmployee.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVProposeEmployee.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVProposeEmployee.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVProposeEmployee.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVProposeEmployee.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVProposeEmployee.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVProposeEmployee.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVProposeEmployee.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVProposeEmployee.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVProposeEmployee.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVProposeEmployee.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVProposeEmployee.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVProposeEmployee.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVProposeEmployee.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVProposeEmployee.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVProposeEmployee.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVProposeEmployee.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVProposeEmployee.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVProposeEmployee.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVProposeEmployee.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVProposeEmployee.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVProposeEmployee.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVProposeEmployee.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVProposeEmployee.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVProposeEmployee.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVProposeEmployee.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVProposeEmployee.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVProposeEmployee.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVProposeEmployee.AppearancePrint.Row.Options.UseFont = True
        Me.GVProposeEmployee.ColumnPanelRowHeight = 32
        Me.GVProposeEmployee.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCIdEmployee, Me.GCIdDepartement, Me.GCIdDepartementSub, Me.GCDepartement, Me.GCEmployeeCode, Me.GCEmployeeName, Me.GCEmployeePosition, Me.GCIdEmployeeStatus, Me.GCEmployeeStatus, Me.GCToSalary, Me.GCConversionType, Me.GCIdOvertime, Me.GCNumber, Me.GCIdOvertimeType, Me.GCOvertimeType, Me.GCDate, Me.GCIsDayOff, Me.GCStartWork, Me.GCEndWork, Me.GCBreakHours, Me.GCTotalHours, Me.GCOvertimePropse, Me.GCIdReportStatus, Me.GCReportStatus, Me.GCCreatedBy, Me.GCCreatedAt})
        Me.GVProposeEmployee.GridControl = Me.GCProposeEmployee
        Me.GVProposeEmployee.GroupCount = 1
        Me.GVProposeEmployee.Name = "GVProposeEmployee"
        Me.GVProposeEmployee.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVProposeEmployee.OptionsBehavior.Editable = False
        Me.GVProposeEmployee.OptionsFind.AlwaysVisible = True
        Me.GVProposeEmployee.OptionsPrint.AllowMultilineHeaders = True
        Me.GVProposeEmployee.OptionsView.ColumnAutoWidth = False
        Me.GVProposeEmployee.OptionsView.ShowGroupPanel = False
        Me.GVProposeEmployee.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GCIdEmployee
        '
        Me.GCIdEmployee.FieldName = "id_employee"
        Me.GCIdEmployee.Name = "GCIdEmployee"
        '
        'GCIdDepartement
        '
        Me.GCIdDepartement.FieldName = "id_departement"
        Me.GCIdDepartement.Name = "GCIdDepartement"
        '
        'GCIdDepartementSub
        '
        Me.GCIdDepartementSub.FieldName = "id_departement_sub"
        Me.GCIdDepartementSub.Name = "GCIdDepartementSub"
        Me.GCIdDepartementSub.Width = 109
        '
        'GCDepartement
        '
        Me.GCDepartement.Caption = "Departement"
        Me.GCDepartement.FieldName = "departement"
        Me.GCDepartement.Name = "GCDepartement"
        Me.GCDepartement.Visible = True
        Me.GCDepartement.VisibleIndex = 4
        Me.GCDepartement.Width = 86
        '
        'GCEmployeeCode
        '
        Me.GCEmployeeCode.Caption = "NIP"
        Me.GCEmployeeCode.FieldName = "employee_code"
        Me.GCEmployeeCode.Name = "GCEmployeeCode"
        Me.GCEmployeeCode.Visible = True
        Me.GCEmployeeCode.VisibleIndex = 0
        Me.GCEmployeeCode.Width = 41
        '
        'GCEmployeeName
        '
        Me.GCEmployeeName.Caption = "Employee"
        Me.GCEmployeeName.FieldName = "employee_name"
        Me.GCEmployeeName.Name = "GCEmployeeName"
        Me.GCEmployeeName.Visible = True
        Me.GCEmployeeName.VisibleIndex = 1
        Me.GCEmployeeName.Width = 56
        '
        'GCEmployeePosition
        '
        Me.GCEmployeePosition.AppearanceHeader.Options.UseTextOptions = True
        Me.GCEmployeePosition.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCEmployeePosition.Caption = "Employee Position"
        Me.GCEmployeePosition.FieldName = "employee_position"
        Me.GCEmployeePosition.Name = "GCEmployeePosition"
        Me.GCEmployeePosition.Visible = True
        Me.GCEmployeePosition.VisibleIndex = 2
        Me.GCEmployeePosition.Width = 100
        '
        'GCIdEmployeeStatus
        '
        Me.GCIdEmployeeStatus.FieldName = "id_employee_status"
        Me.GCIdEmployeeStatus.Name = "GCIdEmployeeStatus"
        '
        'GCEmployeeStatus
        '
        Me.GCEmployeeStatus.AppearanceHeader.Options.UseTextOptions = True
        Me.GCEmployeeStatus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCEmployeeStatus.Caption = "Employee Status"
        Me.GCEmployeeStatus.FieldName = "employee_status"
        Me.GCEmployeeStatus.Name = "GCEmployeeStatus"
        Me.GCEmployeeStatus.Visible = True
        Me.GCEmployeeStatus.VisibleIndex = 3
        Me.GCEmployeeStatus.Width = 90
        '
        'GCToSalary
        '
        Me.GCToSalary.FieldName = "to_salary"
        Me.GCToSalary.Name = "GCToSalary"
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
        Me.RISLUEType.View = Me.RepositoryItemSearchLookUpEdit1View
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn27})
        Me.RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "GridColumn8"
        Me.GridColumn18.FieldName = "id_type"
        Me.GridColumn18.Name = "GridColumn18"
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Conversion Type"
        Me.GridColumn19.FieldName = "type"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 0
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "GridColumn1"
        Me.GridColumn20.FieldName = "to_salary"
        Me.GridColumn20.Name = "GridColumn20"
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "GridColumn2"
        Me.GridColumn27.FieldName = "to_dp"
        Me.GridColumn27.Name = "GridColumn27"
        '
        'GCIdOvertime
        '
        Me.GCIdOvertime.FieldName = "id_ot"
        Me.GCIdOvertime.Name = "GCIdOvertime"
        '
        'GCNumber
        '
        Me.GCNumber.Caption = "Number"
        Me.GCNumber.FieldName = "number"
        Me.GCNumber.Name = "GCNumber"
        Me.GCNumber.Visible = True
        Me.GCNumber.VisibleIndex = 5
        Me.GCNumber.Width = 47
        '
        'GCIdOvertimeType
        '
        Me.GCIdOvertimeType.FieldName = "id_ot_type"
        Me.GCIdOvertimeType.Name = "GCIdOvertimeType"
        '
        'GCOvertimeType
        '
        Me.GCOvertimeType.Caption = "Overtime Type"
        Me.GCOvertimeType.FieldName = "ot_type"
        Me.GCOvertimeType.Name = "GCOvertimeType"
        Me.GCOvertimeType.Visible = True
        Me.GCOvertimeType.VisibleIndex = 6
        Me.GCOvertimeType.Width = 81
        '
        'GCDate
        '
        Me.GCDate.Caption = "Date"
        Me.GCDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GCDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCDate.FieldName = "ot_date"
        Me.GCDate.Name = "GCDate"
        Me.GCDate.Visible = True
        Me.GCDate.VisibleIndex = 7
        Me.GCDate.Width = 33
        '
        'GCIsDayOff
        '
        Me.GCIsDayOff.FieldName = "is_day_off"
        Me.GCIsDayOff.Name = "GCIsDayOff"
        '
        'GCStartWork
        '
        Me.GCStartWork.AppearanceHeader.Options.UseTextOptions = True
        Me.GCStartWork.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCStartWork.Caption = "Start Work"
        Me.GCStartWork.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GCStartWork.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCStartWork.FieldName = "ot_start_time"
        Me.GCStartWork.Name = "GCStartWork"
        Me.GCStartWork.Visible = True
        Me.GCStartWork.VisibleIndex = 8
        Me.GCStartWork.Width = 62
        '
        'GCEndWork
        '
        Me.GCEndWork.AppearanceHeader.Options.UseTextOptions = True
        Me.GCEndWork.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCEndWork.Caption = "End Work"
        Me.GCEndWork.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GCEndWork.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCEndWork.FieldName = "ot_end_time"
        Me.GCEndWork.Name = "GCEndWork"
        Me.GCEndWork.Visible = True
        Me.GCEndWork.VisibleIndex = 9
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
        Me.GCBreakHours.Visible = True
        Me.GCBreakHours.VisibleIndex = 10
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
        Me.GCTotalHours.Visible = True
        Me.GCTotalHours.VisibleIndex = 11
        Me.GCTotalHours.Width = 72
        '
        'GCOvertimePropse
        '
        Me.GCOvertimePropse.Caption = "Overtime Propose"
        Me.GCOvertimePropse.FieldName = "ot_note"
        Me.GCOvertimePropse.Name = "GCOvertimePropse"
        Me.GCOvertimePropse.Visible = True
        Me.GCOvertimePropse.VisibleIndex = 12
        Me.GCOvertimePropse.Width = 96
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
        Me.GCReportStatus.VisibleIndex = 13
        Me.GCReportStatus.Width = 77
        '
        'GCCreatedBy
        '
        Me.GCCreatedBy.Caption = "Created By"
        Me.GCCreatedBy.FieldName = "created_by"
        Me.GCCreatedBy.Name = "GCCreatedBy"
        Me.GCCreatedBy.Visible = True
        Me.GCCreatedBy.VisibleIndex = 14
        '
        'GCCreatedAt
        '
        Me.GCCreatedAt.Caption = "Created At"
        Me.GCCreatedAt.FieldName = "created_at"
        Me.GCCreatedAt.Name = "GCCreatedAt"
        Me.GCCreatedAt.Visible = True
        Me.GCCreatedAt.VisibleIndex = 15
        '
        'XTPVerification
        '
        Me.XTPVerification.Controls.Add(Me.XTCVerification)
        Me.XTPVerification.Name = "XTPVerification"
        Me.XTPVerification.Size = New System.Drawing.Size(998, 640)
        Me.XTPVerification.Text = "Verification"
        '
        'XTCVerification
        '
        Me.XTCVerification.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCVerification.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCVerification.Location = New System.Drawing.Point(0, 0)
        Me.XTCVerification.Name = "XTCVerification"
        Me.XTCVerification.SelectedTabPage = Me.XTPByRequestVerification
        Me.XTCVerification.Size = New System.Drawing.Size(998, 640)
        Me.XTCVerification.TabIndex = 2
        Me.XTCVerification.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPByRequestVerification, Me.XTPByEmployeeVerification})
        '
        'XTPByRequestVerification
        '
        Me.XTPByRequestVerification.Controls.Add(Me.GCVerification)
        Me.XTPByRequestVerification.Name = "XTPByRequestVerification"
        Me.XTPByRequestVerification.Size = New System.Drawing.Size(992, 612)
        Me.XTPByRequestVerification.Text = "By Request"
        '
        'GCVerification
        '
        Me.GCVerification.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCVerification.Location = New System.Drawing.Point(0, 0)
        Me.GCVerification.MainView = Me.GVVerification
        Me.GCVerification.Name = "GCVerification"
        Me.GCVerification.Size = New System.Drawing.Size(992, 612)
        Me.GCVerification.TabIndex = 1
        Me.GCVerification.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVVerification})
        '
        'GVVerification
        '
        Me.GVVerification.ColumnPanelRowHeight = 32
        Me.GVVerification.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn47, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn38, Me.GridColumn42, Me.GridColumn43, Me.GridColumn44, Me.GridColumn45, Me.GridColumn46})
        Me.GVVerification.GridControl = Me.GCVerification
        Me.GVVerification.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_hours", Nothing, "{0:N1}")})
        Me.GVVerification.Name = "GVVerification"
        Me.GVVerification.OptionsBehavior.Editable = False
        Me.GVVerification.OptionsFind.AlwaysVisible = True
        Me.GVVerification.OptionsView.ColumnAutoWidth = False
        Me.GVVerification.OptionsView.RowAutoHeight = True
        Me.GVVerification.OptionsView.ShowFooter = True
        Me.GVVerification.OptionsView.ShowGroupPanel = False
        '
        'GridColumn47
        '
        Me.GridColumn47.Caption = "GridColumn47"
        Me.GridColumn47.FieldName = "id_ot_verification"
        Me.GridColumn47.Name = "GridColumn47"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "GridColumn1"
        Me.GridColumn4.FieldName = "id_ot"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Number"
        Me.GridColumn5.FieldName = "number"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        Me.GridColumn5.Width = 47
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Overtime Type"
        Me.GridColumn6.FieldName = "ot_type"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        Me.GridColumn6.Width = 81
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "BandedGridColumn12"
        Me.GridColumn7.FieldName = "id_departement"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Departement"
        Me.GridColumn8.FieldName = "departement"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 2
        '
        'GridColumn38
        '
        Me.GridColumn38.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn38.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn38.Caption = "Date"
        Me.GridColumn38.FieldName = "ot_date"
        Me.GridColumn38.Name = "GridColumn38"
        Me.GridColumn38.Visible = True
        Me.GridColumn38.VisibleIndex = 3
        Me.GridColumn38.Width = 33
        '
        'GridColumn42
        '
        Me.GridColumn42.Caption = "Overtime Propose"
        Me.GridColumn42.FieldName = "ot_note"
        Me.GridColumn42.Name = "GridColumn42"
        Me.GridColumn42.Visible = True
        Me.GridColumn42.VisibleIndex = 4
        Me.GridColumn42.Width = 96
        '
        'GridColumn43
        '
        Me.GridColumn43.Caption = "GridColumn40"
        Me.GridColumn43.FieldName = "id_report_status"
        Me.GridColumn43.Name = "GridColumn43"
        Me.GridColumn43.Width = 76
        '
        'GridColumn44
        '
        Me.GridColumn44.Caption = "Report Status"
        Me.GridColumn44.FieldName = "report_status"
        Me.GridColumn44.Name = "GridColumn44"
        Me.GridColumn44.Visible = True
        Me.GridColumn44.VisibleIndex = 5
        Me.GridColumn44.Width = 77
        '
        'GridColumn45
        '
        Me.GridColumn45.Caption = "Created By"
        Me.GridColumn45.FieldName = "created_by"
        Me.GridColumn45.Name = "GridColumn45"
        Me.GridColumn45.Visible = True
        Me.GridColumn45.VisibleIndex = 6
        '
        'GridColumn46
        '
        Me.GridColumn46.Caption = "Created At"
        Me.GridColumn46.FieldName = "created_at"
        Me.GridColumn46.Name = "GridColumn46"
        Me.GridColumn46.Visible = True
        Me.GridColumn46.VisibleIndex = 7
        '
        'XTPByEmployeeVerification
        '
        Me.XTPByEmployeeVerification.Controls.Add(Me.GCVerificationEmployee)
        Me.XTPByEmployeeVerification.Name = "XTPByEmployeeVerification"
        Me.XTPByEmployeeVerification.Size = New System.Drawing.Size(992, 612)
        Me.XTPByEmployeeVerification.Text = "By Employee"
        '
        'GCVerificationEmployee
        '
        Me.GCVerificationEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCVerificationEmployee.Location = New System.Drawing.Point(0, 0)
        Me.GCVerificationEmployee.MainView = Me.GVVerificationEmployee
        Me.GCVerificationEmployee.Name = "GCVerificationEmployee"
        Me.GCVerificationEmployee.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RISLUETypeVerification})
        Me.GCVerificationEmployee.Size = New System.Drawing.Size(992, 612)
        Me.GCVerificationEmployee.TabIndex = 1
        Me.GCVerificationEmployee.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVVerificationEmployee})
        '
        'GVVerificationEmployee
        '
        Me.GVVerificationEmployee.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVVerificationEmployee.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVVerificationEmployee.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVVerificationEmployee.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVVerificationEmployee.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVVerificationEmployee.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVVerificationEmployee.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVVerificationEmployee.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVVerificationEmployee.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVVerificationEmployee.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVVerificationEmployee.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVVerificationEmployee.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVVerificationEmployee.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVVerificationEmployee.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVVerificationEmployee.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVVerificationEmployee.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVVerificationEmployee.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVVerificationEmployee.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVVerificationEmployee.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVVerificationEmployee.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVVerificationEmployee.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVVerificationEmployee.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVVerificationEmployee.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVVerificationEmployee.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVVerificationEmployee.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVVerificationEmployee.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVVerificationEmployee.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVVerificationEmployee.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVVerificationEmployee.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVVerificationEmployee.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVVerificationEmployee.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVVerificationEmployee.AppearancePrint.Row.Options.UseFont = True
        Me.GVVerificationEmployee.ColumnPanelRowHeight = 32
        Me.GVVerificationEmployee.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn32, Me.GridColumn33, Me.GridColumn34, Me.GridColumn35, Me.GridColumn22, Me.GridColumn36, Me.GridColumn37, Me.GridColumn39, Me.GridColumn41, Me.GridColumn48, Me.GridColumn49, Me.GridColumn50, Me.GridColumn26, Me.GridColumn54, Me.GridColumn55, Me.GridColumn56, Me.GridColumn57, Me.GridColumn58, Me.GridColumn59, Me.GridColumn60, Me.GridColumn61, Me.GridColumn62, Me.GridColumn63, Me.GridColumn21, Me.GridColumn64, Me.GridColumn65, Me.GridColumn66, Me.GridColumn67, Me.GridColumn68})
        Me.GVVerificationEmployee.GridControl = Me.GCVerificationEmployee
        Me.GVVerificationEmployee.GroupCount = 1
        Me.GVVerificationEmployee.Name = "GVVerificationEmployee"
        Me.GVVerificationEmployee.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVVerificationEmployee.OptionsBehavior.Editable = False
        Me.GVVerificationEmployee.OptionsFind.AlwaysVisible = True
        Me.GVVerificationEmployee.OptionsPrint.AllowMultilineHeaders = True
        Me.GVVerificationEmployee.OptionsView.ColumnAutoWidth = False
        Me.GVVerificationEmployee.OptionsView.ShowGroupPanel = False
        Me.GVVerificationEmployee.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn35, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn32
        '
        Me.GridColumn32.FieldName = "id_employee"
        Me.GridColumn32.Name = "GridColumn32"
        '
        'GridColumn33
        '
        Me.GridColumn33.FieldName = "id_departement"
        Me.GridColumn33.Name = "GridColumn33"
        '
        'GridColumn34
        '
        Me.GridColumn34.FieldName = "id_departement_sub"
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.Width = 109
        '
        'GridColumn35
        '
        Me.GridColumn35.Caption = "Departement"
        Me.GridColumn35.FieldName = "departement"
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.Visible = True
        Me.GridColumn35.VisibleIndex = 4
        Me.GridColumn35.Width = 86
        '
        'GridColumn22
        '
        Me.GridColumn22.FieldName = "is_store"
        Me.GridColumn22.Name = "GridColumn22"
        '
        'GridColumn36
        '
        Me.GridColumn36.Caption = "NIP"
        Me.GridColumn36.FieldName = "employee_code"
        Me.GridColumn36.Name = "GridColumn36"
        Me.GridColumn36.Visible = True
        Me.GridColumn36.VisibleIndex = 0
        Me.GridColumn36.Width = 41
        '
        'GridColumn37
        '
        Me.GridColumn37.Caption = "Employee"
        Me.GridColumn37.FieldName = "employee_name"
        Me.GridColumn37.Name = "GridColumn37"
        Me.GridColumn37.Visible = True
        Me.GridColumn37.VisibleIndex = 1
        Me.GridColumn37.Width = 56
        '
        'GridColumn39
        '
        Me.GridColumn39.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn39.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn39.Caption = "Employee Position"
        Me.GridColumn39.FieldName = "employee_position"
        Me.GridColumn39.Name = "GridColumn39"
        Me.GridColumn39.Visible = True
        Me.GridColumn39.VisibleIndex = 2
        Me.GridColumn39.Width = 100
        '
        'GridColumn41
        '
        Me.GridColumn41.FieldName = "id_employee_status"
        Me.GridColumn41.Name = "GridColumn41"
        '
        'GridColumn48
        '
        Me.GridColumn48.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn48.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn48.Caption = "Employee Status"
        Me.GridColumn48.FieldName = "employee_status"
        Me.GridColumn48.Name = "GridColumn48"
        Me.GridColumn48.Visible = True
        Me.GridColumn48.VisibleIndex = 3
        Me.GridColumn48.Width = 90
        '
        'GridColumn49
        '
        Me.GridColumn49.FieldName = "to_salary"
        Me.GridColumn49.Name = "GridColumn49"
        '
        'GridColumn50
        '
        Me.GridColumn50.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn50.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn50.Caption = "Conversion Type"
        Me.GridColumn50.ColumnEdit = Me.RISLUETypeVerification
        Me.GridColumn50.FieldName = "conversion_type"
        Me.GridColumn50.Name = "GridColumn50"
        Me.GridColumn50.Visible = True
        Me.GridColumn50.VisibleIndex = 4
        Me.GridColumn50.Width = 91
        '
        'RISLUETypeVerification
        '
        Me.RISLUETypeVerification.AutoHeight = False
        Me.RISLUETypeVerification.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RISLUETypeVerification.Name = "RISLUETypeVerification"
        Me.RISLUETypeVerification.View = Me.GridView4
        '
        'GridView4
        '
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn28})
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "GridColumn8"
        Me.GridColumn23.FieldName = "id_type"
        Me.GridColumn23.Name = "GridColumn23"
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "Conversion Type"
        Me.GridColumn24.FieldName = "type"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 0
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "GridColumn1"
        Me.GridColumn25.FieldName = "to_salary"
        Me.GridColumn25.Name = "GridColumn25"
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "GridColumn2"
        Me.GridColumn28.FieldName = "to_dp"
        Me.GridColumn28.Name = "GridColumn28"
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "GridColumn26"
        Me.GridColumn26.FieldName = "id_ot"
        Me.GridColumn26.Name = "GridColumn26"
        '
        'GridColumn54
        '
        Me.GridColumn54.FieldName = "id_ot_verification"
        Me.GridColumn54.Name = "GridColumn54"
        '
        'GridColumn55
        '
        Me.GridColumn55.Caption = "Number"
        Me.GridColumn55.FieldName = "number"
        Me.GridColumn55.Name = "GridColumn55"
        Me.GridColumn55.Visible = True
        Me.GridColumn55.VisibleIndex = 5
        Me.GridColumn55.Width = 47
        '
        'GridColumn56
        '
        Me.GridColumn56.FieldName = "id_ot_type"
        Me.GridColumn56.Name = "GridColumn56"
        '
        'GridColumn57
        '
        Me.GridColumn57.Caption = "Overtime Type"
        Me.GridColumn57.FieldName = "ot_type"
        Me.GridColumn57.Name = "GridColumn57"
        Me.GridColumn57.Visible = True
        Me.GridColumn57.VisibleIndex = 6
        Me.GridColumn57.Width = 81
        '
        'GridColumn58
        '
        Me.GridColumn58.Caption = "Date"
        Me.GridColumn58.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn58.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn58.FieldName = "ot_date"
        Me.GridColumn58.Name = "GridColumn58"
        Me.GridColumn58.Visible = True
        Me.GridColumn58.VisibleIndex = 7
        Me.GridColumn58.Width = 33
        '
        'GridColumn59
        '
        Me.GridColumn59.FieldName = "is_day_off"
        Me.GridColumn59.Name = "GridColumn59"
        '
        'GridColumn60
        '
        Me.GridColumn60.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn60.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn60.Caption = "Start Work"
        Me.GridColumn60.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumn60.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn60.FieldName = "start_work_ot"
        Me.GridColumn60.Name = "GridColumn60"
        Me.GridColumn60.Visible = True
        Me.GridColumn60.VisibleIndex = 8
        Me.GridColumn60.Width = 62
        '
        'GridColumn61
        '
        Me.GridColumn61.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn61.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn61.Caption = "End Work"
        Me.GridColumn61.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumn61.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn61.FieldName = "end_work_ot"
        Me.GridColumn61.Name = "GridColumn61"
        Me.GridColumn61.Visible = True
        Me.GridColumn61.VisibleIndex = 9
        Me.GridColumn61.Width = 56
        '
        'GridColumn62
        '
        Me.GridColumn62.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn62.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn62.Caption = "Break (hours)"
        Me.GridColumn62.DisplayFormat.FormatString = "N1"
        Me.GridColumn62.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn62.FieldName = "break_hours"
        Me.GridColumn62.Name = "GridColumn62"
        Me.GridColumn62.Visible = True
        Me.GridColumn62.VisibleIndex = 10
        '
        'GridColumn63
        '
        Me.GridColumn63.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn63.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn63.Caption = "Total (hours)"
        Me.GridColumn63.DisplayFormat.FormatString = "N1"
        Me.GridColumn63.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn63.FieldName = "total_hours"
        Me.GridColumn63.Name = "GridColumn63"
        Me.GridColumn63.Visible = True
        Me.GridColumn63.VisibleIndex = 11
        Me.GridColumn63.Width = 72
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Point"
        Me.GridColumn21.DisplayFormat.FormatString = "N1"
        Me.GridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn21.FieldName = "point_ot"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 12
        '
        'GridColumn64
        '
        Me.GridColumn64.Caption = "Overtime Propose"
        Me.GridColumn64.FieldName = "ot_note"
        Me.GridColumn64.Name = "GridColumn64"
        Me.GridColumn64.Visible = True
        Me.GridColumn64.VisibleIndex = 13
        Me.GridColumn64.Width = 96
        '
        'GridColumn65
        '
        Me.GridColumn65.FieldName = "id_report_status"
        Me.GridColumn65.Name = "GridColumn65"
        '
        'GridColumn66
        '
        Me.GridColumn66.Caption = "Report Status"
        Me.GridColumn66.FieldName = "report_status"
        Me.GridColumn66.Name = "GridColumn66"
        Me.GridColumn66.Visible = True
        Me.GridColumn66.VisibleIndex = 14
        Me.GridColumn66.Width = 77
        '
        'GridColumn67
        '
        Me.GridColumn67.Caption = "Created By"
        Me.GridColumn67.FieldName = "created_by"
        Me.GridColumn67.Name = "GridColumn67"
        Me.GridColumn67.Visible = True
        Me.GridColumn67.VisibleIndex = 15
        '
        'GridColumn68
        '
        Me.GridColumn68.Caption = "Created At"
        Me.GridColumn68.FieldName = "created_at"
        Me.GridColumn68.Name = "GridColumn68"
        Me.GridColumn68.Visible = True
        Me.GridColumn68.VisibleIndex = 16
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.PanelControl4)
        Me.XtraScrollableControl1.Controls.Add(Me.PCEmployee)
        Me.XtraScrollableControl1.Controls.Add(Me.PanelControl3)
        Me.XtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XtraScrollableControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraScrollableControl1.Name = "XtraScrollableControl1"
        Me.XtraScrollableControl1.Size = New System.Drawing.Size(1008, 57)
        Me.XtraScrollableControl1.TabIndex = 20
        '
        'PCEmployee
        '
        Me.PCEmployee.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PCEmployee.Appearance.Options.UseBackColor = True
        Me.PCEmployee.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCEmployee.Controls.Add(Me.SLUEEmployee)
        Me.PCEmployee.Controls.Add(Me.Label3)
        Me.PCEmployee.Dock = System.Windows.Forms.DockStyle.Left
        Me.PCEmployee.Location = New System.Drawing.Point(987, 0)
        Me.PCEmployee.Name = "PCEmployee"
        Me.PCEmployee.Size = New System.Drawing.Size(270, 40)
        Me.PCEmployee.TabIndex = 20
        Me.PCEmployee.Visible = False
        '
        'SLUEEmployee
        '
        Me.SLUEEmployee.Location = New System.Drawing.Point(77, 11)
        Me.SLUEEmployee.Name = "SLUEEmployee"
        Me.SLUEEmployee.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEEmployee.Properties.View = Me.SearchLookUpEdit2View
        Me.SLUEEmployee.Size = New System.Drawing.Size(180, 20)
        Me.SLUEEmployee.TabIndex = 17
        '
        'SearchLookUpEdit2View
        '
        Me.SearchLookUpEdit2View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn15, Me.GridColumn16, Me.GridColumn17})
        Me.SearchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit2View.Name = "SearchLookUpEdit2View"
        Me.SearchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit2View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "GridColumn15"
        Me.GridColumn15.FieldName = "id_employee"
        Me.GridColumn15.Name = "GridColumn15"
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Code"
        Me.GridColumn16.FieldName = "employee_code"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 0
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Name"
        Me.GridColumn17.FieldName = "employee_name"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Employee :"
        '
        'PopupMenu
        '
        Me.PopupMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BBIDuplicate)})
        Me.PopupMenu.Manager = Me.BarManager
        Me.PopupMenu.Name = "PopupMenu"
        '
        'BBIDuplicate
        '
        Me.BBIDuplicate.Caption = "Duplicate"
        Me.BBIDuplicate.Id = 0
        Me.BBIDuplicate.Name = "BBIDuplicate"
        '
        'BarManager
        '
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BBIDuplicate})
        Me.BarManager.MaxItemId = 1
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1008, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 729)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1008, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 729)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1008, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 729)
        '
        'FormEmpOvertime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.XtraScrollableControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "FormEmpOvertime"
        Me.Text = "Overtime"
        CType(Me.GCOvertime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVOvertime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIMEMultiline, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.SLUEPayroll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUEPayrollView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUEDepartement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.XTCType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCType.ResumeLayout(False)
        Me.XTPPropose.ResumeLayout(False)
        CType(Me.XTCPropose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCPropose.ResumeLayout(False)
        Me.XTPByRequest.ResumeLayout(False)
        CType(Me.PanelControlVerification, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlVerification.ResumeLayout(False)
        Me.XTPByEmployee.ResumeLayout(False)
        CType(Me.GCProposeEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProposeEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RISLUEType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPVerification.ResumeLayout(False)
        CType(Me.XTCVerification, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCVerification.ResumeLayout(False)
        Me.XTPByRequestVerification.ResumeLayout(False)
        CType(Me.GCVerification, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVVerification, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPByEmployeeVerification.ResumeLayout(False)
        CType(Me.GCVerificationEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVVerificationEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RISLUETypeVerification, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraScrollableControl1.ResumeLayout(False)
        CType(Me.PCEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCEmployee.ResumeLayout(False)
        Me.PCEmployee.PerformLayout()
        CType(Me.SLUEEmployee.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit2View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GCOvertime As DevExpress.XtraGrid.GridControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents SBViewCA As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBViewOD As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents XtraScrollableControl1 As DevExpress.XtraEditors.XtraScrollableControl
    Friend WithEvents PCEmployee As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents SLUEEmployee As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit2View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SLUEDepartement As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTCPropose As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPByRequest As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPByEmployee As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCProposeEmployee As DevExpress.XtraGrid.GridControl
    Friend WithEvents PanelControlVerification As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents SBVerification As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RIMEMultiline As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents XTCType As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPropose As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPVerification As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GVOvertime As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn40 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCVerification As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVVerification As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn38 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn43 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn44 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn46 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn47 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVProposeEmployee As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCIdEmployee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdDepartementSub As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeePosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdEmployeeStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCToSalary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCConversionType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIsDayOff As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCStartWork As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEndWork As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCBreakHours As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCTotalHours As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOvertimeType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCCreatedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCCreatedAt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOvertimePropse As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RISLUEType As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCIdOvertimeType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdOvertime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTCVerification As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPByRequestVerification As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPByEmployeeVerification As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCVerificationEmployee As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVVerificationEmployee As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn34 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn36 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn37 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn48 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn49 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn50 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RISLUETypeVerification As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn54 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn55 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn56 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn57 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn58 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn59 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn60 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn61 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn62 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn63 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn64 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn65 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn66 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn67 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn68 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLUEPayroll As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SLUEPayrollView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn51 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PopupMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BBIDuplicate As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
End Class
