<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormShareholder
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
        Me.BImport = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.TESharePercent = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.TEPPHPercent = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SLECOA = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLEVendor = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GCShareHolder = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVShareHolder = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TESharePercent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPPHPercent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLECOA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCShareHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GVShareHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BImport
        '
        Me.BImport.Appearance.BackColor = System.Drawing.Color.Blue
        Me.BImport.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BImport.Appearance.ForeColor = System.Drawing.Color.White
        Me.BImport.Appearance.Options.UseBackColor = True
        Me.BImport.Appearance.Options.UseFont = True
        Me.BImport.Appearance.Options.UseForeColor = True
        Me.BImport.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BImport.Location = New System.Drawing.Point(0, 457)
        Me.BImport.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.BImport.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BImport.Name = "BImport"
        Me.BImport.Size = New System.Drawing.Size(941, 41)
        Me.BImport.TabIndex = 92
        Me.BImport.Text = "Save"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl6)
        Me.PanelControl1.Controls.Add(Me.LabelControl5)
        Me.PanelControl1.Controls.Add(Me.TESharePercent)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.BAdd)
        Me.PanelControl1.Controls.Add(Me.TEPPHPercent)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.SLECOA)
        Me.PanelControl1.Controls.Add(Me.SLEVendor)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(941, 122)
        Me.PanelControl1.TabIndex = 93
        '
        'TESharePercent
        '
        Me.TESharePercent.Location = New System.Drawing.Point(85, 38)
        Me.TESharePercent.Name = "TESharePercent"
        Me.TESharePercent.Properties.Mask.EditMask = "N0"
        Me.TESharePercent.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TESharePercent.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TESharePercent.Size = New System.Drawing.Size(74, 20)
        Me.TESharePercent.TabIndex = 8930
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(11, 41)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(68, 13)
        Me.LabelControl4.TabIndex = 8929
        Me.LabelControl4.Text = "Share Percent"
        '
        'BAdd
        '
        Me.BAdd.Appearance.BackColor = System.Drawing.Color.ForestGreen
        Me.BAdd.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BAdd.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BAdd.Appearance.Options.UseBackColor = True
        Me.BAdd.Appearance.Options.UseFont = True
        Me.BAdd.Appearance.Options.UseForeColor = True
        Me.BAdd.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BAdd.Location = New System.Drawing.Point(2, 92)
        Me.BAdd.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.BAdd.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(937, 28)
        Me.BAdd.TabIndex = 8928
        Me.BAdd.Text = "Add"
        '
        'TEPPHPercent
        '
        Me.TEPPHPercent.Location = New System.Drawing.Point(376, 64)
        Me.TEPPHPercent.Name = "TEPPHPercent"
        Me.TEPPHPercent.Properties.Mask.EditMask = "N0"
        Me.TEPPHPercent.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEPPHPercent.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEPPHPercent.Size = New System.Drawing.Size(59, 20)
        Me.TEPPHPercent.TabIndex = 8927
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(311, 67)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl3.TabIndex = 8926
        Me.LabelControl3.Text = "PPH Percent"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 67)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl2.TabIndex = 8925
        Me.LabelControl2.Text = "PPH COA"
        '
        'SLECOA
        '
        Me.SLECOA.Location = New System.Drawing.Point(85, 64)
        Me.SLECOA.Name = "SLECOA"
        Me.SLECOA.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLECOA.Properties.NullText = ""
        Me.SLECOA.Properties.ShowClearButton = False
        Me.SLECOA.Properties.View = Me.GridView2
        Me.SLECOA.Size = New System.Drawing.Size(220, 20)
        Me.SLECOA.TabIndex = 8924
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn10, Me.GridColumn13, Me.GridColumn11, Me.GridColumn12})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Id"
        Me.GridColumn10.FieldName = "id_acc"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Desc"
        Me.GridColumn13.FieldName = "acc_desc"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Account"
        Me.GridColumn11.FieldName = "acc_name"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 0
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Description"
        Me.GridColumn12.FieldName = "acc_description"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 1
        '
        'SLEVendor
        '
        Me.SLEVendor.Location = New System.Drawing.Point(85, 12)
        Me.SLEVendor.Name = "SLEVendor"
        Me.SLEVendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEVendor.Properties.View = Me.GridView1
        Me.SLEVendor.Size = New System.Drawing.Size(367, 20)
        Me.SLEVendor.TabIndex = 8923
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn9, Me.GridColumn29})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "ID Comp Contact"
        Me.GridColumn9.FieldName = "id_comp_contact"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Vendor"
        Me.GridColumn29.FieldName = "comp_name"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl1.TabIndex = 8922
        Me.LabelControl1.Text = "Shareholder"
        '
        'GCShareHolder
        '
        Me.GCShareHolder.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCShareHolder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCShareHolder.Location = New System.Drawing.Point(0, 122)
        Me.GCShareHolder.MainView = Me.GVShareHolder
        Me.GCShareHolder.Name = "GCShareHolder"
        Me.GCShareHolder.Size = New System.Drawing.Size(941, 335)
        Me.GCShareHolder.TabIndex = 94
        Me.GCShareHolder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVShareHolder})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'GVShareHolder
        '
        Me.GVShareHolder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn6, Me.GridColumn8, Me.GridColumn7, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5})
        Me.GVShareHolder.GridControl = Me.GCShareHolder
        Me.GVShareHolder.Name = "GVShareHolder"
        Me.GVShareHolder.OptionsView.ShowFooter = True
        Me.GVShareHolder.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_shareholder"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "ID Comp"
        Me.GridColumn6.FieldName = "id_comp"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "ID ACC PPH"
        Me.GridColumn8.FieldName = "pph_account"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Code"
        Me.GridColumn7.FieldName = "comp_number"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        Me.GridColumn7.Width = 70
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Shareholder"
        Me.GridColumn2.FieldName = "comp_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 204
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "PPH Account"
        Me.GridColumn3.FieldName = "pph_desc"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 204
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "PPH Percent"
        Me.GridColumn4.DisplayFormat.FormatString = "N2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "pph_percent"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 204
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Percent Share"
        Me.GridColumn5.DisplayFormat.FormatString = "N2"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "deviden_percent"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "deviden_percent", "{0:N2}")})
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        Me.GridColumn5.Width = 211
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(165, 41)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(11, 13)
        Me.LabelControl5.TabIndex = 8931
        Me.LabelControl5.Text = "%"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(441, 67)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(11, 13)
        Me.LabelControl6.TabIndex = 8932
        Me.LabelControl6.Text = "%"
        '
        'FormShareholder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(941, 498)
        Me.Controls.Add(Me.GCShareHolder)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.BImport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormShareholder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Shareholder"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TESharePercent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPPHPercent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLECOA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCShareHolder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GVShareHolder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BImport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCShareHolder As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVShareHolder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEVendor As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLECOA As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEPPHPercent As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TESharePercent As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
End Class
