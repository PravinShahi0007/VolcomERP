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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabControl = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPByRequest = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPByEmployee = New DevExpress.XtraTab.XtraTabPage()
        Me.GCEmployee = New DevExpress.XtraGrid.GridControl()
        Me.GVEmployee = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumn18 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn34 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCIsDayOff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCEValid = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn41 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumn22 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn39 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBEActual = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumn25 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCECheckStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn36 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn37 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PanelControlCheck = New DevExpress.XtraEditors.PanelControl()
        Me.SBVerification = New DevExpress.XtraEditors.SimpleButton()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
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
        Me.XtraScrollableControl1 = New DevExpress.XtraEditors.XtraScrollableControl()
        Me.PCEmployee = New DevExpress.XtraEditors.PanelControl()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SLUEEmployee = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit2View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLUEDepartement = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.GCOvertime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOvertime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIMEMultiline, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.XtraTabControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl.SuspendLayout()
        Me.XTPByRequest.SuspendLayout()
        Me.XTPByEmployee.SuspendLayout()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlCheck, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlCheck.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.GCVerification, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVVerification, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.PCEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCEmployee.SuspendLayout()
        CType(Me.SLUEEmployee.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit2View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUEDepartement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCOvertime
        '
        Me.GCOvertime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOvertime.Location = New System.Drawing.Point(0, 0)
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
        Me.GridColumn9.Caption = "Overtime Propose"
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
        Me.PanelControl4.Location = New System.Drawing.Point(962, 0)
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
        Me.PanelControl3.Controls.Add(Me.Label4)
        Me.PanelControl3.Controls.Add(Me.Label1)
        Me.PanelControl3.Controls.Add(Me.SLUEDepartement)
        Me.PanelControl3.Controls.Add(Me.DEStart)
        Me.PanelControl3.Controls.Add(Me.Label2)
        Me.PanelControl3.Controls.Add(Me.DEUntil)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(692, 40)
        Me.PanelControl3.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "From : "
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(52, 11)
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
        Me.Label2.Location = New System.Drawing.Point(210, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Until : "
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(254, 11)
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
        Me.PanelControl2.Controls.Add(Me.XtraTabControl1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 57)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1008, 672)
        Me.PanelControl2.TabIndex = 2
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(2, 2)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(1004, 668)
        Me.XtraTabControl1.TabIndex = 2
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.XtraTabControl)
        Me.XtraTabPage1.Controls.Add(Me.PanelControlCheck)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(998, 640)
        Me.XtraTabPage1.Text = "Proposed"
        '
        'XtraTabControl
        '
        Me.XtraTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XtraTabControl.Location = New System.Drawing.Point(0, 52)
        Me.XtraTabControl.Name = "XtraTabControl"
        Me.XtraTabControl.SelectedTabPage = Me.XTPByRequest
        Me.XtraTabControl.Size = New System.Drawing.Size(998, 588)
        Me.XtraTabControl.TabIndex = 1
        Me.XtraTabControl.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPByRequest, Me.XTPByEmployee})
        '
        'XTPByRequest
        '
        Me.XTPByRequest.Controls.Add(Me.GCOvertime)
        Me.XTPByRequest.Name = "XTPByRequest"
        Me.XTPByRequest.Size = New System.Drawing.Size(992, 560)
        Me.XTPByRequest.Text = "By Request"
        '
        'XTPByEmployee
        '
        Me.XTPByEmployee.Controls.Add(Me.GCEmployee)
        Me.XTPByEmployee.Name = "XTPByEmployee"
        Me.XTPByEmployee.Size = New System.Drawing.Size(992, 560)
        Me.XTPByEmployee.Text = "By Employee"
        '
        'GCEmployee
        '
        Me.GCEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCEmployee.Location = New System.Drawing.Point(0, 0)
        Me.GCEmployee.MainView = Me.GVEmployee
        Me.GCEmployee.Name = "GCEmployee"
        Me.GCEmployee.Size = New System.Drawing.Size(992, 560)
        Me.GCEmployee.TabIndex = 1
        Me.GCEmployee.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVEmployee})
        '
        'GVEmployee
        '
        Me.GVEmployee.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand2, Me.GBEActual, Me.gridBand4})
        Me.GVEmployee.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumn18, Me.GridColumn19, Me.GridColumn28, Me.BandedGridColumn6, Me.BandedGridColumn7, Me.GridColumn30, Me.GridColumn31, Me.GridColumn33, Me.GridColumn29, Me.GridColumn32, Me.GridColumn34, Me.GCIsDayOff, Me.GCEValid, Me.GridColumn35, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn39, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26, Me.GridColumn41, Me.GridColumn27, Me.GCECheckStatus, Me.GridColumn36, Me.GridColumn37, Me.BandedGridColumn1, Me.BandedGridColumn2, Me.BandedGridColumn3, Me.BandedGridColumn4, Me.BandedGridColumn8, Me.BandedGridColumn5, Me.BandedGridColumn9})
        Me.GVEmployee.GridControl = Me.GCEmployee
        Me.GVEmployee.GroupCount = 1
        Me.GVEmployee.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_hours", Me.GridColumn24, "{0:N1}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ot_det_total_hours", Me.BandedGridColumn4, "{0:N1}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ot_det_overtime_hours", Me.BandedGridColumn8, "{0:N1}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "point", Me.BandedGridColumn5, "{0:N1}")})
        Me.GVEmployee.Name = "GVEmployee"
        Me.GVEmployee.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVEmployee.OptionsBehavior.Editable = False
        Me.GVEmployee.OptionsFind.AlwaysVisible = True
        Me.GVEmployee.OptionsView.ColumnAutoWidth = False
        Me.GVEmployee.OptionsView.ShowFooter = True
        Me.GVEmployee.OptionsView.ShowGroupPanel = False
        Me.GVEmployee.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn28, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridBand1
        '
        Me.GridBand1.Columns.Add(Me.GridColumn18)
        Me.GridBand1.Columns.Add(Me.GridColumn19)
        Me.GridBand1.Columns.Add(Me.GridColumn28)
        Me.GridBand1.Columns.Add(Me.GridColumn30)
        Me.GridBand1.Columns.Add(Me.GridColumn31)
        Me.GridBand1.Columns.Add(Me.GridColumn33)
        Me.GridBand1.Columns.Add(Me.GridColumn29)
        Me.GridBand1.Columns.Add(Me.GridColumn32)
        Me.GridBand1.Columns.Add(Me.GridColumn34)
        Me.GridBand1.Columns.Add(Me.GCIsDayOff)
        Me.GridBand1.Columns.Add(Me.GCEValid)
        Me.GridBand1.Columns.Add(Me.GridColumn35)
        Me.GridBand1.Columns.Add(Me.GridColumn20)
        Me.GridBand1.Columns.Add(Me.GridColumn21)
        Me.GridBand1.Columns.Add(Me.GridColumn41)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 948
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Overtime Id"
        Me.GridColumn18.FieldName = "id_ot"
        Me.GridColumn18.Name = "GridColumn18"
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "GridColumn19"
        Me.GridColumn19.FieldName = "id_departement"
        Me.GridColumn19.Name = "GridColumn19"
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "Departement"
        Me.GridColumn28.FieldName = "departement"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.Visible = True
        Me.GridColumn28.Width = 110
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "Code"
        Me.GridColumn30.FieldName = "employee_code"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.Visible = True
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "Name"
        Me.GridColumn31.FieldName = "employee_name"
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.Visible = True
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "Position"
        Me.GridColumn33.FieldName = "employee_position"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.Visible = True
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "GridColumn29"
        Me.GridColumn29.FieldName = "id_employee_level"
        Me.GridColumn29.Name = "GridColumn29"
        '
        'GridColumn32
        '
        Me.GridColumn32.Caption = "Level"
        Me.GridColumn32.FieldName = "employee_level"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.Visible = True
        '
        'GridColumn34
        '
        Me.GridColumn34.Caption = "Conversion Type"
        Me.GridColumn34.FieldName = "conversion_type"
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.Visible = True
        Me.GridColumn34.Width = 110
        '
        'GCIsDayOff
        '
        Me.GCIsDayOff.Caption = "Day Off"
        Me.GCIsDayOff.FieldName = "is_day_off"
        Me.GCIsDayOff.Name = "GCIsDayOff"
        Me.GCIsDayOff.Visible = True
        '
        'GCEValid
        '
        Me.GCEValid.Caption = "Valid"
        Me.GCEValid.FieldName = "valid"
        Me.GCEValid.Name = "GCEValid"
        Me.GCEValid.Visible = True
        '
        'GridColumn35
        '
        Me.GridColumn35.Caption = "Number"
        Me.GridColumn35.FieldName = "number"
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.Visible = True
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Overtime Type"
        Me.GridColumn20.FieldName = "ot_type"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.Width = 105
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Overtime Date"
        Me.GridColumn21.FieldName = "ot_date"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Visible = True
        Me.GridColumn21.Width = 98
        '
        'GridColumn41
        '
        Me.GridColumn41.Caption = "GridColumn41"
        Me.GridColumn41.FieldName = "id_report_status"
        Me.GridColumn41.Name = "GridColumn41"
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "Submitted"
        Me.gridBand2.Columns.Add(Me.GridColumn22)
        Me.gridBand2.Columns.Add(Me.GridColumn23)
        Me.gridBand2.Columns.Add(Me.GridColumn39)
        Me.gridBand2.Columns.Add(Me.GridColumn24)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 300
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Start Time"
        Me.GridColumn22.FieldName = "ot_start_time"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "End Time"
        Me.GridColumn23.FieldName = "ot_end_time"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Visible = True
        '
        'GridColumn39
        '
        Me.GridColumn39.Caption = "Break (hours)"
        Me.GridColumn39.DisplayFormat.FormatString = "N1"
        Me.GridColumn39.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn39.FieldName = "ot_break"
        Me.GridColumn39.Name = "GridColumn39"
        Me.GridColumn39.Visible = True
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "Total (hours)"
        Me.GridColumn24.DisplayFormat.FormatString = "N1"
        Me.GridColumn24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn24.FieldName = "total_hours"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_hours", "{0:N1}")})
        Me.GridColumn24.Visible = True
        '
        'GBEActual
        '
        Me.GBEActual.Caption = "Actual"
        Me.GBEActual.Columns.Add(Me.BandedGridColumn1)
        Me.GBEActual.Columns.Add(Me.BandedGridColumn2)
        Me.GBEActual.Columns.Add(Me.BandedGridColumn3)
        Me.GBEActual.Columns.Add(Me.BandedGridColumn4)
        Me.GBEActual.Columns.Add(Me.BandedGridColumn8)
        Me.GBEActual.Columns.Add(Me.BandedGridColumn5)
        Me.GBEActual.Name = "GBEActual"
        Me.GBEActual.VisibleIndex = 2
        Me.GBEActual.Width = 450
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "Start Time"
        Me.BandedGridColumn1.FieldName = "ot_det_start_time"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.Visible = True
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "End Time"
        Me.BandedGridColumn2.FieldName = "ot_det_end_time"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.Visible = True
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "Break (hours)"
        Me.BandedGridColumn3.DisplayFormat.FormatString = "N1"
        Me.BandedGridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn3.FieldName = "ot_det_break"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.Visible = True
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "Total (hours)"
        Me.BandedGridColumn4.DisplayFormat.FormatString = "N1"
        Me.BandedGridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn4.FieldName = "ot_det_total_hours"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ot_det_total_hours", "{0:N1}")})
        Me.BandedGridColumn4.Visible = True
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.Caption = "Overtime (hours)"
        Me.BandedGridColumn8.DisplayFormat.FormatString = "N1"
        Me.BandedGridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn8.FieldName = "ot_det_overtime_hours"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        Me.BandedGridColumn8.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ot_det_overtime_hours", "{0:N1}")})
        Me.BandedGridColumn8.Visible = True
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.Caption = "Point"
        Me.BandedGridColumn5.DisplayFormat.FormatString = "N1"
        Me.BandedGridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn5.FieldName = "point"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        Me.BandedGridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "point", "{0:N1}")})
        Me.BandedGridColumn5.Visible = True
        '
        'gridBand4
        '
        Me.gridBand4.Columns.Add(Me.GridColumn25)
        Me.gridBand4.Columns.Add(Me.GridColumn26)
        Me.gridBand4.Columns.Add(Me.GridColumn27)
        Me.gridBand4.Columns.Add(Me.GCECheckStatus)
        Me.gridBand4.Columns.Add(Me.GridColumn36)
        Me.gridBand4.Columns.Add(Me.GridColumn37)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 3
        Me.gridBand4.Width = 463
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Overtime Purpose"
        Me.GridColumn25.FieldName = "ot_note"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.Visible = True
        Me.GridColumn25.Width = 88
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "Payroll Period"
        Me.GridColumn26.FieldName = "payroll_periode"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.Visible = True
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "Report Status"
        Me.GridColumn27.FieldName = "report_status"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.Visible = True
        '
        'GCECheckStatus
        '
        Me.GCECheckStatus.Caption = "Check Status"
        Me.GCECheckStatus.FieldName = "check_status"
        Me.GCECheckStatus.Name = "GCECheckStatus"
        Me.GCECheckStatus.Visible = True
        '
        'GridColumn36
        '
        Me.GridColumn36.Caption = "Created At"
        Me.GridColumn36.FieldName = "created_at"
        Me.GridColumn36.Name = "GridColumn36"
        Me.GridColumn36.Visible = True
        '
        'GridColumn37
        '
        Me.GridColumn37.Caption = "Created By"
        Me.GridColumn37.FieldName = "created_by"
        Me.GridColumn37.Name = "GridColumn37"
        Me.GridColumn37.Visible = True
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.Caption = "BandedGridColumn6"
        Me.BandedGridColumn6.FieldName = "is_store"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.FieldName = "is_point_ho"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.Caption = "BandedGridColumn9"
        Me.BandedGridColumn9.FieldName = "only_dp"
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        '
        'PanelControlCheck
        '
        Me.PanelControlCheck.Controls.Add(Me.SBVerification)
        Me.PanelControlCheck.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlCheck.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlCheck.Name = "PanelControlCheck"
        Me.PanelControlCheck.Size = New System.Drawing.Size(998, 52)
        Me.PanelControlCheck.TabIndex = 1
        '
        'SBVerification
        '
        Me.SBVerification.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBVerification.Image = CType(resources.GetObject("SBVerification.Image"), System.Drawing.Image)
        Me.SBVerification.Location = New System.Drawing.Point(895, 2)
        Me.SBVerification.Name = "SBVerification"
        Me.SBVerification.Size = New System.Drawing.Size(101, 48)
        Me.SBVerification.TabIndex = 0
        Me.SBVerification.Text = "Verification"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.GCVerification)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(998, 640)
        Me.XtraTabPage2.Text = "Verification"
        '
        'GCVerification
        '
        Me.GCVerification.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCVerification.Location = New System.Drawing.Point(0, 0)
        Me.GCVerification.MainView = Me.GVVerification
        Me.GCVerification.Name = "GCVerification"
        Me.GCVerification.Size = New System.Drawing.Size(998, 640)
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
        Me.PCEmployee.Location = New System.Drawing.Point(692, 0)
        Me.PCEmployee.Name = "PCEmployee"
        Me.PCEmployee.Size = New System.Drawing.Size(270, 40)
        Me.PCEmployee.TabIndex = 20
        Me.PCEmployee.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(420, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Departement :"
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
        'SLUEDepartement
        '
        Me.SLUEDepartement.Location = New System.Drawing.Point(503, 11)
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Employee :"
        '
        'FormEmpOvertime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.XtraScrollableControl1)
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
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.XtraTabControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl.ResumeLayout(False)
        Me.XTPByRequest.ResumeLayout(False)
        Me.XTPByEmployee.ResumeLayout(False)
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlCheck, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlCheck.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.GCVerification, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVVerification, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraScrollableControl1.ResumeLayout(False)
        CType(Me.PCEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCEmployee.ResumeLayout(False)
        Me.PCEmployee.PerformLayout()
        CType(Me.SLUEEmployee.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit2View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUEDepartement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

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
    Friend WithEvents XtraTabControl As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPByRequest As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPByEmployee As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCEmployee As DevExpress.XtraGrid.GridControl
    Friend WithEvents PanelControlCheck As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GVEmployee As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn34 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCEValid As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCECheckStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn36 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn37 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCIsDayOff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBEActual As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents SBVerification As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RIMEMultiline As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
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
End Class
