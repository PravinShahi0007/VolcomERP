<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBudgetProdDemand
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBudgetProdDemand))
        Me.XTCBudget = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPApproved = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPProposedBudget = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.DEYearBudget = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.GCApprovedBudget = New DevExpress.XtraGrid.GridControl()
        Me.GVApprovedBudget = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_b_prod_demand = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnyear = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_season = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnseason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnvalue = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCBudget, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCBudget.SuspendLayout()
        Me.XTPApproved.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEYearBudget.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEYearBudget.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCApprovedBudget, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVApprovedBudget, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCBudget
        '
        Me.XTCBudget.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCBudget.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCBudget.Location = New System.Drawing.Point(0, 0)
        Me.XTCBudget.Name = "XTCBudget"
        Me.XTCBudget.SelectedTabPage = Me.XTPApproved
        Me.XTCBudget.Size = New System.Drawing.Size(832, 542)
        Me.XTCBudget.TabIndex = 0
        Me.XTCBudget.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPApproved, Me.XTPProposedBudget})
        '
        'XTPApproved
        '
        Me.XTPApproved.Controls.Add(Me.GCApprovedBudget)
        Me.XTPApproved.Controls.Add(Me.PanelControl1)
        Me.XTPApproved.Name = "XTPApproved"
        Me.XTPApproved.Size = New System.Drawing.Size(826, 514)
        Me.XTPApproved.Text = "Approved Budget"
        '
        'XTPProposedBudget
        '
        Me.XTPProposedBudget.Name = "XTPProposedBudget"
        Me.XTPProposedBudget.Size = New System.Drawing.Size(294, 272)
        Me.XTPProposedBudget.Text = "Proposed Budget"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.DEYearBudget)
        Me.PanelControl1.Controls.Add(Me.LabelControl6)
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(826, 38)
        Me.PanelControl1.TabIndex = 5
        '
        'DEYearBudget
        '
        Me.DEYearBudget.EditValue = Nothing
        Me.DEYearBudget.Location = New System.Drawing.Point(77, 8)
        Me.DEYearBudget.Name = "DEYearBudget"
        Me.DEYearBudget.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEYearBudget.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEYearBudget.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEYearBudget.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.DEYearBudget.Properties.DisplayFormat.FormatString = "yyyy"
        Me.DEYearBudget.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEYearBudget.Properties.Mask.EditMask = "yyyy"
        Me.DEYearBudget.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEYearBudget.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView
        Me.DEYearBudget.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView
        Me.DEYearBudget.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.DEYearBudget.Size = New System.Drawing.Size(143, 20)
        Me.DEYearBudget.TabIndex = 8905
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(12, 11)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl6.TabIndex = 8904
        Me.LabelControl6.Text = "Year Budget"
        '
        'BtnView
        '
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(226, 6)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(68, 23)
        Me.BtnView.TabIndex = 8903
        Me.BtnView.Text = "View"
        '
        'GCApprovedBudget
        '
        Me.GCApprovedBudget.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCApprovedBudget.Location = New System.Drawing.Point(0, 38)
        Me.GCApprovedBudget.MainView = Me.GVApprovedBudget
        Me.GCApprovedBudget.Name = "GCApprovedBudget"
        Me.GCApprovedBudget.Size = New System.Drawing.Size(826, 476)
        Me.GCApprovedBudget.TabIndex = 6
        Me.GCApprovedBudget.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVApprovedBudget})
        '
        'GVApprovedBudget
        '
        Me.GVApprovedBudget.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_b_prod_demand, Me.GridColumnyear, Me.GridColumnid_season, Me.GridColumnseason, Me.GridColumnvalue})
        Me.GVApprovedBudget.GridControl = Me.GCApprovedBudget
        Me.GVApprovedBudget.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "value", Me.GridColumnvalue, "{0:N2}")})
        Me.GVApprovedBudget.Name = "GVApprovedBudget"
        Me.GVApprovedBudget.OptionsBehavior.ReadOnly = True
        Me.GVApprovedBudget.OptionsFind.AlwaysVisible = True
        Me.GVApprovedBudget.OptionsView.ColumnAutoWidth = False
        Me.GVApprovedBudget.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_b_prod_demand
        '
        Me.GridColumnid_b_prod_demand.Caption = "id_b_prod_demand"
        Me.GridColumnid_b_prod_demand.FieldName = "id_b_prod_demand"
        Me.GridColumnid_b_prod_demand.Name = "GridColumnid_b_prod_demand"
        '
        'GridColumnyear
        '
        Me.GridColumnyear.Caption = "Year Budget"
        Me.GridColumnyear.FieldName = "year"
        Me.GridColumnyear.Name = "GridColumnyear"
        Me.GridColumnyear.Visible = True
        Me.GridColumnyear.VisibleIndex = 0
        '
        'GridColumnid_season
        '
        Me.GridColumnid_season.Caption = "id_season"
        Me.GridColumnid_season.FieldName = "id_season"
        Me.GridColumnid_season.Name = "GridColumnid_season"
        '
        'GridColumnseason
        '
        Me.GridColumnseason.Caption = "Season"
        Me.GridColumnseason.FieldName = "season"
        Me.GridColumnseason.Name = "GridColumnseason"
        Me.GridColumnseason.Visible = True
        Me.GridColumnseason.VisibleIndex = 1
        '
        'GridColumnvalue
        '
        Me.GridColumnvalue.Caption = "Value"
        Me.GridColumnvalue.DisplayFormat.FormatString = "N2"
        Me.GridColumnvalue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnvalue.FieldName = "value"
        Me.GridColumnvalue.Name = "GridColumnvalue"
        Me.GridColumnvalue.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "value", "{0:N2}")})
        Me.GridColumnvalue.Visible = True
        Me.GridColumnvalue.VisibleIndex = 2
        '
        'FormBudgetProdDemand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 542)
        Me.Controls.Add(Me.XTCBudget)
        Me.Name = "FormBudgetProdDemand"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setup Budget Production Demand"
        CType(Me.XTCBudget, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCBudget.ResumeLayout(False)
        Me.XTPApproved.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DEYearBudget.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEYearBudget.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCApprovedBudget, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVApprovedBudget, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCBudget As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPApproved As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPProposedBudget As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEYearBudget As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCApprovedBudget As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVApprovedBudget As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_b_prod_demand As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnyear As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_season As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnseason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnvalue As DevExpress.XtraGrid.Columns.GridColumn
End Class
