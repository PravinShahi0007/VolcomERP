<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterStoreFaktur
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterStoreFaktur))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnExport = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnImportXLS = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnstore_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnama_npwp_kantor_pusat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnpwp_kantor_pusat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnakun_toko = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnama_toko = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnaddress_efaktur = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnExport)
        Me.PanelControl1.Controls.Add(Me.BtnImportXLS)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(665, 53)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnExport
        '
        Me.BtnExport.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnExport.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExport.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnExport.Appearance.Image = CType(resources.GetObject("SimpleButton1.Appearance.Image"), System.Drawing.Image)
        Me.BtnExport.Appearance.Options.UseBackColor = True
        Me.BtnExport.Appearance.Options.UseFont = True
        Me.BtnExport.Appearance.Options.UseForeColor = True
        Me.BtnExport.Appearance.Options.UseImage = True
        Me.BtnExport.Location = New System.Drawing.Point(154, 12)
        Me.BtnExport.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnExport.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnExport.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnExport.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(113, 29)
        Me.BtnExport.TabIndex = 24
        Me.BtnExport.Text = "Export to XLS"
        '
        'BtnImportXLS
        '
        Me.BtnImportXLS.Appearance.BackColor = System.Drawing.Color.Gray
        Me.BtnImportXLS.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImportXLS.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnImportXLS.Appearance.Image = CType(resources.GetObject("BtnImportXLS.Appearance.Image"), System.Drawing.Image)
        Me.BtnImportXLS.Appearance.Options.UseBackColor = True
        Me.BtnImportXLS.Appearance.Options.UseFont = True
        Me.BtnImportXLS.Appearance.Options.UseForeColor = True
        Me.BtnImportXLS.Appearance.Options.UseImage = True
        Me.BtnImportXLS.Location = New System.Drawing.Point(12, 12)
        Me.BtnImportXLS.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnImportXLS.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnImportXLS.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnImportXLS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnImportXLS.Name = "BtnImportXLS"
        Me.BtnImportXLS.Size = New System.Drawing.Size(138, 29)
        Me.BtnImportXLS.TabIndex = 23
        Me.BtnImportXLS.Text = "+ Import from XLS"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 53)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(665, 382)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnstore_group, Me.GridColumnnama_npwp_kantor_pusat, Me.GridColumnnpwp_kantor_pusat, Me.GridColumnakun_toko, Me.GridColumnnama_toko, Me.GridColumnaddress_efaktur})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnstore_group
        '
        Me.GridColumnstore_group.Caption = "Store Group"
        Me.GridColumnstore_group.FieldName = "store_group"
        Me.GridColumnstore_group.Name = "GridColumnstore_group"
        Me.GridColumnstore_group.Visible = True
        Me.GridColumnstore_group.VisibleIndex = 0
        '
        'GridColumnnama_npwp_kantor_pusat
        '
        Me.GridColumnnama_npwp_kantor_pusat.Caption = "Nama NPWP"
        Me.GridColumnnama_npwp_kantor_pusat.FieldName = "nama_npwp_kantor_pusat"
        Me.GridColumnnama_npwp_kantor_pusat.Name = "GridColumnnama_npwp_kantor_pusat"
        Me.GridColumnnama_npwp_kantor_pusat.Visible = True
        Me.GridColumnnama_npwp_kantor_pusat.VisibleIndex = 1
        '
        'GridColumnnpwp_kantor_pusat
        '
        Me.GridColumnnpwp_kantor_pusat.Caption = "NPWP"
        Me.GridColumnnpwp_kantor_pusat.FieldName = "npwp_kantor_pusat"
        Me.GridColumnnpwp_kantor_pusat.Name = "GridColumnnpwp_kantor_pusat"
        Me.GridColumnnpwp_kantor_pusat.Visible = True
        Me.GridColumnnpwp_kantor_pusat.VisibleIndex = 2
        '
        'GridColumnakun_toko
        '
        Me.GridColumnakun_toko.Caption = "Akun Toko"
        Me.GridColumnakun_toko.FieldName = "akun_toko"
        Me.GridColumnakun_toko.Name = "GridColumnakun_toko"
        Me.GridColumnakun_toko.Visible = True
        Me.GridColumnakun_toko.VisibleIndex = 3
        '
        'GridColumnnama_toko
        '
        Me.GridColumnnama_toko.Caption = "Toko"
        Me.GridColumnnama_toko.FieldName = "nama_toko"
        Me.GridColumnnama_toko.Name = "GridColumnnama_toko"
        Me.GridColumnnama_toko.Visible = True
        Me.GridColumnnama_toko.VisibleIndex = 4
        '
        'GridColumnaddress_efaktur
        '
        Me.GridColumnaddress_efaktur.Caption = "Alamat E-Faktur"
        Me.GridColumnaddress_efaktur.FieldName = "address_efaktur"
        Me.GridColumnaddress_efaktur.Name = "GridColumnaddress_efaktur"
        Me.GridColumnaddress_efaktur.Visible = True
        Me.GridColumnaddress_efaktur.VisibleIndex = 5
        '
        'FormMasterStoreFaktur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 435)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormMasterStoreFaktur"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Store E-Faktur"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnImportXLS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnstore_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnama_npwp_kantor_pusat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnpwp_kantor_pusat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnakun_toko As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnama_toko As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnaddress_efaktur As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnExport As DevExpress.XtraEditors.SimpleButton
End Class
