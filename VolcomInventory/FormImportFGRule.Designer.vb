<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormImportFGRule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormImportFGRule))
        Me.GCRule = New DevExpress.XtraGrid.GridControl()
        Me.CMSRuleName = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SetNonActiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVRule = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BAddRule = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TERuleName = New DevExpress.XtraEditors.TextEdit()
        Me.BRefreshRule = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BAddVendor = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEVendor = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.BRefreshVendor = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BRefreshDetailRule = New DevExpress.XtraEditors.SimpleButton()
        Me.GCDetailRule = New DevExpress.XtraGrid.GridControl()
        Me.GVDetailRule = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.GCVendor = New DevExpress.XtraGrid.GridControl()
        Me.GVVendor = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl5 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl6 = New DevExpress.XtraEditors.PanelControl()
        Me.CMVendor = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SMDropVendor = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.GCRule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMSRuleName.SuspendLayout()
        CType(Me.GVRule, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TERuleName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.GCDetailRule, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDetailRule, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.GCVendor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVVendor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl5.SuspendLayout()
        CType(Me.PanelControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl6.SuspendLayout()
        Me.CMVendor.SuspendLayout()
        Me.SuspendLayout()
        '
        'GCRule
        '
        Me.GCRule.ContextMenuStrip = Me.CMSRuleName
        Me.GCRule.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRule.Location = New System.Drawing.Point(0, 47)
        Me.GCRule.MainView = Me.GVRule
        Me.GCRule.Name = "GCRule"
        Me.GCRule.Size = New System.Drawing.Size(626, 286)
        Me.GCRule.TabIndex = 3
        Me.GCRule.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRule})
        '
        'CMSRuleName
        '
        Me.CMSRuleName.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetNonActiveToolStripMenuItem})
        Me.CMSRuleName.Name = "CMSRuleName"
        Me.CMSRuleName.Size = New System.Drawing.Size(153, 26)
        '
        'SetNonActiveToolStripMenuItem
        '
        Me.SetNonActiveToolStripMenuItem.Name = "SetNonActiveToolStripMenuItem"
        Me.SetNonActiveToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SetNonActiveToolStripMenuItem.Text = "Set Non Active"
        '
        'GVRule
        '
        Me.GVRule.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn7, Me.GridColumn8})
        Me.GVRule.GridControl = Me.GCRule
        Me.GVRule.Name = "GVRule"
        Me.GVRule.OptionsBehavior.Editable = False
        Me.GVRule.OptionsBehavior.ReadOnly = True
        Me.GVRule.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "ID"
        Me.GridColumn6.FieldName = "id_import_rule"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Rule Name"
        Me.GridColumn7.FieldName = "import_rule"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn8.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn8.Caption = "Status"
        Me.GridColumn8.FieldName = "active_sts"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BAddRule)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.TERuleName)
        Me.PanelControl1.Controls.Add(Me.BRefreshRule)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(626, 47)
        Me.PanelControl1.TabIndex = 0
        '
        'BAddRule
        '
        Me.BAddRule.Location = New System.Drawing.Point(330, 12)
        Me.BAddRule.Name = "BAddRule"
        Me.BAddRule.Size = New System.Drawing.Size(50, 23)
        Me.BAddRule.TabIndex = 4
        Me.BAddRule.Text = "add"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(10, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Rule Name"
        '
        'TERuleName
        '
        Me.TERuleName.Location = New System.Drawing.Point(67, 14)
        Me.TERuleName.Name = "TERuleName"
        Me.TERuleName.Size = New System.Drawing.Size(257, 20)
        Me.TERuleName.TabIndex = 2
        '
        'BRefreshRule
        '
        Me.BRefreshRule.Dock = System.Windows.Forms.DockStyle.Right
        Me.BRefreshRule.Image = CType(resources.GetObject("BRefreshRule.Image"), System.Drawing.Image)
        Me.BRefreshRule.Location = New System.Drawing.Point(501, 2)
        Me.BRefreshRule.Name = "BRefreshRule"
        Me.BRefreshRule.Size = New System.Drawing.Size(123, 43)
        Me.BRefreshRule.TabIndex = 1
        Me.BRefreshRule.Text = "Refresh Rule"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BAddVendor)
        Me.PanelControl2.Controls.Add(Me.SLEVendor)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.BRefreshVendor)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(628, 2)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(529, 47)
        Me.PanelControl2.TabIndex = 1
        '
        'BAddVendor
        '
        Me.BAddVendor.Location = New System.Drawing.Point(235, 12)
        Me.BAddVendor.Name = "BAddVendor"
        Me.BAddVendor.Size = New System.Drawing.Size(50, 23)
        Me.BAddVendor.TabIndex = 8917
        Me.BAddVendor.Text = "add"
        '
        'SLEVendor
        '
        Me.SLEVendor.Location = New System.Drawing.Point(52, 14)
        Me.SLEVendor.Name = "SLEVendor"
        Me.SLEVendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEVendor.Properties.View = Me.GridView6
        Me.SLEVendor.Size = New System.Drawing.Size(177, 20)
        Me.SLEVendor.TabIndex = 8916
        '
        'GridView6
        '
        Me.GridView6.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn28, Me.GridColumn29})
        Me.GridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView6.Name = "GridView6"
        Me.GridView6.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView6.OptionsView.ShowGroupPanel = False
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "ID Comp Contact"
        Me.GridColumn28.FieldName = "id_comp_contact"
        Me.GridColumn28.Name = "GridColumn28"
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Vendor"
        Me.GridColumn29.FieldName = "comp_name"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 0
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl2.TabIndex = 8915
        Me.LabelControl2.Text = "Vendor"
        '
        'BRefreshVendor
        '
        Me.BRefreshVendor.Dock = System.Windows.Forms.DockStyle.Right
        Me.BRefreshVendor.Image = CType(resources.GetObject("BRefreshVendor.Image"), System.Drawing.Image)
        Me.BRefreshVendor.Location = New System.Drawing.Point(404, 2)
        Me.BRefreshVendor.Name = "BRefreshVendor"
        Me.BRefreshVendor.Size = New System.Drawing.Size(123, 43)
        Me.BRefreshVendor.TabIndex = 1
        Me.BRefreshVendor.Text = "Refresh Vendor"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BRefreshDetailRule)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(1155, 47)
        Me.PanelControl3.TabIndex = 1
        '
        'BRefreshDetailRule
        '
        Me.BRefreshDetailRule.Dock = System.Windows.Forms.DockStyle.Right
        Me.BRefreshDetailRule.Image = CType(resources.GetObject("BRefreshDetailRule.Image"), System.Drawing.Image)
        Me.BRefreshDetailRule.Location = New System.Drawing.Point(1030, 2)
        Me.BRefreshDetailRule.Name = "BRefreshDetailRule"
        Me.BRefreshDetailRule.Size = New System.Drawing.Size(123, 43)
        Me.BRefreshDetailRule.TabIndex = 0
        Me.BRefreshDetailRule.Text = "Refresh Detail"
        '
        'GCDetailRule
        '
        Me.GCDetailRule.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDetailRule.Location = New System.Drawing.Point(2, 49)
        Me.GCDetailRule.MainView = Me.GVDetailRule
        Me.GCDetailRule.Name = "GCDetailRule"
        Me.GCDetailRule.Size = New System.Drawing.Size(1155, 247)
        Me.GCDetailRule.TabIndex = 4
        Me.GCDetailRule.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetailRule})
        '
        'GVDetailRule
        '
        Me.GVDetailRule.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5})
        Me.GVDetailRule.GridControl = Me.GCDetailRule
        Me.GVDetailRule.Name = "GVDetailRule"
        Me.GVDetailRule.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.Caption = "Qty Order"
        Me.GridColumn2.DisplayFormat.FormatString = "N0"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.Caption = "Qty Sample"
        Me.GridColumn3.DisplayFormat.FormatString = "N0"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn4.Caption = "Batas Maksimum Reject Minor"
        Me.GridColumn4.DisplayFormat.FormatString = "N0"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn5.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn5.Caption = "Batas Maksimum Reject Major"
        Me.GridColumn5.DisplayFormat.FormatString = "N0"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.GCVendor)
        Me.PanelControl4.Controls.Add(Me.PanelControl2)
        Me.PanelControl4.Controls.Add(Me.PanelControl5)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl4.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(1159, 337)
        Me.PanelControl4.TabIndex = 1
        '
        'GCVendor
        '
        Me.GCVendor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCVendor.Location = New System.Drawing.Point(628, 49)
        Me.GCVendor.MainView = Me.GVVendor
        Me.GCVendor.Name = "GCVendor"
        Me.GCVendor.Size = New System.Drawing.Size(529, 286)
        Me.GCVendor.TabIndex = 4
        Me.GCVendor.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVVendor})
        '
        'GVVendor
        '
        Me.GVVendor.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn9, Me.GridColumn10, Me.GridColumn11})
        Me.GVVendor.GridControl = Me.GCVendor
        Me.GVVendor.Name = "GVVendor"
        Me.GVVendor.OptionsBehavior.Editable = False
        Me.GVVendor.OptionsBehavior.ReadOnly = True
        Me.GVVendor.OptionsView.ShowGroupPanel = False
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "ID"
        Me.GridColumn9.FieldName = "id_import_rule_vendor"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Vendor Code"
        Me.GridColumn10.FieldName = "comp_number"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        Me.GridColumn10.Width = 169
        '
        'GridColumn11
        '
        Me.GridColumn11.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridColumn11.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridColumn11.Caption = "Vendor Name"
        Me.GridColumn11.FieldName = "comp_name"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 1
        Me.GridColumn11.Width = 550
        '
        'PanelControl5
        '
        Me.PanelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl5.Controls.Add(Me.GCRule)
        Me.PanelControl5.Controls.Add(Me.PanelControl1)
        Me.PanelControl5.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl5.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl5.Name = "PanelControl5"
        Me.PanelControl5.Size = New System.Drawing.Size(626, 333)
        Me.PanelControl5.TabIndex = 0
        '
        'PanelControl6
        '
        Me.PanelControl6.Controls.Add(Me.GCDetailRule)
        Me.PanelControl6.Controls.Add(Me.PanelControl3)
        Me.PanelControl6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl6.Location = New System.Drawing.Point(0, 337)
        Me.PanelControl6.Name = "PanelControl6"
        Me.PanelControl6.Size = New System.Drawing.Size(1159, 298)
        Me.PanelControl6.TabIndex = 2
        '
        'CMVendor
        '
        Me.CMVendor.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMDropVendor})
        Me.CMVendor.Name = "CMSRuleName"
        Me.CMVendor.Size = New System.Drawing.Size(153, 48)
        '
        'SMDropVendor
        '
        Me.SMDropVendor.Name = "SMDropVendor"
        Me.SMDropVendor.Size = New System.Drawing.Size(152, 22)
        Me.SMDropVendor.Text = "Drop Vendor"
        '
        'FormImportFGRule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1159, 635)
        Me.Controls.Add(Me.PanelControl6)
        Me.Controls.Add(Me.PanelControl4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormImportFGRule"
        Me.Text = "Import Rule"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GCRule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMSRuleName.ResumeLayout(False)
        CType(Me.GVRule, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TERuleName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.GCDetailRule, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDetailRule, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.GCVendor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVVendor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl5.ResumeLayout(False)
        CType(Me.PanelControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl6.ResumeLayout(False)
        Me.CMVendor.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCRule As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRule As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCDetailRule As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDetailRule As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BRefreshDetailRule As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BRefreshRule As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BRefreshVendor As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl5 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl6 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCVendor As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVVendor As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BAddRule As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TERuleName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BAddVendor As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEVendor As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CMSRuleName As ContextMenuStrip
    Friend WithEvents SetNonActiveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CMVendor As ContextMenuStrip
    Friend WithEvents SMDropVendor As ToolStripMenuItem
End Class
