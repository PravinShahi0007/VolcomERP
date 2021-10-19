<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPolisRegPick
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
        Me.BRefreshPenawaran = New DevExpress.XtraEditors.SimpleButton()
        Me.BPick = New DevExpress.XtraEditors.SimpleButton()
        Me.GCPolisPPS = New DevExpress.XtraGrid.GridControl()
        Me.GVPolisPPS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPPSKolektif = New DevExpress.XtraGrid.GridControl()
        Me.GVPPSKolektif = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SLEPenawaran = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn40 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LDateFrom = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TENomorPolis = New DevExpress.XtraEditors.TextEdit()
        CType(Me.GCPolisPPS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPolisPPS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.GCPPSKolektif, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPPSKolektif, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEPenawaran.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TENomorPolis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BRefreshPenawaran
        '
        Me.BRefreshPenawaran.Appearance.BackColor = System.Drawing.Color.LightSeaGreen
        Me.BRefreshPenawaran.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BRefreshPenawaran.Appearance.ForeColor = System.Drawing.Color.White
        Me.BRefreshPenawaran.Appearance.Options.UseBackColor = True
        Me.BRefreshPenawaran.Appearance.Options.UseFont = True
        Me.BRefreshPenawaran.Appearance.Options.UseForeColor = True
        Me.BRefreshPenawaran.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BRefreshPenawaran.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BRefreshPenawaran.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BRefreshPenawaran.Location = New System.Drawing.Point(0, 324)
        Me.BRefreshPenawaran.LookAndFeel.SkinName = "Metropolis"
        Me.BRefreshPenawaran.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BRefreshPenawaran.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BRefreshPenawaran.Name = "BRefreshPenawaran"
        Me.BRefreshPenawaran.Size = New System.Drawing.Size(760, 32)
        Me.BRefreshPenawaran.TabIndex = 144
        Me.BRefreshPenawaran.Text = "Refresh"
        '
        'BPick
        '
        Me.BPick.Appearance.BackColor = System.Drawing.Color.DarkBlue
        Me.BPick.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BPick.Appearance.ForeColor = System.Drawing.Color.White
        Me.BPick.Appearance.Options.UseBackColor = True
        Me.BPick.Appearance.Options.UseFont = True
        Me.BPick.Appearance.Options.UseForeColor = True
        Me.BPick.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BPick.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BPick.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BPick.Location = New System.Drawing.Point(0, 356)
        Me.BPick.LookAndFeel.SkinName = "Metropolis"
        Me.BPick.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BPick.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BPick.Name = "BPick"
        Me.BPick.Size = New System.Drawing.Size(760, 32)
        Me.BPick.TabIndex = 145
        Me.BPick.Text = "Pick"
        '
        'GCPolisPPS
        '
        Me.GCPolisPPS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPolisPPS.Location = New System.Drawing.Point(0, 0)
        Me.GCPolisPPS.MainView = Me.GVPolisPPS
        Me.GCPolisPPS.Name = "GCPolisPPS"
        Me.GCPolisPPS.Size = New System.Drawing.Size(754, 296)
        Me.GCPolisPPS.TabIndex = 146
        Me.GCPolisPPS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPolisPPS})
        '
        'GVPolisPPS
        '
        Me.GVPolisPPS.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn12, Me.GridColumn13, Me.GridColumn2, Me.GridColumn1, Me.GridColumn15})
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
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Created By"
        Me.GridColumn2.FieldName = "employee_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Created Date"
        Me.GridColumn1.FieldName = "created_date"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Report Status"
        Me.GridColumn15.FieldName = "report_status"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 3
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(760, 324)
        Me.XtraTabControl1.TabIndex = 147
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.GCPolisPPS)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(754, 296)
        Me.XtraTabPage1.Text = "Mandiri"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.GCPPSKolektif)
        Me.XtraTabPage2.Controls.Add(Me.PanelControl1)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(754, 296)
        Me.XtraTabPage2.Text = "Kolektif"
        '
        'GCPPSKolektif
        '
        Me.GCPPSKolektif.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPPSKolektif.Location = New System.Drawing.Point(0, 0)
        Me.GCPPSKolektif.MainView = Me.GVPPSKolektif
        Me.GCPPSKolektif.Name = "GCPPSKolektif"
        Me.GCPPSKolektif.Size = New System.Drawing.Size(754, 227)
        Me.GCPPSKolektif.TabIndex = 147
        Me.GCPPSKolektif.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPPSKolektif})
        '
        'GVPPSKolektif
        '
        Me.GVPPSKolektif.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.GVPPSKolektif.GridControl = Me.GCPPSKolektif
        Me.GVPPSKolektif.Name = "GVPPSKolektif"
        Me.GVPPSKolektif.OptionsBehavior.Editable = False
        Me.GVPPSKolektif.OptionsBehavior.ReadOnly = True
        Me.GVPPSKolektif.OptionsView.ShowGroupPanel = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "ID"
        Me.GridColumn3.FieldName = "id_polis_pps"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Number"
        Me.GridColumn4.FieldName = "number"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Created By"
        Me.GridColumn5.FieldName = "employee_name"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 1
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Created Date"
        Me.GridColumn6.FieldName = "created_date"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Report Status"
        Me.GridColumn7.FieldName = "report_status"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 3
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.TENomorPolis)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.LDateFrom)
        Me.PanelControl1.Controls.Add(Me.SLEPenawaran)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 227)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(754, 69)
        Me.PanelControl1.TabIndex = 148
        '
        'SLEPenawaran
        '
        Me.SLEPenawaran.EditValue = ""
        Me.SLEPenawaran.Location = New System.Drawing.Point(85, 10)
        Me.SLEPenawaran.Name = "SLEPenawaran"
        Me.SLEPenawaran.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEPenawaran.Properties.NullText = ""
        Me.SLEPenawaran.Properties.View = Me.GridView1
        Me.SLEPenawaran.Size = New System.Drawing.Size(321, 20)
        Me.SLEPenawaran.TabIndex = 2
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn40, Me.GridColumn41, Me.GridColumn42})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn40
        '
        Me.GridColumn40.Caption = "ID"
        Me.GridColumn40.FieldName = "id_comp"
        Me.GridColumn40.Name = "GridColumn40"
        '
        'GridColumn41
        '
        Me.GridColumn41.Caption = "Kode"
        Me.GridColumn41.FieldName = "comp_number"
        Me.GridColumn41.Name = "GridColumn41"
        Me.GridColumn41.Visible = True
        Me.GridColumn41.VisibleIndex = 0
        '
        'GridColumn42
        '
        Me.GridColumn42.Caption = "Vendor"
        Me.GridColumn42.FieldName = "comp_name"
        Me.GridColumn42.Name = "GridColumn42"
        Me.GridColumn42.Visible = True
        Me.GridColumn42.VisibleIndex = 1
        '
        'LDateFrom
        '
        Me.LDateFrom.Location = New System.Drawing.Point(11, 13)
        Me.LDateFrom.Name = "LDateFrom"
        Me.LDateFrom.Size = New System.Drawing.Size(64, 13)
        Me.LDateFrom.TabIndex = 181
        Me.LDateFrom.Text = "Vendor Dipilih"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(11, 41)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl1.TabIndex = 182
        Me.LabelControl1.Text = "Nomor Polis"
        '
        'TENomorPolis
        '
        Me.TENomorPolis.Location = New System.Drawing.Point(85, 38)
        Me.TENomorPolis.Name = "TENomorPolis"
        Me.TENomorPolis.Size = New System.Drawing.Size(437, 20)
        Me.TENomorPolis.TabIndex = 183
        '
        'FormPolisRegPick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 388)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.BRefreshPenawaran)
        Me.Controls.Add(Me.BPick)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPolisRegPick"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Proposal Number"
        CType(Me.GCPolisPPS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPolisPPS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.GCPPSKolektif, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPPSKolektif, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEPenawaran.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TENomorPolis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BRefreshPenawaran As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPick As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCPolisPPS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPolisPPS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCPPSKolektif As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPPSKolektif As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLEPenawaran As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn40 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TENomorPolis As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LDateFrom As DevExpress.XtraEditors.LabelControl
End Class
