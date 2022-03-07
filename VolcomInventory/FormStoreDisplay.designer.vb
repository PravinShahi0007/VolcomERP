<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormStoreDisplay
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormStoreDisplay))
        Me.XTCStoreDisplay = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPView = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPPropose = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPPS = New DevExpress.XtraGrid.GridControl()
        Me.GVPPS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_display_pps = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_by_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnupdated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnupdated_by_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_comp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_season = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnseason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_report_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDisplayCapacity = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControlLeft = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEComp = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnCreateNew = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SearchLookUpEdit1 = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.DEDisplayDate = New DevExpress.XtraEditors.DateEdit()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.GCDisplay = New DevExpress.XtraGrid.GridControl()
        Me.XTCView = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.GVDisplay = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        CType(Me.XTCStoreDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCStoreDisplay.SuspendLayout()
        Me.XTPView.SuspendLayout()
        Me.XTPPropose.SuspendLayout()
        CType(Me.GCPPS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPPS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControlLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlLeft.SuspendLayout()
        CType(Me.SLEComp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.SearchLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDisplayDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDisplayDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCView.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.GVDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCStoreDisplay
        '
        Me.XTCStoreDisplay.AppearancePage.Header.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTCStoreDisplay.AppearancePage.Header.Options.UseFont = True
        Me.XTCStoreDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCStoreDisplay.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCStoreDisplay.Location = New System.Drawing.Point(0, 0)
        Me.XTCStoreDisplay.Name = "XTCStoreDisplay"
        Me.XTCStoreDisplay.SelectedTabPage = Me.XTPView
        Me.XTCStoreDisplay.Size = New System.Drawing.Size(1007, 484)
        Me.XTCStoreDisplay.TabIndex = 0
        Me.XTCStoreDisplay.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPView, Me.XTPPropose})
        '
        'XTPView
        '
        Me.XTPView.Controls.Add(Me.XTCView)
        Me.XTPView.Image = CType(resources.GetObject("XTPView.Image"), System.Drawing.Image)
        Me.XTPView.Name = "XTPView"
        Me.XTPView.Size = New System.Drawing.Size(1001, 453)
        Me.XTPView.Text = "View"
        '
        'XTPPropose
        '
        Me.XTPPropose.Controls.Add(Me.GCPPS)
        Me.XTPPropose.Controls.Add(Me.PanelControl1)
        Me.XTPPropose.Image = CType(resources.GetObject("XTPPropose.Image"), System.Drawing.Image)
        Me.XTPPropose.Name = "XTPPropose"
        Me.XTPPropose.Size = New System.Drawing.Size(1001, 453)
        Me.XTPPropose.Text = "Propose List"
        '
        'GCPPS
        '
        Me.GCPPS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPPS.Location = New System.Drawing.Point(0, 48)
        Me.GCPPS.MainView = Me.GVPPS
        Me.GCPPS.Name = "GCPPS"
        Me.GCPPS.Size = New System.Drawing.Size(1001, 405)
        Me.GCPPS.TabIndex = 1
        Me.GCPPS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPPS})
        '
        'GVPPS
        '
        Me.GVPPS.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_display_pps, Me.GridColumnnumber, Me.GridColumncreated_date, Me.GridColumncreated_by_name, Me.GridColumnupdated_date, Me.GridColumnupdated_by_name, Me.GridColumnid_comp, Me.GridColumncomp, Me.GridColumnid_season, Me.GridColumnseason, Me.GridColumnid_report_status, Me.GridColumnreport_status, Me.GridColumnnote})
        Me.GVPPS.GridControl = Me.GCPPS
        Me.GVPPS.Name = "GVPPS"
        Me.GVPPS.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVPPS.OptionsBehavior.Editable = False
        Me.GVPPS.OptionsFind.AlwaysVisible = True
        Me.GVPPS.OptionsView.ColumnAutoWidth = False
        Me.GVPPS.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_display_pps
        '
        Me.GridColumnid_display_pps.Caption = "id_display_pps"
        Me.GridColumnid_display_pps.FieldName = "id_display_pps"
        Me.GridColumnid_display_pps.Name = "GridColumnid_display_pps"
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        '
        'GridColumncreated_date
        '
        Me.GridColumncreated_date.Caption = "Created Date"
        Me.GridColumncreated_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumncreated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumncreated_date.FieldName = "created_date"
        Me.GridColumncreated_date.Name = "GridColumncreated_date"
        Me.GridColumncreated_date.Visible = True
        Me.GridColumncreated_date.VisibleIndex = 3
        '
        'GridColumncreated_by_name
        '
        Me.GridColumncreated_by_name.Caption = "Created By"
        Me.GridColumncreated_by_name.FieldName = "created_by_name"
        Me.GridColumncreated_by_name.Name = "GridColumncreated_by_name"
        Me.GridColumncreated_by_name.Visible = True
        Me.GridColumncreated_by_name.VisibleIndex = 4
        '
        'GridColumnupdated_date
        '
        Me.GridColumnupdated_date.Caption = "Updated Date"
        Me.GridColumnupdated_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnupdated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnupdated_date.FieldName = "updated_date"
        Me.GridColumnupdated_date.Name = "GridColumnupdated_date"
        Me.GridColumnupdated_date.Visible = True
        Me.GridColumnupdated_date.VisibleIndex = 5
        '
        'GridColumnupdated_by_name
        '
        Me.GridColumnupdated_by_name.Caption = "Updated By"
        Me.GridColumnupdated_by_name.FieldName = "updated_by_name"
        Me.GridColumnupdated_by_name.Name = "GridColumnupdated_by_name"
        Me.GridColumnupdated_by_name.Visible = True
        Me.GridColumnupdated_by_name.VisibleIndex = 6
        '
        'GridColumnid_comp
        '
        Me.GridColumnid_comp.Caption = "id_comp"
        Me.GridColumnid_comp.FieldName = "id_comp"
        Me.GridColumnid_comp.Name = "GridColumnid_comp"
        '
        'GridColumncomp
        '
        Me.GridColumncomp.Caption = "Store"
        Me.GridColumncomp.FieldName = "comp"
        Me.GridColumncomp.Name = "GridColumncomp"
        Me.GridColumncomp.Visible = True
        Me.GridColumncomp.VisibleIndex = 2
        '
        'GridColumnid_season
        '
        Me.GridColumnid_season.Caption = "id_season"
        Me.GridColumnid_season.FieldName = "id_season"
        Me.GridColumnid_season.Name = "GridColumnid_season"
        '
        'GridColumnseason
        '
        Me.GridColumnseason.Caption = "Season"
        Me.GridColumnseason.FieldName = "season"
        Me.GridColumnseason.Name = "GridColumnseason"
        Me.GridColumnseason.Visible = True
        Me.GridColumnseason.VisibleIndex = 1
        '
        'GridColumnid_report_status
        '
        Me.GridColumnid_report_status.Caption = "id_report_status"
        Me.GridColumnid_report_status.FieldName = "id_report_status"
        Me.GridColumnid_report_status.Name = "GridColumnid_report_status"
        '
        'GridColumnreport_status
        '
        Me.GridColumnreport_status.Caption = "Status"
        Me.GridColumnreport_status.FieldName = "report_status"
        Me.GridColumnreport_status.Name = "GridColumnreport_status"
        Me.GridColumnreport_status.Visible = True
        Me.GridColumnreport_status.VisibleIndex = 7
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnDisplayCapacity)
        Me.PanelControl1.Controls.Add(Me.PanelControlLeft)
        Me.PanelControl1.Controls.Add(Me.BtnCreateNew)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1001, 48)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnDisplayCapacity
        '
        Me.BtnDisplayCapacity.Appearance.BackColor = System.Drawing.Color.OrangeRed
        Me.BtnDisplayCapacity.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDisplayCapacity.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnDisplayCapacity.Appearance.Image = CType(resources.GetObject("BtnDisplayCapacity.Appearance.Image"), System.Drawing.Image)
        Me.BtnDisplayCapacity.Appearance.Options.UseBackColor = True
        Me.BtnDisplayCapacity.Appearance.Options.UseFont = True
        Me.BtnDisplayCapacity.Appearance.Options.UseForeColor = True
        Me.BtnDisplayCapacity.Appearance.Options.UseImage = True
        Me.BtnDisplayCapacity.Location = New System.Drawing.Point(131, 9)
        Me.BtnDisplayCapacity.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnDisplayCapacity.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnDisplayCapacity.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnDisplayCapacity.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnDisplayCapacity.Name = "BtnDisplayCapacity"
        Me.BtnDisplayCapacity.Size = New System.Drawing.Size(133, 29)
        Me.BtnDisplayCapacity.TabIndex = 23
        Me.BtnDisplayCapacity.Text = "Display Capacity"
        '
        'PanelControlLeft
        '
        Me.PanelControlLeft.Controls.Add(Me.BtnPrint)
        Me.PanelControlLeft.Controls.Add(Me.BtnView)
        Me.PanelControlLeft.Controls.Add(Me.SLEComp)
        Me.PanelControlLeft.Controls.Add(Me.SLESeason)
        Me.PanelControlLeft.Controls.Add(Me.LabelControl2)
        Me.PanelControlLeft.Controls.Add(Me.LabelControl1)
        Me.PanelControlLeft.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControlLeft.Location = New System.Drawing.Point(352, 2)
        Me.PanelControlLeft.Name = "PanelControlLeft"
        Me.PanelControlLeft.Size = New System.Drawing.Size(647, 44)
        Me.PanelControlLeft.TabIndex = 21
        '
        'BtnPrint
        '
        Me.BtnPrint.Appearance.BackColor = System.Drawing.Color.DimGray
        Me.BtnPrint.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnPrint.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnPrint.Appearance.Options.UseBackColor = True
        Me.BtnPrint.Appearance.Options.UseFont = True
        Me.BtnPrint.Appearance.Options.UseForeColor = True
        Me.BtnPrint.Location = New System.Drawing.Point(567, 12)
        Me.BtnPrint.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnPrint.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnPrint.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnPrint.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(70, 21)
        Me.BtnPrint.TabIndex = 20
        Me.BtnPrint.Text = "Print List"
        '
        'BtnView
        '
        Me.BtnView.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BtnView.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnView.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnView.Appearance.Options.UseBackColor = True
        Me.BtnView.Appearance.Options.UseFont = True
        Me.BtnView.Appearance.Options.UseForeColor = True
        Me.BtnView.Location = New System.Drawing.Point(501, 12)
        Me.BtnView.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnView.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnView.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnView.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(63, 21)
        Me.BtnView.TabIndex = 19
        Me.BtnView.Text = "View"
        '
        'SLEComp
        '
        Me.SLEComp.Location = New System.Drawing.Point(251, 13)
        Me.SLEComp.Name = "SLEComp"
        Me.SLEComp.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEComp.Properties.ShowClearButton = False
        Me.SLEComp.Properties.View = Me.GridView1
        Me.SLEComp.Size = New System.Drawing.Size(244, 20)
        Me.SLEComp.TabIndex = 4
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'SLESeason
        '
        Me.SLESeason.Location = New System.Drawing.Point(55, 13)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.ShowClearButton = False
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(158, 20)
        Me.SLESeason.TabIndex = 1
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(219, 16)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Store"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(14, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Season"
        '
        'BtnCreateNew
        '
        Me.BtnCreateNew.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnCreateNew.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCreateNew.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnCreateNew.Appearance.Image = CType(resources.GetObject("BtnCreateNew.Appearance.Image"), System.Drawing.Image)
        Me.BtnCreateNew.Appearance.Options.UseBackColor = True
        Me.BtnCreateNew.Appearance.Options.UseFont = True
        Me.BtnCreateNew.Appearance.Options.UseForeColor = True
        Me.BtnCreateNew.Appearance.Options.UseImage = True
        Me.BtnCreateNew.Location = New System.Drawing.Point(11, 9)
        Me.BtnCreateNew.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnCreateNew.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnCreateNew.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnCreateNew.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnCreateNew.Name = "BtnCreateNew"
        Me.BtnCreateNew.Size = New System.Drawing.Size(117, 29)
        Me.BtnCreateNew.TabIndex = 22
        Me.BtnCreateNew.Text = "+ Create New"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.PanelControl3)
        Me.PanelControl2.Controls.Add(Me.SimpleButton1)
        Me.PanelControl2.Controls.Add(Me.SimpleButton2)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(972, 69)
        Me.PanelControl2.TabIndex = 1
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.CheckEdit1)
        Me.PanelControl3.Controls.Add(Me.DEDisplayDate)
        Me.PanelControl3.Controls.Add(Me.LabelControl4)
        Me.PanelControl3.Controls.Add(Me.SearchLookUpEdit1)
        Me.PanelControl3.Controls.Add(Me.LabelControl3)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl3.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(578, 65)
        Me.PanelControl3.TabIndex = 22
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = System.Drawing.Color.DimGray
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton1.Appearance.ForeColor = System.Drawing.Color.White
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Appearance.Options.UseForeColor = True
        Me.SimpleButton1.Location = New System.Drawing.Point(652, 31)
        Me.SimpleButton1.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.SimpleButton1.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.SimpleButton1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.SimpleButton1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(70, 21)
        Me.SimpleButton1.TabIndex = 20
        Me.SimpleButton1.Text = "Print List"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton2.Appearance.ForeColor = System.Drawing.Color.White
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.Appearance.Options.UseForeColor = True
        Me.SimpleButton2.Location = New System.Drawing.Point(586, 31)
        Me.SimpleButton2.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.SimpleButton2.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.SimpleButton2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.SimpleButton2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(63, 21)
        Me.SimpleButton2.TabIndex = 19
        Me.SimpleButton2.Text = "View"
        '
        'SearchLookUpEdit1
        '
        Me.SearchLookUpEdit1.Location = New System.Drawing.Point(12, 30)
        Me.SearchLookUpEdit1.Name = "SearchLookUpEdit1"
        Me.SearchLookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchLookUpEdit1.Properties.ShowClearButton = False
        Me.SearchLookUpEdit1.Properties.View = Me.GridView2
        Me.SearchLookUpEdit1.Size = New System.Drawing.Size(242, 20)
        Me.SearchLookUpEdit1.TabIndex = 4
        '
        'GridView2
        '
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 11)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl3.TabIndex = 3
        Me.LabelControl3.Text = "Store"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(258, 11)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl4.TabIndex = 4
        Me.LabelControl4.Text = "Date"
        '
        'DEDisplayDate
        '
        Me.DEDisplayDate.EditValue = Nothing
        Me.DEDisplayDate.Location = New System.Drawing.Point(258, 30)
        Me.DEDisplayDate.Name = "DEDisplayDate"
        Me.DEDisplayDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDisplayDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDisplayDate.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEDisplayDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDisplayDate.Size = New System.Drawing.Size(166, 20)
        Me.DEDisplayDate.TabIndex = 2
        '
        'CheckEdit1
        '
        Me.CheckEdit1.Location = New System.Drawing.Point(430, 30)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Caption = "Show Breakdown Season"
        Me.CheckEdit1.Size = New System.Drawing.Size(140, 19)
        Me.CheckEdit1.TabIndex = 2
        '
        'GCDisplay
        '
        Me.GCDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDisplay.Location = New System.Drawing.Point(0, 69)
        Me.GCDisplay.MainView = Me.GVDisplay
        Me.GCDisplay.Name = "GCDisplay"
        Me.GCDisplay.Size = New System.Drawing.Size(972, 378)
        Me.GCDisplay.TabIndex = 2
        Me.GCDisplay.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDisplay})
        '
        'XTCView
        '
        Me.XTCView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCView.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right
        Me.XTCView.Location = New System.Drawing.Point(0, 0)
        Me.XTCView.Name = "XTCView"
        Me.XTCView.SelectedTabPage = Me.XtraTabPage1
        Me.XTCView.Size = New System.Drawing.Size(1001, 453)
        Me.XTCView.TabIndex = 3
        Me.XTCView.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.GCDisplay)
        Me.XtraTabPage1.Controls.Add(Me.PanelControl2)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(972, 447)
        Me.XtraTabPage1.Text = "By Class Group"
        '
        'GVDisplay
        '
        Me.GVDisplay.GridControl = Me.GCDisplay
        Me.GVDisplay.Name = "GVDisplay"
        Me.GVDisplay.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDisplay.OptionsBehavior.ReadOnly = True
        Me.GVDisplay.OptionsFind.AlwaysVisible = True
        Me.GVDisplay.OptionsView.ShowGroupPanel = False
        '
        'FormStoreDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1007, 484)
        Me.Controls.Add(Me.XTCStoreDisplay)
        Me.Name = "FormStoreDisplay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Store Display"
        CType(Me.XTCStoreDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCStoreDisplay.ResumeLayout(False)
        Me.XTPView.ResumeLayout(False)
        Me.XTPPropose.ResumeLayout(False)
        CType(Me.GCPPS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPPS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControlLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlLeft.ResumeLayout(False)
        Me.PanelControlLeft.PerformLayout()
        CType(Me.SLEComp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.SearchLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDisplayDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDisplayDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCView.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.GVDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCStoreDisplay As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPView As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPPropose As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCPPS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPPS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLEComp As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControlLeft As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCreateNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnid_display_pps As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_by_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnupdated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnupdated_by_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_comp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_season As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnseason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_report_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnDisplayCapacity As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEDisplayDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SearchLookUpEdit1 As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents XTCView As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCDisplay As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDisplay As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
End Class
