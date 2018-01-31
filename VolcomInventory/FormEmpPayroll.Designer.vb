<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpPayroll
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpPayroll))
        Me.XTCPayroll = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPeriode = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPayrollPeriode = New DevExpress.XtraGrid.GridControl()
        Me.GVPayrollPeriode = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPStart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPEnd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastUpd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastUpdBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPSalaryFormat = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPayroll = New DevExpress.XtraGrid.GridControl()
        Me.GVPayroll = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIDDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIDEmployee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNIP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLevel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPosition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnContractEnd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnWorkingDays = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotOvertime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBasicSalary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnJobAllowance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMealAllowance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTransportAllowance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnHousingAllowance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVehicleAttndAllowance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotTHP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPointRegular = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOTReguler = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPointMkt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOtMkt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPointIA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOtIA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPointSales = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOtSales = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPointProd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOTProd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPointGeneral = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOtGeneral = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIuranKoperasi = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPinjamanKoperasi = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUniform = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnWHSale = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnREIKI = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnKasBon = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSPT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMissing = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPotLain2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDropQuickMenu = New DevExpress.XtraEditors.DropDownButton()
        Me.PopupMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.BBJamsostek = New DevExpress.XtraBars.BarButtonItem()
        Me.BBDeduction = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.BGetEmployee = New DevExpress.XtraEditors.SimpleButton()
        Me.BOvertime = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.ViewPopWorksheet = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMDelEmp = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.XTCPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPayroll.SuspendLayout()
        Me.XTPPeriode.SuspendLayout()
        CType(Me.GCPayrollPeriode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPayrollPeriode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPSalaryFormat.SuspendLayout()
        CType(Me.GCPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PopupMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewPopWorksheet.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCPayroll
        '
        Me.XTCPayroll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCPayroll.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCPayroll.Location = New System.Drawing.Point(0, 0)
        Me.XTCPayroll.Name = "XTCPayroll"
        Me.XTCPayroll.SelectedTabPage = Me.XTPPeriode
        Me.XTCPayroll.Size = New System.Drawing.Size(1121, 469)
        Me.XTCPayroll.TabIndex = 0
        Me.XTCPayroll.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPeriode, Me.XTPSalaryFormat})
        '
        'XTPPeriode
        '
        Me.XTPPeriode.Controls.Add(Me.GCPayrollPeriode)
        Me.XTPPeriode.Name = "XTPPeriode"
        Me.XTPPeriode.Size = New System.Drawing.Size(1115, 441)
        Me.XTPPeriode.Text = "Periode"
        '
        'GCPayrollPeriode
        '
        Me.GCPayrollPeriode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPayrollPeriode.Location = New System.Drawing.Point(0, 0)
        Me.GCPayrollPeriode.MainView = Me.GVPayrollPeriode
        Me.GCPayrollPeriode.Name = "GCPayrollPeriode"
        Me.GCPayrollPeriode.Size = New System.Drawing.Size(1115, 441)
        Me.GCPayrollPeriode.TabIndex = 0
        Me.GCPayrollPeriode.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPayrollPeriode})
        '
        'GVPayrollPeriode
        '
        Me.GVPayrollPeriode.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnID, Me.GridColumnPStart, Me.GridColumnPEnd, Me.GridColumnLastUpd, Me.GridColumnLastUpdBy, Me.GridColumnNote})
        Me.GVPayrollPeriode.GridControl = Me.GCPayrollPeriode
        Me.GVPayrollPeriode.Name = "GVPayrollPeriode"
        Me.GVPayrollPeriode.OptionsBehavior.ReadOnly = True
        Me.GVPayrollPeriode.OptionsView.ShowGroupPanel = False
        '
        'GridColumnID
        '
        Me.GridColumnID.Caption = "ID"
        Me.GridColumnID.FieldName = "id_payroll"
        Me.GridColumnID.Name = "GridColumnID"
        '
        'GridColumnPStart
        '
        Me.GridColumnPStart.Caption = "Periode Start"
        Me.GridColumnPStart.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnPStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnPStart.FieldName = "periode_start"
        Me.GridColumnPStart.Name = "GridColumnPStart"
        Me.GridColumnPStart.Visible = True
        Me.GridColumnPStart.VisibleIndex = 0
        Me.GridColumnPStart.Width = 160
        '
        'GridColumnPEnd
        '
        Me.GridColumnPEnd.Caption = "Periode End"
        Me.GridColumnPEnd.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnPEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnPEnd.FieldName = "periode_end"
        Me.GridColumnPEnd.Name = "GridColumnPEnd"
        Me.GridColumnPEnd.Visible = True
        Me.GridColumnPEnd.VisibleIndex = 1
        Me.GridColumnPEnd.Width = 136
        '
        'GridColumnLastUpd
        '
        Me.GridColumnLastUpd.Caption = "Last Update"
        Me.GridColumnLastUpd.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnLastUpd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnLastUpd.FieldName = "employee_name"
        Me.GridColumnLastUpd.Name = "GridColumnLastUpd"
        Me.GridColumnLastUpd.Visible = True
        Me.GridColumnLastUpd.VisibleIndex = 2
        Me.GridColumnLastUpd.Width = 199
        '
        'GridColumnLastUpdBy
        '
        Me.GridColumnLastUpdBy.Caption = "Last Update By"
        Me.GridColumnLastUpdBy.FieldName = "employee_name"
        Me.GridColumnLastUpdBy.Name = "GridColumnLastUpdBy"
        Me.GridColumnLastUpdBy.Visible = True
        Me.GridColumnLastUpdBy.VisibleIndex = 3
        Me.GridColumnLastUpdBy.Width = 162
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "Note"
        Me.GridColumnNote.FieldName = "note"
        Me.GridColumnNote.Name = "GridColumnNote"
        Me.GridColumnNote.Visible = True
        Me.GridColumnNote.VisibleIndex = 4
        Me.GridColumnNote.Width = 440
        '
        'XTPSalaryFormat
        '
        Me.XTPSalaryFormat.Controls.Add(Me.GCPayroll)
        Me.XTPSalaryFormat.Controls.Add(Me.PanelControl1)
        Me.XTPSalaryFormat.Name = "XTPSalaryFormat"
        Me.XTPSalaryFormat.Size = New System.Drawing.Size(1115, 441)
        Me.XTPSalaryFormat.Text = "Worksheet"
        '
        'GCPayroll
        '
        Me.GCPayroll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPayroll.Location = New System.Drawing.Point(0, 39)
        Me.GCPayroll.MainView = Me.GVPayroll
        Me.GCPayroll.Name = "GCPayroll"
        Me.GCPayroll.Size = New System.Drawing.Size(1115, 402)
        Me.GCPayroll.TabIndex = 1
        Me.GCPayroll.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPayroll})
        '
        'GVPayroll
        '
        Me.GVPayroll.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIDDet, Me.GridColumnIDEmployee, Me.GridColumnNIP, Me.GridColumnName, Me.GridColumnDepartement, Me.GridColumnLevel, Me.GridColumnPosition, Me.GridColumnStatus, Me.GridColumnContractEnd, Me.GridColumnWorkingDays, Me.GridColumnTotOvertime, Me.GridColumnBasicSalary, Me.GridColumnJobAllowance, Me.GridColumnMealAllowance, Me.GridColumnTransportAllowance, Me.GridColumnHousingAllowance, Me.GridColumnVehicleAttndAllowance, Me.GridColumnTotTHP, Me.GridColumnPointRegular, Me.GridColumnOTReguler, Me.GridColumnPointMkt, Me.GridColumnOtMkt, Me.GridColumnPointIA, Me.GridColumnOtIA, Me.GridColumnPointSales, Me.GridColumnOtSales, Me.GridColumnPointProd, Me.GridColumnOTProd, Me.GridColumnPointGeneral, Me.GridColumnOtGeneral, Me.GridColumnIuranKoperasi, Me.GridColumnPinjamanKoperasi, Me.GridColumnUniform, Me.GridColumnWHSale, Me.GridColumnREIKI, Me.GridColumnKasBon, Me.GridColumnSPT, Me.GridColumnMissing, Me.GridColumnPotLain2})
        Me.GVPayroll.GridControl = Me.GCPayroll
        Me.GVPayroll.Name = "GVPayroll"
        Me.GVPayroll.OptionsView.ColumnAutoWidth = False
        Me.GVPayroll.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIDDet
        '
        Me.GridColumnIDDet.Caption = "ID"
        Me.GridColumnIDDet.FieldName = "id_payroll_det"
        Me.GridColumnIDDet.Name = "GridColumnIDDet"
        '
        'GridColumnIDEmployee
        '
        Me.GridColumnIDEmployee.Caption = "ID Employee"
        Me.GridColumnIDEmployee.FieldName = "id_employee"
        Me.GridColumnIDEmployee.Name = "GridColumnIDEmployee"
        '
        'GridColumnNIP
        '
        Me.GridColumnNIP.Caption = "NIP"
        Me.GridColumnNIP.FieldName = "employee_code"
        Me.GridColumnNIP.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnNIP.Name = "GridColumnNIP"
        Me.GridColumnNIP.Visible = True
        Me.GridColumnNIP.VisibleIndex = 0
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "employee_name"
        Me.GridColumnName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 1
        '
        'GridColumnDepartement
        '
        Me.GridColumnDepartement.Caption = "Departement"
        Me.GridColumnDepartement.FieldName = "departement"
        Me.GridColumnDepartement.Name = "GridColumnDepartement"
        Me.GridColumnDepartement.Visible = True
        Me.GridColumnDepartement.VisibleIndex = 2
        '
        'GridColumnLevel
        '
        Me.GridColumnLevel.Caption = "Level"
        Me.GridColumnLevel.FieldName = "employee_level"
        Me.GridColumnLevel.Name = "GridColumnLevel"
        Me.GridColumnLevel.Visible = True
        Me.GridColumnLevel.VisibleIndex = 3
        '
        'GridColumnPosition
        '
        Me.GridColumnPosition.Caption = "Position"
        Me.GridColumnPosition.FieldName = "employee_position"
        Me.GridColumnPosition.Name = "GridColumnPosition"
        Me.GridColumnPosition.Visible = True
        Me.GridColumnPosition.VisibleIndex = 4
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "employee_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 5
        '
        'GridColumnContractEnd
        '
        Me.GridColumnContractEnd.Caption = "Contract End"
        Me.GridColumnContractEnd.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnContractEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnContractEnd.FieldName = "end_period"
        Me.GridColumnContractEnd.Name = "GridColumnContractEnd"
        Me.GridColumnContractEnd.Visible = True
        Me.GridColumnContractEnd.VisibleIndex = 6
        '
        'GridColumnWorkingDays
        '
        Me.GridColumnWorkingDays.Caption = "Working Days"
        Me.GridColumnWorkingDays.FieldName = "working_days"
        Me.GridColumnWorkingDays.Name = "GridColumnWorkingDays"
        Me.GridColumnWorkingDays.Visible = True
        Me.GridColumnWorkingDays.VisibleIndex = 7
        '
        'GridColumnTotOvertime
        '
        Me.GridColumnTotOvertime.Caption = "Overtime (hours)"
        Me.GridColumnTotOvertime.DisplayFormat.FormatString = "N1"
        Me.GridColumnTotOvertime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotOvertime.FieldName = "total_ot"
        Me.GridColumnTotOvertime.Name = "GridColumnTotOvertime"
        Me.GridColumnTotOvertime.Visible = True
        Me.GridColumnTotOvertime.VisibleIndex = 8
        '
        'GridColumnBasicSalary
        '
        Me.GridColumnBasicSalary.Caption = "Basic Salary"
        Me.GridColumnBasicSalary.DisplayFormat.FormatString = "N2"
        Me.GridColumnBasicSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnBasicSalary.FieldName = "basic_salary"
        Me.GridColumnBasicSalary.Name = "GridColumnBasicSalary"
        Me.GridColumnBasicSalary.Visible = True
        Me.GridColumnBasicSalary.VisibleIndex = 9
        '
        'GridColumnJobAllowance
        '
        Me.GridColumnJobAllowance.Caption = "Job Allowance"
        Me.GridColumnJobAllowance.DisplayFormat.FormatString = "N2"
        Me.GridColumnJobAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnJobAllowance.FieldName = "allow_job"
        Me.GridColumnJobAllowance.Name = "GridColumnJobAllowance"
        Me.GridColumnJobAllowance.Visible = True
        Me.GridColumnJobAllowance.VisibleIndex = 10
        '
        'GridColumnMealAllowance
        '
        Me.GridColumnMealAllowance.Caption = "Meal Allowance"
        Me.GridColumnMealAllowance.DisplayFormat.FormatString = "N2"
        Me.GridColumnMealAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnMealAllowance.FieldName = "allow_meal"
        Me.GridColumnMealAllowance.Name = "GridColumnMealAllowance"
        Me.GridColumnMealAllowance.Visible = True
        Me.GridColumnMealAllowance.VisibleIndex = 11
        '
        'GridColumnTransportAllowance
        '
        Me.GridColumnTransportAllowance.Caption = "Transport Allowance"
        Me.GridColumnTransportAllowance.DisplayFormat.FormatString = "N2"
        Me.GridColumnTransportAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTransportAllowance.FieldName = "allow_trans"
        Me.GridColumnTransportAllowance.Name = "GridColumnTransportAllowance"
        Me.GridColumnTransportAllowance.Visible = True
        Me.GridColumnTransportAllowance.VisibleIndex = 12
        '
        'GridColumnHousingAllowance
        '
        Me.GridColumnHousingAllowance.Caption = "Housing Allowance"
        Me.GridColumnHousingAllowance.DisplayFormat.FormatString = "N2"
        Me.GridColumnHousingAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnHousingAllowance.FieldName = "allow_house"
        Me.GridColumnHousingAllowance.Name = "GridColumnHousingAllowance"
        Me.GridColumnHousingAllowance.Visible = True
        Me.GridColumnHousingAllowance.VisibleIndex = 13
        '
        'GridColumnVehicleAttndAllowance
        '
        Me.GridColumnVehicleAttndAllowance.Caption = "Vehicle & Attnd Allowance"
        Me.GridColumnVehicleAttndAllowance.DisplayFormat.FormatString = "N2"
        Me.GridColumnVehicleAttndAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnVehicleAttndAllowance.FieldName = "allow_car"
        Me.GridColumnVehicleAttndAllowance.Name = "GridColumnVehicleAttndAllowance"
        Me.GridColumnVehicleAttndAllowance.Visible = True
        Me.GridColumnVehicleAttndAllowance.VisibleIndex = 14
        '
        'GridColumnTotTHP
        '
        Me.GridColumnTotTHP.Caption = "THP Total"
        Me.GridColumnTotTHP.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotTHP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotTHP.FieldName = "tot_thp"
        Me.GridColumnTotTHP.Name = "GridColumnTotTHP"
        Me.GridColumnTotTHP.Visible = True
        Me.GridColumnTotTHP.VisibleIndex = 15
        '
        'GridColumnPointRegular
        '
        Me.GridColumnPointRegular.Caption = "Point Reguler"
        Me.GridColumnPointRegular.DisplayFormat.FormatString = "N2"
        Me.GridColumnPointRegular.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPointRegular.FieldName = "reg_total_point"
        Me.GridColumnPointRegular.Name = "GridColumnPointRegular"
        Me.GridColumnPointRegular.Visible = True
        Me.GridColumnPointRegular.VisibleIndex = 16
        '
        'GridColumnOTReguler
        '
        Me.GridColumnOTReguler.Caption = "Overtime Reguler"
        Me.GridColumnOTReguler.DisplayFormat.FormatString = "N2"
        Me.GridColumnOTReguler.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOTReguler.FieldName = "reg_total_wages"
        Me.GridColumnOTReguler.Name = "GridColumnOTReguler"
        Me.GridColumnOTReguler.Visible = True
        Me.GridColumnOTReguler.VisibleIndex = 17
        '
        'GridColumnPointMkt
        '
        Me.GridColumnPointMkt.Caption = "Point Event Marketing"
        Me.GridColumnPointMkt.DisplayFormat.FormatString = "N2"
        Me.GridColumnPointMkt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPointMkt.FieldName = "mkt_total_point"
        Me.GridColumnPointMkt.Name = "GridColumnPointMkt"
        Me.GridColumnPointMkt.Visible = True
        Me.GridColumnPointMkt.VisibleIndex = 18
        '
        'GridColumnOtMkt
        '
        Me.GridColumnOtMkt.Caption = "Overtime Marketing"
        Me.GridColumnOtMkt.DisplayFormat.FormatString = "N2"
        Me.GridColumnOtMkt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOtMkt.FieldName = "mkt_total_wages"
        Me.GridColumnOtMkt.Name = "GridColumnOtMkt"
        Me.GridColumnOtMkt.Visible = True
        Me.GridColumnOtMkt.VisibleIndex = 19
        '
        'GridColumnPointIA
        '
        Me.GridColumnPointIA.Caption = "Point Event IA"
        Me.GridColumnPointIA.DisplayFormat.FormatString = "N2"
        Me.GridColumnPointIA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPointIA.FieldName = "ia_total_point"
        Me.GridColumnPointIA.Name = "GridColumnPointIA"
        Me.GridColumnPointIA.Visible = True
        Me.GridColumnPointIA.VisibleIndex = 20
        '
        'GridColumnOtIA
        '
        Me.GridColumnOtIA.Caption = "Overtime IA"
        Me.GridColumnOtIA.DisplayFormat.FormatString = "N2"
        Me.GridColumnOtIA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOtIA.FieldName = "ia_total_wages"
        Me.GridColumnOtIA.Name = "GridColumnOtIA"
        Me.GridColumnOtIA.Visible = True
        Me.GridColumnOtIA.VisibleIndex = 21
        '
        'GridColumnPointSales
        '
        Me.GridColumnPointSales.Caption = "Point Event Sales"
        Me.GridColumnPointSales.DisplayFormat.FormatString = "N2"
        Me.GridColumnPointSales.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPointSales.FieldName = "sales_total_point"
        Me.GridColumnPointSales.Name = "GridColumnPointSales"
        Me.GridColumnPointSales.Visible = True
        Me.GridColumnPointSales.VisibleIndex = 22
        '
        'GridColumnOtSales
        '
        Me.GridColumnOtSales.Caption = "Overtime Sales"
        Me.GridColumnOtSales.DisplayFormat.FormatString = "N2"
        Me.GridColumnOtSales.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOtSales.FieldName = "sales_total_wages"
        Me.GridColumnOtSales.Name = "GridColumnOtSales"
        Me.GridColumnOtSales.Visible = True
        Me.GridColumnOtSales.VisibleIndex = 23
        '
        'GridColumnPointProd
        '
        Me.GridColumnPointProd.Caption = "Point Event Production"
        Me.GridColumnPointProd.DisplayFormat.FormatString = "N2"
        Me.GridColumnPointProd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPointProd.FieldName = "prod_total_point"
        Me.GridColumnPointProd.Name = "GridColumnPointProd"
        Me.GridColumnPointProd.Visible = True
        Me.GridColumnPointProd.VisibleIndex = 24
        '
        'GridColumnOTProd
        '
        Me.GridColumnOTProd.Caption = "Overtime Production"
        Me.GridColumnOTProd.DisplayFormat.FormatString = "N2"
        Me.GridColumnOTProd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOTProd.FieldName = "prod_total_wages"
        Me.GridColumnOTProd.Name = "GridColumnOTProd"
        Me.GridColumnOTProd.Visible = True
        Me.GridColumnOTProd.VisibleIndex = 25
        '
        'GridColumnPointGeneral
        '
        Me.GridColumnPointGeneral.Caption = "Point Event General/Other"
        Me.GridColumnPointGeneral.DisplayFormat.FormatString = "N2"
        Me.GridColumnPointGeneral.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPointGeneral.FieldName = "general_total_point"
        Me.GridColumnPointGeneral.Name = "GridColumnPointGeneral"
        Me.GridColumnPointGeneral.Visible = True
        Me.GridColumnPointGeneral.VisibleIndex = 26
        '
        'GridColumnOtGeneral
        '
        Me.GridColumnOtGeneral.Caption = "Overtime General/Other"
        Me.GridColumnOtGeneral.DisplayFormat.FormatString = "N2"
        Me.GridColumnOtGeneral.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOtGeneral.FieldName = "general_total_wages"
        Me.GridColumnOtGeneral.Name = "GridColumnOtGeneral"
        Me.GridColumnOtGeneral.Visible = True
        Me.GridColumnOtGeneral.VisibleIndex = 27
        '
        'GridColumnIuranKoperasi
        '
        Me.GridColumnIuranKoperasi.Caption = "Iuran Koperasi"
        Me.GridColumnIuranKoperasi.Name = "GridColumnIuranKoperasi"
        Me.GridColumnIuranKoperasi.Visible = True
        Me.GridColumnIuranKoperasi.VisibleIndex = 29
        '
        'GridColumnPinjamanKoperasi
        '
        Me.GridColumnPinjamanKoperasi.Caption = "Pinjaman Koperasi"
        Me.GridColumnPinjamanKoperasi.Name = "GridColumnPinjamanKoperasi"
        Me.GridColumnPinjamanKoperasi.Visible = True
        Me.GridColumnPinjamanKoperasi.VisibleIndex = 28
        '
        'GridColumnUniform
        '
        Me.GridColumnUniform.Caption = "Uniform"
        Me.GridColumnUniform.Name = "GridColumnUniform"
        Me.GridColumnUniform.Visible = True
        Me.GridColumnUniform.VisibleIndex = 30
        '
        'GridColumnWHSale
        '
        Me.GridColumnWHSale.Caption = "WH Sale"
        Me.GridColumnWHSale.Name = "GridColumnWHSale"
        Me.GridColumnWHSale.Visible = True
        Me.GridColumnWHSale.VisibleIndex = 31
        '
        'GridColumnREIKI
        '
        Me.GridColumnREIKI.Caption = "REIKI"
        Me.GridColumnREIKI.Name = "GridColumnREIKI"
        Me.GridColumnREIKI.Visible = True
        Me.GridColumnREIKI.VisibleIndex = 32
        '
        'GridColumnKasBon
        '
        Me.GridColumnKasBon.Caption = "Kas Bon"
        Me.GridColumnKasBon.Name = "GridColumnKasBon"
        Me.GridColumnKasBon.Visible = True
        Me.GridColumnKasBon.VisibleIndex = 33
        '
        'GridColumnSPT
        '
        Me.GridColumnSPT.Caption = "SPT"
        Me.GridColumnSPT.Name = "GridColumnSPT"
        Me.GridColumnSPT.Visible = True
        Me.GridColumnSPT.VisibleIndex = 34
        '
        'GridColumnMissing
        '
        Me.GridColumnMissing.Caption = "Tabungan Missing"
        Me.GridColumnMissing.Name = "GridColumnMissing"
        Me.GridColumnMissing.Visible = True
        Me.GridColumnMissing.VisibleIndex = 35
        '
        'GridColumnPotLain2
        '
        Me.GridColumnPotLain2.Caption = "Potongan Lain-lain"
        Me.GridColumnPotLain2.Name = "GridColumnPotLain2"
        Me.GridColumnPotLain2.Visible = True
        Me.GridColumnPotLain2.VisibleIndex = 36
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnDropQuickMenu)
        Me.PanelControl1.Controls.Add(Me.SimpleButton3)
        Me.PanelControl1.Controls.Add(Me.BGetEmployee)
        Me.PanelControl1.Controls.Add(Me.BOvertime)
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1115, 39)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnDropQuickMenu
        '
        Me.BtnDropQuickMenu.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDropQuickMenu.DropDownControl = Me.PopupMenu
        Me.BtnDropQuickMenu.ImageIndex = 14
        Me.BtnDropQuickMenu.ImageList = Me.LargeImageCollection
        Me.BtnDropQuickMenu.Location = New System.Drawing.Point(798, 2)
        Me.BtnDropQuickMenu.Name = "BtnDropQuickMenu"
        Me.BtnDropQuickMenu.Size = New System.Drawing.Size(111, 35)
        Me.BtnDropQuickMenu.TabIndex = 108
        Me.BtnDropQuickMenu.Text = "Deduction"
        '
        'PopupMenu
        '
        Me.PopupMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BBJamsostek), New DevExpress.XtraBars.LinkPersistInfo(Me.BBDeduction)})
        Me.PopupMenu.Manager = Me.BarManager
        Me.PopupMenu.Name = "PopupMenu"
        '
        'BBJamsostek
        '
        Me.BBJamsostek.Caption = "Jamsostek"
        Me.BBJamsostek.Id = 12
        Me.BBJamsostek.Name = "BBJamsostek"
        '
        'BBDeduction
        '
        Me.BBDeduction.Caption = "Deduction"
        Me.BBDeduction.Id = 13
        Me.BBDeduction.Name = "BBDeduction"
        '
        'BarManager
        '
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BBJamsostek, Me.BBDeduction})
        Me.BarManager.MaxItemId = 14
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1121, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 469)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1121, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 469)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1121, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 469)
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "arrow_refresh.png")
        Me.LargeImageCollection.Images.SetKeyName(4, "check_mark.png")
        Me.LargeImageCollection.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.LargeImageCollection.Images.SetKeyName(6, "printer_3.png")
        Me.LargeImageCollection.Images.SetKeyName(7, "save.png")
        Me.LargeImageCollection.Images.SetKeyName(8, "31_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(9, "18_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(10, "1415351112474759854-32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "icon_merchandise_clothes32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "t_shirtgreen.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "lock red.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "ordering32.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "kghostview.png")
        Me.LargeImageCollection.Images.SetKeyName(16, "MetroUI-Folder-OS-Configure-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(17, "Setting(32).png")
        Me.LargeImageCollection.Images.SetKeyName(18, "estimate_icon32.png")
        Me.LargeImageCollection.Images.SetKeyName(19, "copy_icon.png")
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Dock = System.Windows.Forms.DockStyle.Left
        Me.SimpleButton3.ImageIndex = 6
        Me.SimpleButton3.ImageList = Me.LargeImageCollection
        Me.SimpleButton3.Location = New System.Drawing.Point(130, 2)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(86, 35)
        Me.SimpleButton3.TabIndex = 2
        Me.SimpleButton3.Text = "Print"
        '
        'BGetEmployee
        '
        Me.BGetEmployee.Dock = System.Windows.Forms.DockStyle.Left
        Me.BGetEmployee.ImageIndex = 19
        Me.BGetEmployee.ImageList = Me.LargeImageCollection
        Me.BGetEmployee.Location = New System.Drawing.Point(2, 2)
        Me.BGetEmployee.Name = "BGetEmployee"
        Me.BGetEmployee.Size = New System.Drawing.Size(128, 35)
        Me.BGetEmployee.TabIndex = 3
        Me.BGetEmployee.Text = "Insert Employee"
        '
        'BOvertime
        '
        Me.BOvertime.Dock = System.Windows.Forms.DockStyle.Right
        Me.BOvertime.ImageIndex = 18
        Me.BOvertime.ImageList = Me.LargeImageCollection
        Me.BOvertime.Location = New System.Drawing.Point(909, 2)
        Me.BOvertime.Name = "BOvertime"
        Me.BOvertime.Size = New System.Drawing.Size(101, 35)
        Me.BOvertime.TabIndex = 1
        Me.BOvertime.Text = "Overtime"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton1.ImageIndex = 17
        Me.SimpleButton1.ImageList = Me.LargeImageCollection
        Me.SimpleButton1.Location = New System.Drawing.Point(1010, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(103, 35)
        Me.SimpleButton1.TabIndex = 0
        Me.SimpleButton1.Text = "Setting"
        '
        'ViewPopWorksheet
        '
        Me.ViewPopWorksheet.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMDelEmp})
        Me.ViewPopWorksheet.Name = "ViewPreDel"
        Me.ViewPopWorksheet.Size = New System.Drawing.Size(173, 26)
        '
        'CMDelEmp
        '
        Me.CMDelEmp.Name = "CMDelEmp"
        Me.CMDelEmp.Size = New System.Drawing.Size(172, 22)
        Me.CMDelEmp.Text = "Remove Employee"
        '
        'FormEmpPayroll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1121, 469)
        Me.Controls.Add(Me.XTCPayroll)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpPayroll"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Payroll Worksheet"
        CType(Me.XTCPayroll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCPayroll.ResumeLayout(False)
        Me.XTPPeriode.ResumeLayout(False)
        CType(Me.GCPayrollPeriode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPayrollPeriode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPSalaryFormat.ResumeLayout(False)
        CType(Me.GCPayroll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPayroll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PopupMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewPopWorksheet.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents XTCPayroll As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPeriode As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPSalaryFormat As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCPayrollPeriode As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPayrollPeriode As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BOvertime As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCPayroll As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPayroll As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPStart As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPEnd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLastUpd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLastUpdBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNote As DevExpress.XtraGrid.Columns.GridColumn
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents GridColumnIDDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIDEmployee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNIP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLevel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnContractEnd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWorkingDays As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotOvertime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBasicSalary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnJobAllowance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMealAllowance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTransportAllowance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnHousingAllowance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVehicleAttndAllowance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotTHP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPointRegular As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOTReguler As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPointMkt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOtMkt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPointIA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOtIA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPointSales As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOtSales As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPointProd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOTProd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPointGeneral As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOtGeneral As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGetEmployee As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ViewPopWorksheet As ContextMenuStrip
    Friend WithEvents CMDelEmp As ToolStripMenuItem
    Friend WithEvents GridColumnPinjamanKoperasi As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIuranKoperasi As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUniform As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWHSale As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnREIKI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnKasBon As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSPT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMissing As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPotLain2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnDropQuickMenu As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents PopupMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BBJamsostek As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBDeduction As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
End Class
