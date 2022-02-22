<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRiderContract
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
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPKontrak = New DevExpress.XtraTab.XtraTabPage()
        Me.GCContractList = New DevExpress.XtraGrid.GridControl()
        Me.GVContractList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICE = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BChanges = New DevExpress.XtraEditors.SimpleButton()
        Me.BNewExtend = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPPPS = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPPS = New DevExpress.XtraGrid.GridControl()
        Me.GVPPS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BRefreshPPS = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.DEContract = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPKontrak.SuspendLayout()
        CType(Me.GCContractList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVContractList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPPPS.SuspendLayout()
        CType(Me.GCPPS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPPS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEContract.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEContract.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPKontrak
        Me.XtraTabControl1.Size = New System.Drawing.Size(1101, 566)
        Me.XtraTabControl1.TabIndex = 0
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPKontrak, Me.XTPPPS})
        '
        'XTPKontrak
        '
        Me.XTPKontrak.Controls.Add(Me.GCContractList)
        Me.XTPKontrak.Controls.Add(Me.PanelControl1)
        Me.XTPKontrak.Controls.Add(Me.BChanges)
        Me.XTPKontrak.Controls.Add(Me.BNewExtend)
        Me.XTPKontrak.Name = "XTPKontrak"
        Me.XTPKontrak.Size = New System.Drawing.Size(1095, 538)
        Me.XTPKontrak.Text = "Contract List"
        '
        'GCContractList
        '
        Me.GCContractList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCContractList.Location = New System.Drawing.Point(0, 45)
        Me.GCContractList.MainView = Me.GVContractList
        Me.GCContractList.Name = "GCContractList"
        Me.GCContractList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICE})
        Me.GCContractList.Size = New System.Drawing.Size(1095, 425)
        Me.GCContractList.TabIndex = 0
        Me.GCContractList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVContractList})
        '
        'GVContractList
        '
        Me.GVContractList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn13, Me.GridColumn3, Me.GridColumn4, Me.GridColumn9, Me.GridColumn11, Me.GridColumn10, Me.GridColumn12})
        Me.GVContractList.GridControl = Me.GCContractList
        Me.GVContractList.Name = "GVContractList"
        Me.GVContractList.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID Kontrak"
        Me.GridColumn1.FieldName = "id_kontrak_rider"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "ID Comp"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn13
        '
        Me.GridColumn13.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn13.Caption = "*"
        Me.GridColumn13.ColumnEdit = Me.RICE
        Me.GridColumn13.FieldName = "is_check"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 0
        Me.GridColumn13.Width = 54
        '
        'RICE
        '
        Me.RICE.AutoHeight = False
        Me.RICE.Name = "RICE"
        Me.RICE.ValueChecked = "yes"
        Me.RICE.ValueUnchecked = "no"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Endorsee"
        Me.GridColumn3.FieldName = "comp_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 261
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Periode Start"
        Me.GridColumn4.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn4.FieldName = "kontrak_from"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 169
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Periode Until"
        Me.GridColumn9.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn9.FieldName = "kontrak_until"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 3
        Me.GridColumn9.Width = 169
        '
        'GridColumn11
        '
        Me.GridColumn11.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn11.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn11.Caption = "Periode (Month)"
        Me.GridColumn11.FieldName = "qty_month"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 4
        Me.GridColumn11.Width = 261
        '
        'GridColumn10
        '
        Me.GridColumn10.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn10.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn10.Caption = "Monthly Payment"
        Me.GridColumn10.DisplayFormat.FormatString = "N2"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn10.FieldName = "monthly_pay"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 5
        Me.GridColumn10.Width = 261
        '
        'GridColumn12
        '
        Me.GridColumn12.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn12.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn12.Caption = "Total Payment"
        Me.GridColumn12.DisplayFormat.FormatString = "N2"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn12.FieldName = "total"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 6
        Me.GridColumn12.Width = 268
        '
        'BChanges
        '
        Me.BChanges.Appearance.BackColor = System.Drawing.Color.Blue
        Me.BChanges.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BChanges.Appearance.ForeColor = System.Drawing.Color.White
        Me.BChanges.Appearance.Options.UseBackColor = True
        Me.BChanges.Appearance.Options.UseFont = True
        Me.BChanges.Appearance.Options.UseForeColor = True
        Me.BChanges.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BChanges.Location = New System.Drawing.Point(0, 470)
        Me.BChanges.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.BChanges.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BChanges.Name = "BChanges"
        Me.BChanges.Size = New System.Drawing.Size(1095, 34)
        Me.BChanges.TabIndex = 94
        Me.BChanges.Text = "Changes"
        '
        'BNewExtend
        '
        Me.BNewExtend.Appearance.BackColor = System.Drawing.Color.Blue
        Me.BNewExtend.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BNewExtend.Appearance.ForeColor = System.Drawing.Color.White
        Me.BNewExtend.Appearance.Options.UseBackColor = True
        Me.BNewExtend.Appearance.Options.UseFont = True
        Me.BNewExtend.Appearance.Options.UseForeColor = True
        Me.BNewExtend.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BNewExtend.Location = New System.Drawing.Point(0, 504)
        Me.BNewExtend.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.BNewExtend.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BNewExtend.Name = "BNewExtend"
        Me.BNewExtend.Size = New System.Drawing.Size(1095, 34)
        Me.BNewExtend.TabIndex = 93
        Me.BNewExtend.Text = "New / Extend"
        '
        'XTPPPS
        '
        Me.XTPPPS.Controls.Add(Me.GCPPS)
        Me.XTPPPS.Controls.Add(Me.BRefreshPPS)
        Me.XTPPPS.Name = "XTPPPS"
        Me.XTPPPS.Size = New System.Drawing.Size(1095, 538)
        Me.XTPPPS.Text = "Changes Proposal"
        '
        'GCPPS
        '
        Me.GCPPS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPPS.Location = New System.Drawing.Point(0, 0)
        Me.GCPPS.MainView = Me.GVPPS
        Me.GCPPS.Name = "GCPPS"
        Me.GCPPS.Size = New System.Drawing.Size(1095, 504)
        Me.GCPPS.TabIndex = 93
        Me.GCPPS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPPS})
        '
        'GVPPS
        '
        Me.GVPPS.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.GVPPS.GridControl = Me.GCPPS
        Me.GVPPS.Name = "GVPPS"
        Me.GVPPS.OptionsBehavior.Editable = False
        Me.GVPPS.OptionsBehavior.ReadOnly = True
        Me.GVPPS.OptionsView.ShowGroupPanel = False
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "ID Changes"
        Me.GridColumn5.FieldName = "id_kontrak_rider_pps"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Number"
        Me.GridColumn6.FieldName = "number"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Status"
        Me.GridColumn7.FieldName = "report_status"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 1
        '
        'BRefreshPPS
        '
        Me.BRefreshPPS.Appearance.BackColor = System.Drawing.Color.LimeGreen
        Me.BRefreshPPS.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BRefreshPPS.Appearance.ForeColor = System.Drawing.Color.White
        Me.BRefreshPPS.Appearance.Options.UseBackColor = True
        Me.BRefreshPPS.Appearance.Options.UseFont = True
        Me.BRefreshPPS.Appearance.Options.UseForeColor = True
        Me.BRefreshPPS.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BRefreshPPS.Location = New System.Drawing.Point(0, 504)
        Me.BRefreshPPS.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.BRefreshPPS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BRefreshPPS.Name = "BRefreshPPS"
        Me.BRefreshPPS.Size = New System.Drawing.Size(1095, 34)
        Me.BRefreshPPS.TabIndex = 94
        Me.BRefreshPPS.Text = "Refresh"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BView)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.DEContract)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1095, 45)
        Me.PanelControl1.TabIndex = 95
        '
        'DEContract
        '
        Me.DEContract.EditValue = Nothing
        Me.DEContract.Location = New System.Drawing.Point(78, 11)
        Me.DEContract.Name = "DEContract"
        Me.DEContract.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEContract.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEContract.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEContract.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEContract.Size = New System.Drawing.Size(232, 20)
        Me.DEContract.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(11, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Contract Per"
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(316, 9)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(58, 23)
        Me.BView.TabIndex = 2
        Me.BView.Text = "view"
        '
        'FormRiderContract
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1101, 566)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormRiderContract"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Endorsee Contract"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPKontrak.ResumeLayout(False)
        CType(Me.GCContractList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVContractList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPPPS.ResumeLayout(False)
        CType(Me.GCPPS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPPS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DEContract.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEContract.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPKontrak As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPPPS As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCContractList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVContractList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BNewExtend As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCPPS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPPS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICE As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents BRefreshPPS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BChanges As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEContract As DevExpress.XtraEditors.DateEdit
End Class
