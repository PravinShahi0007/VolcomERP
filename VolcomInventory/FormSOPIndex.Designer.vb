<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSOPIndex
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSOPIndex))
        Me.XTCSOPIndex = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPBySOP = New DevExpress.XtraTab.XtraTabPage()
        Me.GCBySOP = New DevExpress.XtraGrid.GridControl()
        Me.GVBySOP = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoLinkFile = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoLinkMenuERP = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.BSOPAsset = New DevExpress.XtraEditors.SimpleButton()
        Me.BMasterCatSOP = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPByModul = New DevExpress.XtraTab.XtraTabPage()
        Me.GCByModul = New DevExpress.XtraGrid.GridControl()
        Me.GVByModul = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoFileByModul = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoMenuByModul = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.XTPScheduleSOPAdmin = New DevExpress.XtraTab.XtraTabPage()
        Me.GCScheduleAdmin = New DevExpress.XtraGrid.GridControl()
        Me.GVScheduleAdmin = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SBSetComplete = New DevExpress.XtraEditors.SimpleButton()
        Me.SBSetSOP = New DevExpress.XtraEditors.SimpleButton()
        Me.SBAddSchedule = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPScheduleSOPGuest = New DevExpress.XtraTab.XtraTabPage()
        Me.GCScheduleGuest = New DevExpress.XtraGrid.GridControl()
        Me.GVScheduleGuest = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn36 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPIndexPPS = New DevExpress.XtraTab.XtraTabPage()
        Me.GCIndexPPS = New DevExpress.XtraGrid.GridControl()
        Me.GVIndexPPS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BNewSOP = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPPengajuanKelengkapan = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPengajuanKelengkapan = New DevExpress.XtraGrid.GridControl()
        Me.GVPengajuanKelengkapan = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn37 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn38 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn39 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn40 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPDepartemenTerkait = New DevExpress.XtraTab.XtraTabPage()
        Me.GCDepartementTerkait = New DevExpress.XtraGrid.GridControl()
        Me.GVDepartementTerkait = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn43 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn44 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn45 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn46 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn47 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemHyperLinkEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.RepositoryItemHyperLinkEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumn48 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn49 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCSOPIndex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCSOPIndex.SuspendLayout()
        Me.XTPBySOP.SuspendLayout()
        CType(Me.GCBySOP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBySOP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoLinkFile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoLinkMenuERP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPByModul.SuspendLayout()
        CType(Me.GCByModul, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVByModul, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoFileByModul, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoMenuByModul, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPScheduleSOPAdmin.SuspendLayout()
        CType(Me.GCScheduleAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVScheduleAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.XTPScheduleSOPGuest.SuspendLayout()
        CType(Me.GCScheduleGuest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVScheduleGuest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPIndexPPS.SuspendLayout()
        CType(Me.GCIndexPPS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVIndexPPS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPPengajuanKelengkapan.SuspendLayout()
        CType(Me.GCPengajuanKelengkapan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPengajuanKelengkapan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPDepartemenTerkait.SuspendLayout()
        CType(Me.GCDepartementTerkait, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDepartementTerkait, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCSOPIndex
        '
        Me.XTCSOPIndex.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCSOPIndex.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCSOPIndex.Location = New System.Drawing.Point(0, 48)
        Me.XTCSOPIndex.Name = "XTCSOPIndex"
        Me.XTCSOPIndex.SelectedTabPage = Me.XTPBySOP
        Me.XTCSOPIndex.Size = New System.Drawing.Size(1046, 520)
        Me.XTCSOPIndex.TabIndex = 0
        Me.XTCSOPIndex.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPBySOP, Me.XTPByModul, Me.XTPScheduleSOPAdmin, Me.XTPScheduleSOPGuest, Me.XTPIndexPPS, Me.XTPPengajuanKelengkapan, Me.XTPDepartemenTerkait})
        '
        'XTPBySOP
        '
        Me.XTPBySOP.Controls.Add(Me.GCBySOP)
        Me.XTPBySOP.Controls.Add(Me.BSOPAsset)
        Me.XTPBySOP.Controls.Add(Me.BMasterCatSOP)
        Me.XTPBySOP.Name = "XTPBySOP"
        Me.XTPBySOP.Size = New System.Drawing.Size(1040, 492)
        Me.XTPBySOP.Text = "By SOP"
        '
        'GCBySOP
        '
        Me.GCBySOP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBySOP.Location = New System.Drawing.Point(0, 0)
        Me.GCBySOP.MainView = Me.GVBySOP
        Me.GCBySOP.Name = "GCBySOP"
        Me.GCBySOP.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepoLinkFile, Me.RepoLinkMenuERP})
        Me.GCBySOP.Size = New System.Drawing.Size(1040, 412)
        Me.GCBySOP.TabIndex = 0
        Me.GCBySOP.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBySOP})
        '
        'GVBySOP
        '
        Me.GVBySOP.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn6, Me.GridColumn17, Me.GridColumn16, Me.GridColumn2, Me.GridColumn15, Me.GridColumn48, Me.GridColumn3, Me.GridColumn4})
        Me.GVBySOP.GridControl = Me.GCBySOP
        Me.GVBySOP.Name = "GVBySOP"
        Me.GVBySOP.OptionsBehavior.ReadOnly = True
        Me.GVBySOP.OptionsView.AllowCellMerge = True
        Me.GVBySOP.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_sop"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Departement"
        Me.GridColumn6.FieldName = "departement"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Prosedur"
        Me.GridColumn17.FieldName = "sop_prosedur"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 1
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Sub Prosedur"
        Me.GridColumn16.FieldName = "sop_prosedur_sub"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 2
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Nama SOP"
        Me.GridColumn2.FieldName = "sop_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 4
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Nomor SOP"
        Me.GridColumn15.FieldName = "sop_number"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 3
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "File SOP"
        Me.GridColumn3.ColumnEdit = Me.RepoLinkFile
        Me.GridColumn3.FieldName = "doc_desc"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 6
        '
        'RepoLinkFile
        '
        Me.RepoLinkFile.AutoHeight = False
        Me.RepoLinkFile.Name = "RepoLinkFile"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Menu ERP"
        Me.GridColumn4.ColumnEdit = Me.RepoLinkMenuERP
        Me.GridColumn4.FieldName = "menu_caption"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 7
        '
        'RepoLinkMenuERP
        '
        Me.RepoLinkMenuERP.AutoHeight = False
        Me.RepoLinkMenuERP.Name = "RepoLinkMenuERP"
        '
        'BSOPAsset
        '
        Me.BSOPAsset.Appearance.BackColor = System.Drawing.Color.DarkBlue
        Me.BSOPAsset.Appearance.ForeColor = System.Drawing.Color.White
        Me.BSOPAsset.Appearance.Options.UseBackColor = True
        Me.BSOPAsset.Appearance.Options.UseForeColor = True
        Me.BSOPAsset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BSOPAsset.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BSOPAsset.Location = New System.Drawing.Point(0, 412)
        Me.BSOPAsset.Name = "BSOPAsset"
        Me.BSOPAsset.Size = New System.Drawing.Size(1040, 40)
        Me.BSOPAsset.TabIndex = 9
        Me.BSOPAsset.Text = "Pengajuan kelengkapan SOP"
        '
        'BMasterCatSOP
        '
        Me.BMasterCatSOP.Appearance.BackColor = System.Drawing.Color.DarkBlue
        Me.BMasterCatSOP.Appearance.ForeColor = System.Drawing.Color.White
        Me.BMasterCatSOP.Appearance.Options.UseBackColor = True
        Me.BMasterCatSOP.Appearance.Options.UseForeColor = True
        Me.BMasterCatSOP.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BMasterCatSOP.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BMasterCatSOP.Location = New System.Drawing.Point(0, 452)
        Me.BMasterCatSOP.Name = "BMasterCatSOP"
        Me.BMasterCatSOP.Size = New System.Drawing.Size(1040, 40)
        Me.BMasterCatSOP.TabIndex = 8
        Me.BMasterCatSOP.Text = "Master Kategori SOP"
        '
        'XTPByModul
        '
        Me.XTPByModul.Controls.Add(Me.GCByModul)
        Me.XTPByModul.Name = "XTPByModul"
        Me.XTPByModul.Size = New System.Drawing.Size(1040, 492)
        Me.XTPByModul.Text = "By Modul ERP"
        '
        'GCByModul
        '
        Me.GCByModul.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCByModul.Location = New System.Drawing.Point(0, 0)
        Me.GCByModul.MainView = Me.GVByModul
        Me.GCByModul.Name = "GCByModul"
        Me.GCByModul.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepoFileByModul, Me.RepoMenuByModul})
        Me.GCByModul.Size = New System.Drawing.Size(1040, 492)
        Me.GCByModul.TabIndex = 1
        Me.GCByModul.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVByModul})
        '
        'GVByModul
        '
        Me.GVByModul.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn5, Me.GridColumn7, Me.GridColumn21, Me.GridColumn20, Me.GridColumn18, Me.GridColumn8, Me.GridColumn49, Me.GridColumn9, Me.GridColumn10})
        Me.GVByModul.GridControl = Me.GCByModul
        Me.GVByModul.Name = "GVByModul"
        Me.GVByModul.OptionsBehavior.ReadOnly = True
        Me.GVByModul.OptionsView.AllowCellMerge = True
        Me.GVByModul.OptionsView.ShowGroupPanel = False
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "ID"
        Me.GridColumn5.FieldName = "id_sop"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Departement"
        Me.GridColumn7.FieldName = "departement"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 1
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Prosedur"
        Me.GridColumn21.FieldName = "sop_prosedur"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 2
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Sub Prosedur"
        Me.GridColumn20.FieldName = "sop_prosedur_sub"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 3
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Nomor SOP"
        Me.GridColumn18.FieldName = "sop_number"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 4
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Nama SOP"
        Me.GridColumn8.FieldName = "sop_name"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 5
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "File SOP"
        Me.GridColumn9.ColumnEdit = Me.RepoFileByModul
        Me.GridColumn9.FieldName = "doc_desc"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 7
        '
        'RepoFileByModul
        '
        Me.RepoFileByModul.AutoHeight = False
        Me.RepoFileByModul.Name = "RepoFileByModul"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Menu ERP"
        Me.GridColumn10.ColumnEdit = Me.RepoMenuByModul
        Me.GridColumn10.FieldName = "menu_caption"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        '
        'RepoMenuByModul
        '
        Me.RepoMenuByModul.AutoHeight = False
        Me.RepoMenuByModul.Name = "RepoMenuByModul"
        '
        'XTPScheduleSOPAdmin
        '
        Me.XTPScheduleSOPAdmin.Controls.Add(Me.GCScheduleAdmin)
        Me.XTPScheduleSOPAdmin.Controls.Add(Me.PanelControl2)
        Me.XTPScheduleSOPAdmin.Name = "XTPScheduleSOPAdmin"
        Me.XTPScheduleSOPAdmin.Size = New System.Drawing.Size(1040, 492)
        Me.XTPScheduleSOPAdmin.Text = "Schedule SOP"
        '
        'GCScheduleAdmin
        '
        Me.GCScheduleAdmin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCScheduleAdmin.Location = New System.Drawing.Point(0, 48)
        Me.GCScheduleAdmin.MainView = Me.GVScheduleAdmin
        Me.GCScheduleAdmin.Name = "GCScheduleAdmin"
        Me.GCScheduleAdmin.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit})
        Me.GCScheduleAdmin.Size = New System.Drawing.Size(1040, 444)
        Me.GCScheduleAdmin.TabIndex = 1
        Me.GCScheduleAdmin.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVScheduleAdmin})
        '
        'GVScheduleAdmin
        '
        Me.GVScheduleAdmin.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn19, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28})
        Me.GVScheduleAdmin.GridControl = Me.GCScheduleAdmin
        Me.GVScheduleAdmin.Name = "GVScheduleAdmin"
        Me.GVScheduleAdmin.OptionsBehavior.Editable = False
        Me.GVScheduleAdmin.OptionsView.ColumnAutoWidth = False
        Me.GVScheduleAdmin.OptionsView.RowAutoHeight = True
        Me.GVScheduleAdmin.OptionsView.ShowGroupPanel = False
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Department"
        Me.GridColumn19.FieldName = "departement"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 0
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Date"
        Me.GridColumn22.FieldName = "date"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 1
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "Time"
        Me.GridColumn23.FieldName = "time"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 2
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "SOP"
        Me.GridColumn24.ColumnEdit = Me.RepositoryItemMemoEdit
        Me.GridColumn24.FieldName = "sop"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 3
        '
        'RepositoryItemMemoEdit
        '
        Me.RepositoryItemMemoEdit.Name = "RepositoryItemMemoEdit"
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Milestone"
        Me.GridColumn25.ColumnEdit = Me.RepositoryItemMemoEdit
        Me.GridColumn25.FieldName = "milestone"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 4
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "Status"
        Me.GridColumn26.ColumnEdit = Me.RepositoryItemMemoEdit
        Me.GridColumn26.FieldName = "status"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 5
        '
        'GridColumn27
        '
        Me.GridColumn27.FieldName = "id_sop_schedule"
        Me.GridColumn27.Name = "GridColumn27"
        '
        'GridColumn28
        '
        Me.GridColumn28.FieldName = "id_departement"
        Me.GridColumn28.Name = "GridColumn28"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.SBSetComplete)
        Me.PanelControl2.Controls.Add(Me.SBSetSOP)
        Me.PanelControl2.Controls.Add(Me.SBAddSchedule)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1040, 48)
        Me.PanelControl2.TabIndex = 0
        '
        'SBSetComplete
        '
        Me.SBSetComplete.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBSetComplete.Image = CType(resources.GetObject("SBSetComplete.Image"), System.Drawing.Image)
        Me.SBSetComplete.Location = New System.Drawing.Point(810, 2)
        Me.SBSetComplete.Name = "SBSetComplete"
        Me.SBSetComplete.Size = New System.Drawing.Size(117, 44)
        Me.SBSetComplete.TabIndex = 2
        Me.SBSetComplete.Text = "Set Complete"
        '
        'SBSetSOP
        '
        Me.SBSetSOP.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBSetSOP.Image = CType(resources.GetObject("SBSetSOP.Image"), System.Drawing.Image)
        Me.SBSetSOP.Location = New System.Drawing.Point(927, 2)
        Me.SBSetSOP.Name = "SBSetSOP"
        Me.SBSetSOP.Size = New System.Drawing.Size(111, 44)
        Me.SBSetSOP.TabIndex = 1
        Me.SBSetSOP.Text = "Select SOP"
        '
        'SBAddSchedule
        '
        Me.SBAddSchedule.Dock = System.Windows.Forms.DockStyle.Left
        Me.SBAddSchedule.Image = CType(resources.GetObject("SBAddSchedule.Image"), System.Drawing.Image)
        Me.SBAddSchedule.Location = New System.Drawing.Point(2, 2)
        Me.SBAddSchedule.Name = "SBAddSchedule"
        Me.SBAddSchedule.Size = New System.Drawing.Size(80, 44)
        Me.SBAddSchedule.TabIndex = 0
        Me.SBAddSchedule.Text = "Add"
        '
        'XTPScheduleSOPGuest
        '
        Me.XTPScheduleSOPGuest.Controls.Add(Me.GCScheduleGuest)
        Me.XTPScheduleSOPGuest.Name = "XTPScheduleSOPGuest"
        Me.XTPScheduleSOPGuest.Size = New System.Drawing.Size(1040, 492)
        Me.XTPScheduleSOPGuest.Text = "Schedule SOP"
        '
        'GCScheduleGuest
        '
        Me.GCScheduleGuest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCScheduleGuest.Location = New System.Drawing.Point(0, 0)
        Me.GCScheduleGuest.MainView = Me.GVScheduleGuest
        Me.GCScheduleGuest.Name = "GCScheduleGuest"
        Me.GCScheduleGuest.Size = New System.Drawing.Size(1040, 492)
        Me.GCScheduleGuest.TabIndex = 2
        Me.GCScheduleGuest.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVScheduleGuest})
        '
        'GVScheduleGuest
        '
        Me.GVScheduleGuest.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn29, Me.GridColumn30, Me.GridColumn31, Me.GridColumn32, Me.GridColumn33, Me.GridColumn34, Me.GridColumn35, Me.GridColumn36})
        Me.GVScheduleGuest.GridControl = Me.GCScheduleGuest
        Me.GVScheduleGuest.Name = "GVScheduleGuest"
        Me.GVScheduleGuest.OptionsBehavior.Editable = False
        Me.GVScheduleGuest.OptionsView.ColumnAutoWidth = False
        Me.GVScheduleGuest.OptionsView.RowAutoHeight = True
        Me.GVScheduleGuest.OptionsView.ShowGroupPanel = False
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Department"
        Me.GridColumn29.FieldName = "departement"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 0
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "Date"
        Me.GridColumn30.FieldName = "date"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 1
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "Time"
        Me.GridColumn31.FieldName = "time"
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.Visible = True
        Me.GridColumn31.VisibleIndex = 2
        '
        'GridColumn32
        '
        Me.GridColumn32.Caption = "SOP"
        Me.GridColumn32.FieldName = "sop"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.Visible = True
        Me.GridColumn32.VisibleIndex = 3
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "Milestone"
        Me.GridColumn33.FieldName = "milestone"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 4
        '
        'GridColumn34
        '
        Me.GridColumn34.Caption = "Status"
        Me.GridColumn34.FieldName = "status"
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.Visible = True
        Me.GridColumn34.VisibleIndex = 5
        '
        'GridColumn35
        '
        Me.GridColumn35.FieldName = "id_sop_schedule"
        Me.GridColumn35.Name = "GridColumn35"
        '
        'GridColumn36
        '
        Me.GridColumn36.FieldName = "id_departement"
        Me.GridColumn36.Name = "GridColumn36"
        '
        'XTPIndexPPS
        '
        Me.XTPIndexPPS.Controls.Add(Me.GCIndexPPS)
        Me.XTPIndexPPS.Controls.Add(Me.BNewSOP)
        Me.XTPIndexPPS.Name = "XTPIndexPPS"
        Me.XTPIndexPPS.Size = New System.Drawing.Size(1040, 492)
        Me.XTPIndexPPS.Text = "Proposal Index"
        '
        'GCIndexPPS
        '
        Me.GCIndexPPS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCIndexPPS.Location = New System.Drawing.Point(0, 0)
        Me.GCIndexPPS.MainView = Me.GVIndexPPS
        Me.GCIndexPPS.Name = "GCIndexPPS"
        Me.GCIndexPPS.Size = New System.Drawing.Size(1040, 447)
        Me.GCIndexPPS.TabIndex = 0
        Me.GCIndexPPS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVIndexPPS})
        '
        'GVIndexPPS
        '
        Me.GVIndexPPS.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14})
        Me.GVIndexPPS.GridControl = Me.GCIndexPPS
        Me.GVIndexPPS.Name = "GVIndexPPS"
        Me.GVIndexPPS.OptionsView.ShowGroupPanel = False
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "ID"
        Me.GridColumn11.FieldName = "id_sop_pps"
        Me.GridColumn11.Name = "GridColumn11"
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Proposal Number"
        Me.GridColumn12.FieldName = "number"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 0
        Me.GridColumn12.Width = 237
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Departement"
        Me.GridColumn13.FieldName = "departement"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 1
        Me.GridColumn13.Width = 538
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Report Status"
        Me.GridColumn14.FieldName = "report_status"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 2
        Me.GridColumn14.Width = 247
        '
        'BNewSOP
        '
        Me.BNewSOP.Appearance.BackColor = System.Drawing.Color.DarkBlue
        Me.BNewSOP.Appearance.ForeColor = System.Drawing.Color.White
        Me.BNewSOP.Appearance.Options.UseBackColor = True
        Me.BNewSOP.Appearance.Options.UseForeColor = True
        Me.BNewSOP.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BNewSOP.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BNewSOP.Location = New System.Drawing.Point(0, 447)
        Me.BNewSOP.Name = "BNewSOP"
        Me.BNewSOP.Size = New System.Drawing.Size(1040, 45)
        Me.BNewSOP.TabIndex = 7
        Me.BNewSOP.Text = "New Proposal"
        '
        'XTPPengajuanKelengkapan
        '
        Me.XTPPengajuanKelengkapan.Controls.Add(Me.GCPengajuanKelengkapan)
        Me.XTPPengajuanKelengkapan.Name = "XTPPengajuanKelengkapan"
        Me.XTPPengajuanKelengkapan.Size = New System.Drawing.Size(1040, 492)
        Me.XTPPengajuanKelengkapan.Text = "Pengajuan Kelengkapan SOP"
        '
        'GCPengajuanKelengkapan
        '
        Me.GCPengajuanKelengkapan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPengajuanKelengkapan.Location = New System.Drawing.Point(0, 0)
        Me.GCPengajuanKelengkapan.MainView = Me.GVPengajuanKelengkapan
        Me.GCPengajuanKelengkapan.Name = "GCPengajuanKelengkapan"
        Me.GCPengajuanKelengkapan.Size = New System.Drawing.Size(1040, 492)
        Me.GCPengajuanKelengkapan.TabIndex = 1
        Me.GCPengajuanKelengkapan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPengajuanKelengkapan})
        '
        'GVPengajuanKelengkapan
        '
        Me.GVPengajuanKelengkapan.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn37, Me.GridColumn38, Me.GridColumn39, Me.GridColumn40})
        Me.GVPengajuanKelengkapan.GridControl = Me.GCPengajuanKelengkapan
        Me.GVPengajuanKelengkapan.Name = "GVPengajuanKelengkapan"
        Me.GVPengajuanKelengkapan.OptionsView.ShowGroupPanel = False
        '
        'GridColumn37
        '
        Me.GridColumn37.Caption = "ID"
        Me.GridColumn37.FieldName = "id_sop_pps"
        Me.GridColumn37.Name = "GridColumn37"
        '
        'GridColumn38
        '
        Me.GridColumn38.Caption = "Nomor"
        Me.GridColumn38.FieldName = "number"
        Me.GridColumn38.Name = "GridColumn38"
        Me.GridColumn38.Visible = True
        Me.GridColumn38.VisibleIndex = 0
        Me.GridColumn38.Width = 237
        '
        'GridColumn39
        '
        Me.GridColumn39.Caption = "Nama SOP"
        Me.GridColumn39.FieldName = "sop_name"
        Me.GridColumn39.Name = "GridColumn39"
        Me.GridColumn39.Visible = True
        Me.GridColumn39.VisibleIndex = 1
        Me.GridColumn39.Width = 538
        '
        'GridColumn40
        '
        Me.GridColumn40.Caption = "Status"
        Me.GridColumn40.FieldName = "report_status"
        Me.GridColumn40.Name = "GridColumn40"
        Me.GridColumn40.Visible = True
        Me.GridColumn40.VisibleIndex = 2
        Me.GridColumn40.Width = 247
        '
        'XTPDepartemenTerkait
        '
        Me.XTPDepartemenTerkait.Controls.Add(Me.GCDepartementTerkait)
        Me.XTPDepartemenTerkait.Name = "XTPDepartemenTerkait"
        Me.XTPDepartemenTerkait.Size = New System.Drawing.Size(1040, 492)
        Me.XTPDepartemenTerkait.Text = "SOP Terkait"
        '
        'GCDepartementTerkait
        '
        Me.GCDepartementTerkait.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDepartementTerkait.Location = New System.Drawing.Point(0, 0)
        Me.GCDepartementTerkait.MainView = Me.GVDepartementTerkait
        Me.GCDepartementTerkait.Name = "GCDepartementTerkait"
        Me.GCDepartementTerkait.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemHyperLinkEdit1, Me.RepositoryItemHyperLinkEdit2})
        Me.GCDepartementTerkait.Size = New System.Drawing.Size(1040, 492)
        Me.GCDepartementTerkait.TabIndex = 1
        Me.GCDepartementTerkait.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDepartementTerkait})
        '
        'GVDepartementTerkait
        '
        Me.GVDepartementTerkait.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn41, Me.GridColumn42, Me.GridColumn43, Me.GridColumn44, Me.GridColumn45, Me.GridColumn46, Me.GridColumn47})
        Me.GVDepartementTerkait.GridControl = Me.GCDepartementTerkait
        Me.GVDepartementTerkait.Name = "GVDepartementTerkait"
        Me.GVDepartementTerkait.OptionsBehavior.ReadOnly = True
        Me.GVDepartementTerkait.OptionsView.AllowCellMerge = True
        Me.GVDepartementTerkait.OptionsView.ShowGroupPanel = False
        '
        'GridColumn41
        '
        Me.GridColumn41.Caption = "ID"
        Me.GridColumn41.FieldName = "id_sop"
        Me.GridColumn41.Name = "GridColumn41"
        '
        'GridColumn42
        '
        Me.GridColumn42.Caption = "Milik Departement"
        Me.GridColumn42.FieldName = "departement"
        Me.GridColumn42.Name = "GridColumn42"
        Me.GridColumn42.Visible = True
        Me.GridColumn42.VisibleIndex = 0
        '
        'GridColumn43
        '
        Me.GridColumn43.Caption = "Prosedur"
        Me.GridColumn43.FieldName = "sop_prosedur"
        Me.GridColumn43.Name = "GridColumn43"
        Me.GridColumn43.Visible = True
        Me.GridColumn43.VisibleIndex = 1
        '
        'GridColumn44
        '
        Me.GridColumn44.Caption = "Sub Prosedur"
        Me.GridColumn44.FieldName = "sop_prosedur_sub"
        Me.GridColumn44.Name = "GridColumn44"
        Me.GridColumn44.Visible = True
        Me.GridColumn44.VisibleIndex = 2
        '
        'GridColumn45
        '
        Me.GridColumn45.Caption = "Nama SOP"
        Me.GridColumn45.FieldName = "sop_name"
        Me.GridColumn45.Name = "GridColumn45"
        Me.GridColumn45.Visible = True
        Me.GridColumn45.VisibleIndex = 4
        '
        'GridColumn46
        '
        Me.GridColumn46.Caption = "Nomor SOP"
        Me.GridColumn46.FieldName = "sop_number"
        Me.GridColumn46.Name = "GridColumn46"
        Me.GridColumn46.Visible = True
        Me.GridColumn46.VisibleIndex = 3
        '
        'GridColumn47
        '
        Me.GridColumn47.Caption = "File SOP"
        Me.GridColumn47.ColumnEdit = Me.RepositoryItemHyperLinkEdit1
        Me.GridColumn47.FieldName = "doc_desc"
        Me.GridColumn47.Name = "GridColumn47"
        Me.GridColumn47.Visible = True
        Me.GridColumn47.VisibleIndex = 5
        '
        'RepositoryItemHyperLinkEdit1
        '
        Me.RepositoryItemHyperLinkEdit1.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit1.Name = "RepositoryItemHyperLinkEdit1"
        '
        'RepositoryItemHyperLinkEdit2
        '
        Me.RepositoryItemHyperLinkEdit2.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit2.Name = "RepositoryItemHyperLinkEdit2"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BRefresh)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1046, 48)
        Me.PanelControl1.TabIndex = 1
        '
        'BRefresh
        '
        Me.BRefresh.Dock = System.Windows.Forms.DockStyle.Right
        Me.BRefresh.Image = CType(resources.GetObject("BRefresh.Image"), System.Drawing.Image)
        Me.BRefresh.Location = New System.Drawing.Point(928, 2)
        Me.BRefresh.Name = "BRefresh"
        Me.BRefresh.Size = New System.Drawing.Size(116, 44)
        Me.BRefresh.TabIndex = 1
        Me.BRefresh.Text = "Refresh"
        '
        'GridColumn48
        '
        Me.GridColumn48.Caption = "Milestone"
        Me.GridColumn48.FieldName = "milestone"
        Me.GridColumn48.Name = "GridColumn48"
        Me.GridColumn48.Visible = True
        Me.GridColumn48.VisibleIndex = 5
        '
        'GridColumn49
        '
        Me.GridColumn49.Caption = "Milestone"
        Me.GridColumn49.FieldName = "milestone"
        Me.GridColumn49.Name = "GridColumn49"
        Me.GridColumn49.Visible = True
        Me.GridColumn49.VisibleIndex = 6
        '
        'FormSOPIndex
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1046, 568)
        Me.ControlBox = False
        Me.Controls.Add(Me.XTCSOPIndex)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSOPIndex"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Index SOP"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.XTCSOPIndex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCSOPIndex.ResumeLayout(False)
        Me.XTPBySOP.ResumeLayout(False)
        CType(Me.GCBySOP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBySOP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoLinkFile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoLinkMenuERP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPByModul.ResumeLayout(False)
        CType(Me.GCByModul, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVByModul, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoFileByModul, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoMenuByModul, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPScheduleSOPAdmin.ResumeLayout(False)
        CType(Me.GCScheduleAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVScheduleAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.XTPScheduleSOPGuest.ResumeLayout(False)
        CType(Me.GCScheduleGuest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVScheduleGuest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPIndexPPS.ResumeLayout(False)
        CType(Me.GCIndexPPS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVIndexPPS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPPengajuanKelengkapan.ResumeLayout(False)
        CType(Me.GCPengajuanKelengkapan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPengajuanKelengkapan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPDepartemenTerkait.ResumeLayout(False)
        CType(Me.GCDepartementTerkait, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDepartementTerkait, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCSOPIndex As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPBySOP As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPByModul As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCBySOP As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBySOP As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BNewSOP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RepoLinkFile As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents RepoLinkMenuERP As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents GCByModul As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVByModul As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoFileByModul As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoMenuByModul As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents XTPScheduleSOPAdmin As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCScheduleAdmin As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVScheduleAdmin As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBAddSchedule As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTPScheduleSOPGuest As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCScheduleGuest As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVScheduleGuest As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BMasterCatSOP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTPIndexPPS As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCIndexPPS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVIndexPPS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SBSetSOP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents SBSetComplete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn34 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn36 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BSOPAsset As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTPPengajuanKelengkapan As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCPengajuanKelengkapan As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPengajuanKelengkapan As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn37 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn38 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn40 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPDepartemenTerkait As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCDepartementTerkait As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDepartementTerkait As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn43 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn44 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn46 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn47 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemHyperLinkEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents RepositoryItemHyperLinkEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents GridColumn48 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn49 As DevExpress.XtraGrid.Columns.GridColumn
End Class
