<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPolis
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPolis))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BExpiredSoon = New DevExpress.XtraEditors.SimpleButton()
        Me.BRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.GCPolisToko = New DevExpress.XtraGrid.GridControl()
        Me.GVPolisToko = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RIMemoLocation = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTCPolis = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPToko = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPListPolis = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPPolisPPS = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPolisPPS = New DevExpress.XtraGrid.GridControl()
        Me.GVPolisPPS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BCreatePolis = New DevExpress.XtraEditors.SimpleButton()
        Me.BRefreshPolisPPS = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPPolisRegister = New DevExpress.XtraTab.XtraTabPage()
        Me.GCRegisterPolis = New DevExpress.XtraGrid.GridControl()
        Me.GVRegisterPolis = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BCreateNewReg = New DevExpress.XtraEditors.SimpleButton()
        Me.BRefreshRegisterPolis = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPFixedAsset = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCPolisToko, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPolisToko, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIMemoLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCPolis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPolis.SuspendLayout()
        Me.XTPToko.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPListPolis.SuspendLayout()
        Me.XTPPolisPPS.SuspendLayout()
        CType(Me.GCPolisPPS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPolisPPS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPPolisRegister.SuspendLayout()
        CType(Me.GCRegisterPolis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRegisterPolis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BExpiredSoon)
        Me.PanelControl1.Controls.Add(Me.BRefresh)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(997, 46)
        Me.PanelControl1.TabIndex = 0
        '
        'BExpiredSoon
        '
        Me.BExpiredSoon.Dock = System.Windows.Forms.DockStyle.Right
        Me.BExpiredSoon.Image = CType(resources.GetObject("BExpiredSoon.Image"), System.Drawing.Image)
        Me.BExpiredSoon.ImageIndex = 13
        Me.BExpiredSoon.Location = New System.Drawing.Point(726, 2)
        Me.BExpiredSoon.Name = "BExpiredSoon"
        Me.BExpiredSoon.Size = New System.Drawing.Size(147, 42)
        Me.BExpiredSoon.TabIndex = 19
        Me.BExpiredSoon.TabStop = False
        Me.BExpiredSoon.Text = "View Expired Soon"
        '
        'BRefresh
        '
        Me.BRefresh.Dock = System.Windows.Forms.DockStyle.Right
        Me.BRefresh.Image = CType(resources.GetObject("BRefresh.Image"), System.Drawing.Image)
        Me.BRefresh.ImageIndex = 13
        Me.BRefresh.Location = New System.Drawing.Point(873, 2)
        Me.BRefresh.Name = "BRefresh"
        Me.BRefresh.Size = New System.Drawing.Size(122, 42)
        Me.BRefresh.TabIndex = 18
        Me.BRefresh.TabStop = False
        Me.BRefresh.Text = "Show All"
        '
        'GCPolisToko
        '
        Me.GCPolisToko.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPolisToko.Location = New System.Drawing.Point(0, 46)
        Me.GCPolisToko.MainView = Me.GVPolisToko
        Me.GCPolisToko.Name = "GCPolisToko"
        Me.GCPolisToko.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RIMemoLocation})
        Me.GCPolisToko.Size = New System.Drawing.Size(997, 389)
        Me.GCPolisToko.TabIndex = 1
        Me.GCPolisToko.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPolisToko})
        '
        'GVPolisToko
        '
        Me.GVPolisToko.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn10, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn11})
        Me.GVPolisToko.GridControl = Me.GCPolisToko
        Me.GVPolisToko.Name = "GVPolisToko"
        Me.GVPolisToko.OptionsView.AllowCellMerge = True
        Me.GVPolisToko.OptionsView.ShowGroupPanel = False
        Me.GVPolisToko.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn10, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_polis"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Store"
        Me.GridColumn2.FieldName = "polis_object"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 142
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Location"
        Me.GridColumn3.ColumnEdit = Me.RIMemoLocation
        Me.GridColumn3.FieldName = "polis_object_location"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 142
        '
        'RIMemoLocation
        '
        Me.RIMemoLocation.Name = "RIMemoLocation"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Start Date"
        Me.GridColumn4.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn4.FieldName = "start_date"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 142
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "End Date"
        Me.GridColumn5.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn5.FieldName = "end_date"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        Me.GridColumn5.Width = 142
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Polis By"
        Me.GridColumn6.FieldName = "comp_name_polis"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        Me.GridColumn6.Width = 142
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Expired In (days)"
        Me.GridColumn10.DisplayFormat.FormatString = "N0"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn10.FieldName = "expired_in"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 6
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Polis Number"
        Me.GridColumn7.FieldName = "polis_number"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 5
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Polis Untuk"
        Me.GridColumn8.FieldName = "polis_untuk"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 8
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Premi"
        Me.GridColumn9.DisplayFormat.FormatString = "N2"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn9.FieldName = "premi"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 9
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Total Nilai Pertanggungan"
        Me.GridColumn11.FieldName = "nilai_total"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 7
        '
        'XTCPolis
        '
        Me.XTCPolis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCPolis.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCPolis.Location = New System.Drawing.Point(0, 0)
        Me.XTCPolis.Name = "XTCPolis"
        Me.XTCPolis.SelectedTabPage = Me.XTPToko
        Me.XTCPolis.Size = New System.Drawing.Size(1009, 491)
        Me.XTCPolis.TabIndex = 2
        Me.XTCPolis.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPToko, Me.XTPFixedAsset})
        '
        'XTPToko
        '
        Me.XTPToko.Controls.Add(Me.XtraTabControl1)
        Me.XTPToko.Name = "XTPToko"
        Me.XTPToko.Size = New System.Drawing.Size(1003, 463)
        Me.XTPToko.Text = "Toko"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPListPolis
        Me.XtraTabControl1.Size = New System.Drawing.Size(1003, 463)
        Me.XtraTabControl1.TabIndex = 2
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPListPolis, Me.XTPPolisPPS, Me.XTPPolisRegister})
        '
        'XTPListPolis
        '
        Me.XTPListPolis.Controls.Add(Me.GCPolisToko)
        Me.XTPListPolis.Controls.Add(Me.PanelControl1)
        Me.XTPListPolis.Name = "XTPListPolis"
        Me.XTPListPolis.Size = New System.Drawing.Size(997, 435)
        Me.XTPListPolis.Text = "List Polis"
        '
        'XTPPolisPPS
        '
        Me.XTPPolisPPS.Controls.Add(Me.GCPolisPPS)
        Me.XTPPolisPPS.Controls.Add(Me.BCreatePolis)
        Me.XTPPolisPPS.Controls.Add(Me.BRefreshPolisPPS)
        Me.XTPPolisPPS.Name = "XTPPolisPPS"
        Me.XTPPolisPPS.Size = New System.Drawing.Size(997, 435)
        Me.XTPPolisPPS.Text = "Proposal Polis"
        '
        'GCPolisPPS
        '
        Me.GCPolisPPS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPolisPPS.Location = New System.Drawing.Point(0, 0)
        Me.GCPolisPPS.MainView = Me.GVPolisPPS
        Me.GCPolisPPS.Name = "GCPolisPPS"
        Me.GCPolisPPS.Size = New System.Drawing.Size(997, 359)
        Me.GCPolisPPS.TabIndex = 0
        Me.GCPolisPPS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPolisPPS})
        '
        'GVPolisPPS
        '
        Me.GVPolisPPS.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15})
        Me.GVPolisPPS.GridControl = Me.GCPolisPPS
        Me.GVPolisPPS.Name = "GVPolisPPS"
        Me.GVPolisPPS.OptionsBehavior.Editable = False
        Me.GVPolisPPS.OptionsBehavior.ReadOnly = True
        Me.GVPolisPPS.OptionsView.ShowGroupPanel = False
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "ID"
        Me.GridColumn12.FieldName = "id_polis_pps"
        Me.GridColumn12.Name = "GridColumn12"
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Number"
        Me.GridColumn13.FieldName = "number"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 0
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Step"
        Me.GridColumn14.FieldName = "step_desc"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 1
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Report Status"
        Me.GridColumn15.FieldName = "report_status"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 2
        '
        'BCreatePolis
        '
        Me.BCreatePolis.Appearance.BackColor = System.Drawing.Color.DarkBlue
        Me.BCreatePolis.Appearance.ForeColor = System.Drawing.Color.White
        Me.BCreatePolis.Appearance.Options.UseBackColor = True
        Me.BCreatePolis.Appearance.Options.UseForeColor = True
        Me.BCreatePolis.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BCreatePolis.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BCreatePolis.Location = New System.Drawing.Point(0, 359)
        Me.BCreatePolis.Name = "BCreatePolis"
        Me.BCreatePolis.Size = New System.Drawing.Size(997, 40)
        Me.BCreatePolis.TabIndex = 5
        Me.BCreatePolis.Text = "Create New Proposal"
        '
        'BRefreshPolisPPS
        '
        Me.BRefreshPolisPPS.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BRefreshPolisPPS.Appearance.ForeColor = System.Drawing.Color.White
        Me.BRefreshPolisPPS.Appearance.Options.UseBackColor = True
        Me.BRefreshPolisPPS.Appearance.Options.UseForeColor = True
        Me.BRefreshPolisPPS.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BRefreshPolisPPS.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BRefreshPolisPPS.Location = New System.Drawing.Point(0, 399)
        Me.BRefreshPolisPPS.Name = "BRefreshPolisPPS"
        Me.BRefreshPolisPPS.Size = New System.Drawing.Size(997, 36)
        Me.BRefreshPolisPPS.TabIndex = 1
        Me.BRefreshPolisPPS.Text = "Refresh"
        '
        'XTPPolisRegister
        '
        Me.XTPPolisRegister.Controls.Add(Me.GCRegisterPolis)
        Me.XTPPolisRegister.Controls.Add(Me.BCreateNewReg)
        Me.XTPPolisRegister.Controls.Add(Me.BRefreshRegisterPolis)
        Me.XTPPolisRegister.Name = "XTPPolisRegister"
        Me.XTPPolisRegister.Size = New System.Drawing.Size(997, 435)
        Me.XTPPolisRegister.Text = "Pendaftaran Nomor Polis"
        '
        'GCRegisterPolis
        '
        Me.GCRegisterPolis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRegisterPolis.Location = New System.Drawing.Point(0, 0)
        Me.GCRegisterPolis.MainView = Me.GVRegisterPolis
        Me.GCRegisterPolis.Name = "GCRegisterPolis"
        Me.GCRegisterPolis.Size = New System.Drawing.Size(997, 357)
        Me.GCRegisterPolis.TabIndex = 3
        Me.GCRegisterPolis.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRegisterPolis})
        '
        'GVRegisterPolis
        '
        Me.GVRegisterPolis.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn16, Me.GridColumn21, Me.GridColumn17, Me.GridColumn20, Me.GridColumn19})
        Me.GVRegisterPolis.GridControl = Me.GCRegisterPolis
        Me.GVRegisterPolis.Name = "GVRegisterPolis"
        Me.GVRegisterPolis.OptionsBehavior.Editable = False
        Me.GVRegisterPolis.OptionsBehavior.ReadOnly = True
        Me.GVRegisterPolis.OptionsView.ShowGroupPanel = False
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "ID"
        Me.GridColumn16.FieldName = "id_polis_reg"
        Me.GridColumn16.Name = "GridColumn16"
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "ID PPS"
        Me.GridColumn21.FieldName = "id_polis_pps"
        Me.GridColumn21.Name = "GridColumn21"
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Number"
        Me.GridColumn17.FieldName = "number"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 0
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Propossal Number"
        Me.GridColumn20.FieldName = "pps_number"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 1
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Report Status"
        Me.GridColumn19.FieldName = "report_status"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 2
        '
        'BCreateNewReg
        '
        Me.BCreateNewReg.Appearance.BackColor = System.Drawing.Color.DarkBlue
        Me.BCreateNewReg.Appearance.ForeColor = System.Drawing.Color.White
        Me.BCreateNewReg.Appearance.Options.UseBackColor = True
        Me.BCreateNewReg.Appearance.Options.UseForeColor = True
        Me.BCreateNewReg.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BCreateNewReg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BCreateNewReg.Location = New System.Drawing.Point(0, 357)
        Me.BCreateNewReg.Name = "BCreateNewReg"
        Me.BCreateNewReg.Size = New System.Drawing.Size(997, 42)
        Me.BCreateNewReg.TabIndex = 4
        Me.BCreateNewReg.Text = "Register Polis from Proposal"
        '
        'BRefreshRegisterPolis
        '
        Me.BRefreshRegisterPolis.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BRefreshRegisterPolis.Appearance.ForeColor = System.Drawing.Color.White
        Me.BRefreshRegisterPolis.Appearance.Options.UseBackColor = True
        Me.BRefreshRegisterPolis.Appearance.Options.UseForeColor = True
        Me.BRefreshRegisterPolis.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BRefreshRegisterPolis.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BRefreshRegisterPolis.Location = New System.Drawing.Point(0, 399)
        Me.BRefreshRegisterPolis.Name = "BRefreshRegisterPolis"
        Me.BRefreshRegisterPolis.Size = New System.Drawing.Size(997, 36)
        Me.BRefreshRegisterPolis.TabIndex = 2
        Me.BRefreshRegisterPolis.Text = "Refresh"
        '
        'XTPFixedAsset
        '
        Me.XTPFixedAsset.Name = "XTPFixedAsset"
        Me.XTPFixedAsset.Size = New System.Drawing.Size(1003, 463)
        Me.XTPFixedAsset.Text = "Fixed Asset"
        '
        'FormPolis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1009, 491)
        Me.Controls.Add(Me.XTCPolis)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPolis"
        Me.Text = "List Polis"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCPolisToko, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPolisToko, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIMemoLocation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCPolis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCPolis.ResumeLayout(False)
        Me.XTPToko.ResumeLayout(False)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPListPolis.ResumeLayout(False)
        Me.XTPPolisPPS.ResumeLayout(False)
        CType(Me.GCPolisPPS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPolisPPS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPPolisRegister.ResumeLayout(False)
        CType(Me.GCRegisterPolis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRegisterPolis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCPolisToko As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPolisToko As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTCPolis As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPToko As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPFixedAsset As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents BExpiredSoon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RIMemoLocation As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPListPolis As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPPolisPPS As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCPolisPPS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPolisPPS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BRefreshPolisPPS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPPolisRegister As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCRegisterPolis As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRegisterPolis As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BRefreshRegisterPolis As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BCreatePolis As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BCreateNewReg As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
End Class
