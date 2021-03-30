<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormOutboundList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOutboundList))
        Me.XTCOutbound = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPending = New DevExpress.XtraTab.XtraTabPage()
        Me.GCOutbound = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelOutboundLabelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelOutboundLabelToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVOutbound = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BCheckFisik = New DevExpress.XtraEditors.SimpleButton()
        Me.BRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BOutboundLabel = New DevExpress.XtraEditors.SimpleButton()
        Me.TEOutboundNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPHistory = New DevExpress.XtraTab.XtraTabPage()
        Me.GCHistory = New DevExpress.XtraGrid.GridControl()
        Me.GVHistory = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BRefreshHistory = New DevExpress.XtraEditors.SimpleButton()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.DETo = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        CType(Me.XTCOutbound, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCOutbound.SuspendLayout()
        Me.XTPPending.SuspendLayout()
        CType(Me.GCOutbound, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GVOutbound, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TEOutboundNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPHistory.SuspendLayout()
        CType(Me.GCHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.DETo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DETo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCOutbound
        '
        Me.XTCOutbound.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCOutbound.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCOutbound.Location = New System.Drawing.Point(0, 0)
        Me.XTCOutbound.Name = "XTCOutbound"
        Me.XTCOutbound.SelectedTabPage = Me.XTPPending
        Me.XTCOutbound.Size = New System.Drawing.Size(916, 522)
        Me.XTCOutbound.TabIndex = 0
        Me.XTCOutbound.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPending, Me.XTPHistory})
        '
        'XTPPending
        '
        Me.XTPPending.Controls.Add(Me.GCOutbound)
        Me.XTPPending.Controls.Add(Me.BCheckFisik)
        Me.XTPPending.Controls.Add(Me.BRefresh)
        Me.XTPPending.Controls.Add(Me.PanelControl1)
        Me.XTPPending.Name = "XTPPending"
        Me.XTPPending.Size = New System.Drawing.Size(910, 494)
        Me.XTPPending.Text = "Pending Outbound"
        '
        'GCOutbound
        '
        Me.GCOutbound.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCOutbound.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOutbound.Location = New System.Drawing.Point(0, 46)
        Me.GCOutbound.MainView = Me.GVOutbound
        Me.GCOutbound.Name = "GCOutbound"
        Me.GCOutbound.Size = New System.Drawing.Size(910, 382)
        Me.GCOutbound.TabIndex = 1
        Me.GCOutbound.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOutbound})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDocumentToolStripMenuItem, Me.CancelOutboundLabelToolStripMenuItem, Me.CancelOutboundLabelToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(200, 70)
        '
        'ViewDocumentToolStripMenuItem
        '
        Me.ViewDocumentToolStripMenuItem.Name = "ViewDocumentToolStripMenuItem"
        Me.ViewDocumentToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ViewDocumentToolStripMenuItem.Text = "Print"
        '
        'CancelOutboundLabelToolStripMenuItem
        '
        Me.CancelOutboundLabelToolStripMenuItem.Name = "CancelOutboundLabelToolStripMenuItem"
        Me.CancelOutboundLabelToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.CancelOutboundLabelToolStripMenuItem.Text = "Cancel SDO"
        '
        'CancelOutboundLabelToolStripMenuItem1
        '
        Me.CancelOutboundLabelToolStripMenuItem1.Name = "CancelOutboundLabelToolStripMenuItem1"
        Me.CancelOutboundLabelToolStripMenuItem1.Size = New System.Drawing.Size(199, 22)
        Me.CancelOutboundLabelToolStripMenuItem1.Text = "Cancel Outbound Label"
        '
        'GVOutbound
        '
        Me.GVOutbound.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn20, Me.GridColumn2, Me.GridColumn4, Me.GridColumn6, Me.GridColumn18, Me.GridColumn5, Me.GridColumn3, Me.GridColumn23})
        Me.GVOutbound.GridControl = Me.GCOutbound
        Me.GVOutbound.Name = "GVOutbound"
        Me.GVOutbound.OptionsBehavior.Editable = False
        Me.GVOutbound.OptionsBehavior.ReadOnly = True
        Me.GVOutbound.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Outbound Number"
        Me.GridColumn1.FieldName = "ol_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        Me.GridColumn1.Width = 98
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Code"
        Me.GridColumn20.FieldName = "comp_number"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Store"
        Me.GridColumn2.FieldName = "comp_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 257
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Sub District"
        Me.GridColumn4.FieldName = "sub_district"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 327
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Delivery Number"
        Me.GridColumn6.FieldName = "sdo_number"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Combine Number"
        Me.GridColumn18.FieldName = "combine_number"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 4
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Online Order Number"
        Me.GridColumn5.FieldName = "online_order_number"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 6
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.Caption = "Qty"
        Me.GridColumn3.FieldName = "qty"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 7
        Me.GridColumn3.Width = 132
        '
        'GridColumn23
        '
        Me.GridColumn23.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn23.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn23.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn23.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn23.Caption = "Satus Cek Fisik"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 8
        '
        'BCheckFisik
        '
        Me.BCheckFisik.Appearance.BackColor = System.Drawing.Color.Blue
        Me.BCheckFisik.Appearance.BackColor2 = System.Drawing.Color.Blue
        Me.BCheckFisik.Appearance.ForeColor = System.Drawing.Color.White
        Me.BCheckFisik.Appearance.Options.UseBackColor = True
        Me.BCheckFisik.Appearance.Options.UseForeColor = True
        Me.BCheckFisik.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BCheckFisik.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BCheckFisik.Location = New System.Drawing.Point(0, 428)
        Me.BCheckFisik.Name = "BCheckFisik"
        Me.BCheckFisik.Size = New System.Drawing.Size(910, 33)
        Me.BCheckFisik.TabIndex = 3
        Me.BCheckFisik.Text = "Proses Cek Fisik"
        '
        'BRefresh
        '
        Me.BRefresh.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BRefresh.Location = New System.Drawing.Point(0, 461)
        Me.BRefresh.Name = "BRefresh"
        Me.BRefresh.Size = New System.Drawing.Size(910, 33)
        Me.BRefresh.TabIndex = 2
        Me.BRefresh.Text = "Refresh"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BOutboundLabel)
        Me.PanelControl1.Controls.Add(Me.TEOutboundNumber)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(910, 46)
        Me.PanelControl1.TabIndex = 0
        '
        'BOutboundLabel
        '
        Me.BOutboundLabel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BOutboundLabel.Image = CType(resources.GetObject("BOutboundLabel.Image"), System.Drawing.Image)
        Me.BOutboundLabel.Location = New System.Drawing.Point(767, 2)
        Me.BOutboundLabel.LookAndFeel.SkinName = "Blue"
        Me.BOutboundLabel.Name = "BOutboundLabel"
        Me.BOutboundLabel.Size = New System.Drawing.Size(141, 42)
        Me.BOutboundLabel.TabIndex = 8900
        Me.BOutboundLabel.Text = "Outbound Label"
        '
        'TEOutboundNumber
        '
        Me.TEOutboundNumber.Location = New System.Drawing.Point(150, 9)
        Me.TEOutboundNumber.Name = "TEOutboundNumber"
        Me.TEOutboundNumber.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TEOutboundNumber.Properties.Appearance.Options.UseFont = True
        Me.TEOutboundNumber.Size = New System.Drawing.Size(334, 28)
        Me.TEOutboundNumber.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.LabelControl1.Location = New System.Drawing.Point(11, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(133, 21)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Outbound Number"
        '
        'XTPHistory
        '
        Me.XTPHistory.Controls.Add(Me.GCHistory)
        Me.XTPHistory.Controls.Add(Me.PanelControl2)
        Me.XTPHistory.Name = "XTPHistory"
        Me.XTPHistory.Size = New System.Drawing.Size(910, 494)
        Me.XTPHistory.Text = "History"
        '
        'GCHistory
        '
        Me.GCHistory.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCHistory.Location = New System.Drawing.Point(0, 46)
        Me.GCHistory.MainView = Me.GVHistory
        Me.GCHistory.Name = "GCHistory"
        Me.GCHistory.Size = New System.Drawing.Size(910, 448)
        Me.GCHistory.TabIndex = 2
        Me.GCHistory.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVHistory})
        '
        'GVHistory
        '
        Me.GVHistory.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn7, Me.GridColumn21, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn19, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn22, Me.GridColumn17, Me.GridColumn15, Me.GridColumn16})
        Me.GVHistory.GridControl = Me.GCHistory
        Me.GVHistory.Name = "GVHistory"
        Me.GVHistory.OptionsBehavior.Editable = False
        Me.GVHistory.OptionsBehavior.ReadOnly = True
        Me.GVHistory.OptionsView.ShowGroupPanel = False
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Outbound Number"
        Me.GridColumn7.FieldName = "ol_number"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 2
        Me.GridColumn7.Width = 98
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Code"
        Me.GridColumn21.FieldName = "comp_number"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 1
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Store"
        Me.GridColumn8.FieldName = "comp_name"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 0
        Me.GridColumn8.Width = 257
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Sub District"
        Me.GridColumn9.FieldName = "sub_district"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 3
        Me.GridColumn9.Width = 327
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Delivery Number"
        Me.GridColumn10.FieldName = "sdo_number"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 5
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Combine number"
        Me.GridColumn19.FieldName = "combine_number"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 4
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Online Order Number"
        Me.GridColumn11.FieldName = "online_order_number"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 6
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Qty"
        Me.GridColumn12.FieldName = "qty"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 7
        Me.GridColumn12.Width = 132
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Status"
        Me.GridColumn13.FieldName = "report_status"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 8
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Draft Manifest"
        Me.GridColumn14.FieldName = "draft_manifest"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 9
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "3PL"
        Me.GridColumn22.FieldName = "cargo"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 10
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "AWB"
        Me.GridColumn17.FieldName = "awbill_no"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 11
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Scan Manifest"
        Me.GridColumn15.FieldName = "scan_manifest"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 12
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Manifest"
        Me.GridColumn16.FieldName = "print_manifest"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 13
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BRefreshHistory)
        Me.PanelControl2.Controls.Add(Me.BPrint)
        Me.PanelControl2.Controls.Add(Me.DETo)
        Me.PanelControl2.Controls.Add(Me.LabelControl19)
        Me.PanelControl2.Controls.Add(Me.LabelControl18)
        Me.PanelControl2.Controls.Add(Me.DEFrom)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(910, 46)
        Me.PanelControl2.TabIndex = 1
        '
        'BRefreshHistory
        '
        Me.BRefreshHistory.Dock = System.Windows.Forms.DockStyle.Right
        Me.BRefreshHistory.Image = CType(resources.GetObject("BRefreshHistory.Image"), System.Drawing.Image)
        Me.BRefreshHistory.Location = New System.Drawing.Point(684, 2)
        Me.BRefreshHistory.Name = "BRefreshHistory"
        Me.BRefreshHistory.Size = New System.Drawing.Size(112, 42)
        Me.BRefreshHistory.TabIndex = 3
        Me.BRefreshHistory.Text = "Refresh"
        '
        'BPrint
        '
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPrint.Image = CType(resources.GetObject("BPrint.Image"), System.Drawing.Image)
        Me.BPrint.Location = New System.Drawing.Point(796, 2)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(112, 42)
        Me.BPrint.TabIndex = 8930
        Me.BPrint.Text = "Print"
        '
        'DETo
        '
        Me.DETo.EditValue = Nothing
        Me.DETo.Location = New System.Drawing.Point(297, 14)
        Me.DETo.Name = "DETo"
        Me.DETo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETo.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DETo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DETo.Size = New System.Drawing.Size(158, 20)
        Me.DETo.TabIndex = 8929
        '
        'LabelControl19
        '
        Me.LabelControl19.Location = New System.Drawing.Point(279, 16)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl19.TabIndex = 8928
        Me.LabelControl19.Text = "To"
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(11, 16)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(98, 13)
        Me.LabelControl18.TabIndex = 8927
        Me.LabelControl18.Text = "Outbound label from"
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(115, 13)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Size = New System.Drawing.Size(158, 20)
        Me.DEFrom.TabIndex = 8926
        '
        'FormOutboundList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(916, 522)
        Me.Controls.Add(Me.XTCOutbound)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormOutboundList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Outbound Number List"
        CType(Me.XTCOutbound, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCOutbound.ResumeLayout(False)
        Me.XTPPending.ResumeLayout(False)
        CType(Me.GCOutbound, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GVOutbound, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TEOutboundNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPHistory.ResumeLayout(False)
        CType(Me.GCHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.DETo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DETo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCOutbound As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPending As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPHistory As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCOutbound As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOutbound As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEOutboundNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ViewDocumentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BRefreshHistory As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCHistory As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVHistory As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CancelOutboundLabelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DETo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BOutboundLabel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CancelOutboundLabelToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BCheckFisik As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
End Class
