<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSOPCat
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
        Me.XTCCat = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPProsedur = New DevExpress.XtraTab.XtraTabPage()
        Me.GCProsedur = New DevExpress.XtraGrid.GridControl()
        Me.GVProsedur = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PCAddMasterProsedur = New DevExpress.XtraEditors.PanelControl()
        Me.BAddProsedur = New DevExpress.XtraEditors.SimpleButton()
        Me.TEProsedur = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TEKodeProsedur = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.Bview = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEDepartement = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPSubProsedur = New DevExpress.XtraTab.XtraTabPage()
        Me.GCSubProsedur = New DevExpress.XtraGrid.GridControl()
        Me.GVSubProsedur = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BRefresSubSOP = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BAddSubProsedur = New DevExpress.XtraEditors.SimpleButton()
        Me.TESKodeProsedur = New DevExpress.XtraEditors.TextEdit()
        Me.TESub = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TEKodeSub = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TESProsedur = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.XTCCat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCCat.SuspendLayout()
        Me.XTPProsedur.SuspendLayout()
        CType(Me.GCProsedur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProsedur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCAddMasterProsedur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCAddMasterProsedur.SuspendLayout()
        CType(Me.TEProsedur.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEKodeProsedur.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEDepartement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPSubProsedur.SuspendLayout()
        CType(Me.GCSubProsedur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSubProsedur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.TESKodeProsedur.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TESub.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEKodeSub.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TESProsedur.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCCat
        '
        Me.XTCCat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCCat.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCCat.Location = New System.Drawing.Point(0, 0)
        Me.XTCCat.Name = "XTCCat"
        Me.XTCCat.SelectedTabPage = Me.XTPProsedur
        Me.XTCCat.Size = New System.Drawing.Size(1054, 519)
        Me.XTCCat.TabIndex = 0
        Me.XTCCat.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPProsedur, Me.XTPSubProsedur})
        '
        'XTPProsedur
        '
        Me.XTPProsedur.Controls.Add(Me.GCProsedur)
        Me.XTPProsedur.Controls.Add(Me.PCAddMasterProsedur)
        Me.XTPProsedur.Controls.Add(Me.PanelControl1)
        Me.XTPProsedur.Name = "XTPProsedur"
        Me.XTPProsedur.Size = New System.Drawing.Size(1048, 491)
        Me.XTPProsedur.Text = "Master Prosedur"
        '
        'GCProsedur
        '
        Me.GCProsedur.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProsedur.Location = New System.Drawing.Point(0, 52)
        Me.GCProsedur.MainView = Me.GVProsedur
        Me.GCProsedur.Name = "GCProsedur"
        Me.GCProsedur.Size = New System.Drawing.Size(1048, 338)
        Me.GCProsedur.TabIndex = 1
        Me.GCProsedur.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProsedur})
        '
        'GVProsedur
        '
        Me.GVProsedur.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn6, Me.GridColumn3})
        Me.GVProsedur.GridControl = Me.GCProsedur
        Me.GVProsedur.Name = "GVProsedur"
        Me.GVProsedur.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_sop_prosedur"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Nama Prosedur"
        Me.GridColumn2.FieldName = "sop_prosedur"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 1130
        '
        'GridColumn6
        '
        Me.GridColumn6.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn6.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn6.Caption = "Kode Prosedur"
        Me.GridColumn6.FieldName = "sop_prosedur_code"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        Me.GridColumn6.Width = 249
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.Caption = "Status"
        Me.GridColumn3.FieldName = "sts"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 253
        '
        'PCAddMasterProsedur
        '
        Me.PCAddMasterProsedur.Controls.Add(Me.BAddProsedur)
        Me.PCAddMasterProsedur.Controls.Add(Me.TEProsedur)
        Me.PCAddMasterProsedur.Controls.Add(Me.LabelControl6)
        Me.PCAddMasterProsedur.Controls.Add(Me.TEKodeProsedur)
        Me.PCAddMasterProsedur.Controls.Add(Me.LabelControl7)
        Me.PCAddMasterProsedur.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCAddMasterProsedur.Location = New System.Drawing.Point(0, 390)
        Me.PCAddMasterProsedur.Name = "PCAddMasterProsedur"
        Me.PCAddMasterProsedur.Size = New System.Drawing.Size(1048, 101)
        Me.PCAddMasterProsedur.TabIndex = 12
        Me.PCAddMasterProsedur.Visible = False
        '
        'BAddProsedur
        '
        Me.BAddProsedur.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.BAddProsedur.Appearance.ForeColor = System.Drawing.Color.White
        Me.BAddProsedur.Appearance.Options.UseBackColor = True
        Me.BAddProsedur.Appearance.Options.UseForeColor = True
        Me.BAddProsedur.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BAddProsedur.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BAddProsedur.Location = New System.Drawing.Point(2, 65)
        Me.BAddProsedur.Name = "BAddProsedur"
        Me.BAddProsedur.Size = New System.Drawing.Size(1044, 34)
        Me.BAddProsedur.TabIndex = 11
        Me.BAddProsedur.Text = "Add Prosedur"
        '
        'TEProsedur
        '
        Me.TEProsedur.Location = New System.Drawing.Point(110, 38)
        Me.TEProsedur.Name = "TEProsedur"
        Me.TEProsedur.Size = New System.Drawing.Size(385, 20)
        Me.TEProsedur.TabIndex = 5
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(13, 41)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl6.TabIndex = 4
        Me.LabelControl6.Text = "Prosedur"
        '
        'TEKodeProsedur
        '
        Me.TEKodeProsedur.Location = New System.Drawing.Point(110, 12)
        Me.TEKodeProsedur.Name = "TEKodeProsedur"
        Me.TEKodeProsedur.Size = New System.Drawing.Size(184, 20)
        Me.TEKodeProsedur.TabIndex = 3
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(13, 15)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl7.TabIndex = 2
        Me.LabelControl7.Text = "Kode Prosedur"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.Bview)
        Me.PanelControl1.Controls.Add(Me.SLEDepartement)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1048, 52)
        Me.PanelControl1.TabIndex = 0
        '
        'Bview
        '
        Me.Bview.Location = New System.Drawing.Point(376, 14)
        Me.Bview.Name = "Bview"
        Me.Bview.Size = New System.Drawing.Size(50, 23)
        Me.Bview.TabIndex = 18
        Me.Bview.Text = "view"
        '
        'SLEDepartement
        '
        Me.SLEDepartement.Location = New System.Drawing.Point(80, 16)
        Me.SLEDepartement.Name = "SLEDepartement"
        Me.SLEDepartement.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEDepartement.Properties.View = Me.GridView2
        Me.SLEDepartement.Size = New System.Drawing.Size(290, 20)
        Me.SLEDepartement.TabIndex = 17
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn4, Me.GridColumn5})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "ID"
        Me.GridColumn4.FieldName = "id_departement"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Departement"
        Me.GridColumn5.FieldName = "departement"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(11, 19)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Departement"
        '
        'XTPSubProsedur
        '
        Me.XTPSubProsedur.Controls.Add(Me.GCSubProsedur)
        Me.XTPSubProsedur.Controls.Add(Me.BRefresSubSOP)
        Me.XTPSubProsedur.Controls.Add(Me.PanelControl3)
        Me.XTPSubProsedur.Name = "XTPSubProsedur"
        Me.XTPSubProsedur.PageVisible = False
        Me.XTPSubProsedur.Size = New System.Drawing.Size(1048, 491)
        Me.XTPSubProsedur.Text = "Master Sub Prosedur"
        '
        'GCSubProsedur
        '
        Me.GCSubProsedur.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSubProsedur.Location = New System.Drawing.Point(0, 0)
        Me.GCSubProsedur.MainView = Me.GVSubProsedur
        Me.GCSubProsedur.Name = "GCSubProsedur"
        Me.GCSubProsedur.Size = New System.Drawing.Size(1048, 318)
        Me.GCSubProsedur.TabIndex = 2
        Me.GCSubProsedur.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSubProsedur})
        '
        'GVSubProsedur
        '
        Me.GVSubProsedur.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12})
        Me.GVSubProsedur.GridControl = Me.GCSubProsedur
        Me.GVSubProsedur.Name = "GVSubProsedur"
        Me.GVSubProsedur.OptionsView.ShowGroupPanel = False
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "ID"
        Me.GridColumn9.FieldName = "id_sop_prosedur"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Nama Sub Prosedur"
        Me.GridColumn10.FieldName = "sop_prosedur_sub"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        Me.GridColumn10.Width = 1130
        '
        'GridColumn11
        '
        Me.GridColumn11.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn11.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn11.Caption = "Kode Sub Prosedur"
        Me.GridColumn11.FieldName = "sop_prosedur_sub_code"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 1
        Me.GridColumn11.Width = 249
        '
        'GridColumn12
        '
        Me.GridColumn12.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn12.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn12.Caption = "Status"
        Me.GridColumn12.FieldName = "sts"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 2
        Me.GridColumn12.Width = 253
        '
        'BRefresSubSOP
        '
        Me.BRefresSubSOP.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BRefresSubSOP.Appearance.ForeColor = System.Drawing.Color.White
        Me.BRefresSubSOP.Appearance.Options.UseBackColor = True
        Me.BRefresSubSOP.Appearance.Options.UseForeColor = True
        Me.BRefresSubSOP.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BRefresSubSOP.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BRefresSubSOP.Location = New System.Drawing.Point(0, 318)
        Me.BRefresSubSOP.Name = "BRefresSubSOP"
        Me.BRefresSubSOP.Size = New System.Drawing.Size(1048, 40)
        Me.BRefresSubSOP.TabIndex = 9
        Me.BRefresSubSOP.Text = "Refresh"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BAddSubProsedur)
        Me.PanelControl3.Controls.Add(Me.TESKodeProsedur)
        Me.PanelControl3.Controls.Add(Me.TESub)
        Me.PanelControl3.Controls.Add(Me.LabelControl5)
        Me.PanelControl3.Controls.Add(Me.TEKodeSub)
        Me.PanelControl3.Controls.Add(Me.LabelControl4)
        Me.PanelControl3.Controls.Add(Me.TESProsedur)
        Me.PanelControl3.Controls.Add(Me.LabelControl3)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 358)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(1048, 133)
        Me.PanelControl3.TabIndex = 2
        '
        'BAddSubProsedur
        '
        Me.BAddSubProsedur.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.BAddSubProsedur.Appearance.ForeColor = System.Drawing.Color.White
        Me.BAddSubProsedur.Appearance.Options.UseBackColor = True
        Me.BAddSubProsedur.Appearance.Options.UseForeColor = True
        Me.BAddSubProsedur.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BAddSubProsedur.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BAddSubProsedur.Location = New System.Drawing.Point(2, 96)
        Me.BAddSubProsedur.Name = "BAddSubProsedur"
        Me.BAddSubProsedur.Size = New System.Drawing.Size(1044, 35)
        Me.BAddSubProsedur.TabIndex = 10
        Me.BAddSubProsedur.Text = "Add Sub Prosedur"
        '
        'TESKodeProsedur
        '
        Me.TESKodeProsedur.Location = New System.Drawing.Point(108, 13)
        Me.TESKodeProsedur.Name = "TESKodeProsedur"
        Me.TESKodeProsedur.Properties.ReadOnly = True
        Me.TESKodeProsedur.Size = New System.Drawing.Size(92, 20)
        Me.TESKodeProsedur.TabIndex = 6
        '
        'TESub
        '
        Me.TESub.Location = New System.Drawing.Point(108, 67)
        Me.TESub.Name = "TESub"
        Me.TESub.Size = New System.Drawing.Size(385, 20)
        Me.TESub.TabIndex = 5
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(11, 70)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(64, 13)
        Me.LabelControl5.TabIndex = 4
        Me.LabelControl5.Text = "Sub Prosedur"
        '
        'TEKodeSub
        '
        Me.TEKodeSub.Location = New System.Drawing.Point(108, 41)
        Me.TEKodeSub.Name = "TEKodeSub"
        Me.TEKodeSub.Size = New System.Drawing.Size(184, 20)
        Me.TEKodeSub.TabIndex = 3
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(11, 44)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(91, 13)
        Me.LabelControl4.TabIndex = 2
        Me.LabelControl4.Text = "Kode Sub Prosedur"
        '
        'TESProsedur
        '
        Me.TESProsedur.Location = New System.Drawing.Point(206, 13)
        Me.TESProsedur.Name = "TESProsedur"
        Me.TESProsedur.Properties.ReadOnly = True
        Me.TESProsedur.Size = New System.Drawing.Size(287, 20)
        Me.TESProsedur.TabIndex = 1
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(11, 16)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl3.TabIndex = 0
        Me.LabelControl3.Text = "Prosedur"
        '
        'FormSOPCat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 519)
        Me.Controls.Add(Me.XTCCat)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormSOPCat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SOP Data Master Prosedur - Sub Prosedur"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.XTCCat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCCat.ResumeLayout(False)
        Me.XTPProsedur.ResumeLayout(False)
        CType(Me.GCProsedur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProsedur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCAddMasterProsedur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCAddMasterProsedur.ResumeLayout(False)
        Me.PCAddMasterProsedur.PerformLayout()
        CType(Me.TEProsedur.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEKodeProsedur.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEDepartement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPSubProsedur.ResumeLayout(False)
        CType(Me.GCSubProsedur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSubProsedur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.TESKodeProsedur.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TESub.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEKodeSub.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TESProsedur.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCCat As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPProsedur As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCProsedur As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProsedur As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents XTPSubProsedur As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Bview As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEDepartement As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCSubProsedur As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSubProsedur As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BRefresSubSOP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PCAddMasterProsedur As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEProsedur As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEKodeProsedur As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BAddProsedur As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BAddSubProsedur As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TESKodeProsedur As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TESub As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEKodeSub As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TESProsedur As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
End Class
