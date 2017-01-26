<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormFGLineListMoveSeason
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
        Me.PBC = New DevExpress.XtraEditors.ProgressBarControl()
        Me.BtnUpdateRec = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelSeason = New DevExpress.XtraEditors.LabelControl()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRange = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LEPlanStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.SLESeasonFrom = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelSeasonFrom = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PBC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEPlanStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLESeasonFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PBC
        '
        Me.PBC.Dock = System.Windows.Forms.DockStyle.Top
        Me.PBC.Location = New System.Drawing.Point(0, 0)
        Me.PBC.Name = "PBC"
        Me.PBC.Size = New System.Drawing.Size(297, 6)
        Me.PBC.TabIndex = 8903
        Me.PBC.Visible = False
        '
        'BtnUpdateRec
        '
        Me.BtnUpdateRec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnUpdateRec.Location = New System.Drawing.Point(2, 2)
        Me.BtnUpdateRec.LookAndFeel.SkinName = "Blue"
        Me.BtnUpdateRec.Name = "BtnUpdateRec"
        Me.BtnUpdateRec.Size = New System.Drawing.Size(293, 24)
        Me.BtnUpdateRec.TabIndex = 8905
        Me.BtnUpdateRec.Text = "Update"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(10, 19)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl7.TabIndex = 8906
        Me.LabelControl7.Text = "Move/Drop"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnUpdateRec)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 76)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(297, 28)
        Me.PanelControl1.TabIndex = 8907
        '
        'LabelSeason
        '
        Me.LabelSeason.Location = New System.Drawing.Point(10, 45)
        Me.LabelSeason.Name = "LabelSeason"
        Me.LabelSeason.Size = New System.Drawing.Size(12, 13)
        Me.LabelSeason.TabIndex = 8908
        Me.LabelSeason.Text = "To"
        '
        'SLESeason
        '
        Me.SLESeason.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SLESeason.Enabled = False
        Me.SLESeason.Location = New System.Drawing.Point(79, 42)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(206, 20)
        Me.SLESeason.TabIndex = 8909
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdSeason, Me.GridColumnRange, Me.GridColumnSeason})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "Id Season"
        Me.GridColumnIdSeason.FieldName = "id_season"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        '
        'GridColumnRange
        '
        Me.GridColumnRange.Caption = "Range"
        Me.GridColumnRange.FieldName = "range"
        Me.GridColumnRange.Name = "GridColumnRange"
        Me.GridColumnRange.Visible = True
        Me.GridColumnRange.VisibleIndex = 0
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        Me.GridColumnSeason.Visible = True
        Me.GridColumnSeason.VisibleIndex = 1
        '
        'LEPlanStatus
        '
        Me.LEPlanStatus.Location = New System.Drawing.Point(79, 16)
        Me.LEPlanStatus.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.LEPlanStatus.Name = "LEPlanStatus"
        Me.LEPlanStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEPlanStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_lookup_status_order", "Id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("lookup_status_order", "Status")})
        Me.LEPlanStatus.Size = New System.Drawing.Size(206, 20)
        Me.LEPlanStatus.TabIndex = 8910
        '
        'SLESeasonFrom
        '
        Me.SLESeasonFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SLESeasonFrom.Enabled = False
        Me.SLESeasonFrom.Location = New System.Drawing.Point(79, 106)
        Me.SLESeasonFrom.Name = "SLESeasonFrom"
        Me.SLESeasonFrom.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeasonFrom.Properties.Appearance.Options.UseFont = True
        Me.SLESeasonFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeasonFrom.Properties.View = Me.GridView1
        Me.SLESeasonFrom.Size = New System.Drawing.Size(206, 20)
        Me.SLESeasonFrom.TabIndex = 8911
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Season"
        Me.GridColumn1.FieldName = "id_season"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Range"
        Me.GridColumn2.FieldName = "range"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Season"
        Me.GridColumn3.FieldName = "season"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'LabelSeasonFrom
        '
        Me.LabelSeasonFrom.Location = New System.Drawing.Point(12, 109)
        Me.LabelSeasonFrom.Name = "LabelSeasonFrom"
        Me.LabelSeasonFrom.Size = New System.Drawing.Size(24, 13)
        Me.LabelSeasonFrom.TabIndex = 8912
        Me.LabelSeasonFrom.Text = "From"
        '
        'FormFGLineListMoveSeason
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(297, 104)
        Me.Controls.Add(Me.LabelSeasonFrom)
        Me.Controls.Add(Me.SLESeasonFrom)
        Me.Controls.Add(Me.LEPlanStatus)
        Me.Controls.Add(Me.SLESeason)
        Me.Controls.Add(Me.LabelSeason)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.PBC)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFGLineListMoveSeason"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Move/Drop"
        CType(Me.PBC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEPlanStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLESeasonFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PBC As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents BtnUpdateRec As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelSeason As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRange As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LEPlanStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents SLESeasonFrom As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelSeasonFrom As DevExpress.XtraEditors.LabelControl
End Class
