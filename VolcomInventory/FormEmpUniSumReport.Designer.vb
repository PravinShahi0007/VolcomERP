<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpUniSumReport
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
        Me.XTCUniReport = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPByPeriod = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPeriod = New DevExpress.XtraGrid.GridControl()
        Me.GVPeriod = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdDept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBudget = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnActual = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.LEPeriodx = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPByYear = New DevExpress.XtraTab.XtraTabPage()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCUniReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCUniReport.SuspendLayout()
        Me.XTPByPeriod.SuspendLayout()
        CType(Me.GCPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LEPeriodx.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCUniReport
        '
        Me.XTCUniReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCUniReport.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCUniReport.Location = New System.Drawing.Point(0, 0)
        Me.XTCUniReport.Name = "XTCUniReport"
        Me.XTCUniReport.SelectedTabPage = Me.XTPByPeriod
        Me.XTCUniReport.Size = New System.Drawing.Size(803, 568)
        Me.XTCUniReport.TabIndex = 0
        Me.XTCUniReport.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPByPeriod, Me.XTPByYear})
        '
        'XTPByPeriod
        '
        Me.XTPByPeriod.Controls.Add(Me.GCPeriod)
        Me.XTPByPeriod.Controls.Add(Me.PanelControl1)
        Me.XTPByPeriod.Name = "XTPByPeriod"
        Me.XTPByPeriod.Size = New System.Drawing.Size(797, 540)
        Me.XTPByPeriod.Text = "Summary by Period"
        '
        'GCPeriod
        '
        Me.GCPeriod.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPeriod.Location = New System.Drawing.Point(0, 41)
        Me.GCPeriod.MainView = Me.GVPeriod
        Me.GCPeriod.Name = "GCPeriod"
        Me.GCPeriod.Size = New System.Drawing.Size(797, 499)
        Me.GCPeriod.TabIndex = 2
        Me.GCPeriod.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPeriod})
        '
        'GVPeriod
        '
        Me.GVPeriod.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdDept, Me.GridColumnDept, Me.GridColumnBudget, Me.GridColumnActual, Me.GridColumnQty})
        Me.GVPeriod.GridControl = Me.GCPeriod
        Me.GVPeriod.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "budget", Me.GridColumnBudget, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "actual", Me.GridColumnActual, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", Me.GridColumnQty, "{0:N0}")})
        Me.GVPeriod.Name = "GVPeriod"
        Me.GVPeriod.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVPeriod.OptionsBehavior.Editable = False
        Me.GVPeriod.OptionsView.ShowFooter = True
        Me.GVPeriod.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdDept
        '
        Me.GridColumnIdDept.Caption = "Id Departement"
        Me.GridColumnIdDept.FieldName = "id_departement"
        Me.GridColumnIdDept.Name = "GridColumnIdDept"
        '
        'GridColumnDept
        '
        Me.GridColumnDept.Caption = "Department"
        Me.GridColumnDept.FieldName = "departement"
        Me.GridColumnDept.Name = "GridColumnDept"
        Me.GridColumnDept.Visible = True
        Me.GridColumnDept.VisibleIndex = 0
        '
        'GridColumnBudget
        '
        Me.GridColumnBudget.Caption = "Budget"
        Me.GridColumnBudget.DisplayFormat.FormatString = "N2"
        Me.GridColumnBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnBudget.FieldName = "budget"
        Me.GridColumnBudget.Name = "GridColumnBudget"
        Me.GridColumnBudget.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "budget", "{0:N2}")})
        Me.GridColumnBudget.Visible = True
        Me.GridColumnBudget.VisibleIndex = 1
        '
        'GridColumnActual
        '
        Me.GridColumnActual.Caption = "Actual"
        Me.GridColumnActual.DisplayFormat.FormatString = "N2"
        Me.GridColumnActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnActual.FieldName = "actual"
        Me.GridColumnActual.Name = "GridColumnActual"
        Me.GridColumnActual.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "actual", "{0:N2}")})
        Me.GridColumnActual.Visible = True
        Me.GridColumnActual.VisibleIndex = 2
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Controls.Add(Me.LEPeriodx)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(797, 41)
        Me.PanelControl1.TabIndex = 1
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(285, 9)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 23)
        Me.BtnView.TabIndex = 17
        Me.BtnView.Text = "View"
        '
        'LEPeriodx
        '
        Me.LEPeriodx.Location = New System.Drawing.Point(51, 11)
        Me.LEPeriodx.Name = "LEPeriodx"
        Me.LEPeriodx.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEPeriodx.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_emp_uni_period", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("period_name", "Period"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("selection_date_start", "Start", 20, DevExpress.Utils.FormatType.DateTime, "dd\/MM\/yyyy", True, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("selection_date_end", "End", 20, DevExpress.Utils.FormatType.DateTime, "dd\/MM\/yyyy", True, DevExpress.Utils.HorzAlignment.[Default])})
        Me.LEPeriodx.Size = New System.Drawing.Size(228, 20)
        Me.LEPeriodx.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(30, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Period"
        '
        'XTPByYear
        '
        Me.XTPByYear.Name = "XTPByYear"
        Me.XTPByYear.Size = New System.Drawing.Size(797, 540)
        Me.XTPByYear.Text = "Summary by Year"
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 3
        '
        'FormEmpUniSumReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 568)
        Me.Controls.Add(Me.XTCUniReport)
        Me.MinimizeBox = False
        Me.Name = "FormEmpUniSumReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Uniform Report"
        CType(Me.XTCUniReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCUniReport.ResumeLayout(False)
        Me.XTPByPeriod.ResumeLayout(False)
        CType(Me.GCPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.LEPeriodx.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCUniReport As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPByPeriod As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPByYear As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LEPeriodx As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCPeriod As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPeriod As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdDept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBudget As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnActual As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
End Class
