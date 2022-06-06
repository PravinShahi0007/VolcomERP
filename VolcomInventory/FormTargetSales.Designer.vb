<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTargetSales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTargetSales))
        Me.XTCSalesTarget = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPList = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SLEYear = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPPropose = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPropose = New DevExpress.XtraGrid.GridControl()
        Me.GVPropose = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_b_revenue_propose = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnyear = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_user = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_report_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnis_confirm = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCreateNew = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnViewPropose = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEYearPropose = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.XTCSalesTarget, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCSalesTarget.SuspendLayout()
        Me.XTPList.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPPropose.SuspendLayout()
        CType(Me.GCPropose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPropose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.SLEYearPropose.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCSalesTarget
        '
        Me.XTCSalesTarget.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCSalesTarget.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCSalesTarget.Location = New System.Drawing.Point(0, 0)
        Me.XTCSalesTarget.Name = "XTCSalesTarget"
        Me.XTCSalesTarget.SelectedTabPage = Me.XTPList
        Me.XTCSalesTarget.Size = New System.Drawing.Size(660, 474)
        Me.XTCSalesTarget.TabIndex = 0
        Me.XTCSalesTarget.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPList, Me.XTPPropose})
        '
        'XTPList
        '
        Me.XTPList.Controls.Add(Me.PanelControl1)
        Me.XTPList.Name = "XTPList"
        Me.XTPList.Size = New System.Drawing.Size(654, 446)
        Me.XTPList.Text = "List"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SLEYear)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(654, 54)
        Me.PanelControl1.TabIndex = 0
        '
        'SLEYear
        '
        Me.SLEYear.Location = New System.Drawing.Point(41, 19)
        Me.SLEYear.Name = "SLEYear"
        Me.SLEYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEYear.Properties.NullText = "- Select Year -"
        Me.SLEYear.Properties.ShowClearButton = False
        Me.SLEYear.Properties.View = Me.GridView1
        Me.SLEYear.Size = New System.Drawing.Size(140, 20)
        Me.SLEYear.TabIndex = 3
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(13, 22)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Year"
        '
        'XTPPropose
        '
        Me.XTPPropose.Controls.Add(Me.GCPropose)
        Me.XTPPropose.Controls.Add(Me.PanelControl2)
        Me.XTPPropose.Name = "XTPPropose"
        Me.XTPPropose.Size = New System.Drawing.Size(654, 446)
        Me.XTPPropose.Text = "Propose"
        '
        'GCPropose
        '
        Me.GCPropose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPropose.Location = New System.Drawing.Point(0, 42)
        Me.GCPropose.MainView = Me.GVPropose
        Me.GCPropose.Name = "GCPropose"
        Me.GCPropose.Size = New System.Drawing.Size(654, 404)
        Me.GCPropose.TabIndex = 2
        Me.GCPropose.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPropose})
        '
        'GVPropose
        '
        Me.GVPropose.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_b_revenue_propose, Me.GridColumnnumber, Me.GridColumnyear, Me.GridColumntotal, Me.GridColumncreated_date, Me.GridColumncreated_user, Me.GridColumnnote, Me.GridColumnid_report_status, Me.GridColumnreport_status, Me.GridColumnis_confirm})
        Me.GVPropose.GridControl = Me.GCPropose
        Me.GVPropose.Name = "GVPropose"
        Me.GVPropose.OptionsBehavior.Editable = False
        Me.GVPropose.OptionsFind.AlwaysVisible = True
        Me.GVPropose.OptionsView.ColumnAutoWidth = False
        Me.GVPropose.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_b_revenue_propose
        '
        Me.GridColumnid_b_revenue_propose.Caption = "id_b_revenue_propose"
        Me.GridColumnid_b_revenue_propose.FieldName = "id_b_revenue_propose"
        Me.GridColumnid_b_revenue_propose.Name = "GridColumnid_b_revenue_propose"
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        '
        'GridColumnyear
        '
        Me.GridColumnyear.Caption = "Year"
        Me.GridColumnyear.FieldName = "year"
        Me.GridColumnyear.Name = "GridColumnyear"
        Me.GridColumnyear.Visible = True
        Me.GridColumnyear.VisibleIndex = 1
        '
        'GridColumntotal
        '
        Me.GridColumntotal.Caption = "Total Target"
        Me.GridColumntotal.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal.FieldName = "total"
        Me.GridColumntotal.Name = "GridColumntotal"
        Me.GridColumntotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N0}")})
        Me.GridColumntotal.Visible = True
        Me.GridColumntotal.VisibleIndex = 4
        '
        'GridColumncreated_date
        '
        Me.GridColumncreated_date.Caption = "Created Date"
        Me.GridColumncreated_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumncreated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumncreated_date.FieldName = "created_date"
        Me.GridColumncreated_date.Name = "GridColumncreated_date"
        Me.GridColumncreated_date.Visible = True
        Me.GridColumncreated_date.VisibleIndex = 2
        '
        'GridColumncreated_user
        '
        Me.GridColumncreated_user.Caption = "Created By"
        Me.GridColumncreated_user.FieldName = "created_user"
        Me.GridColumncreated_user.Name = "GridColumncreated_user"
        Me.GridColumncreated_user.Visible = True
        Me.GridColumncreated_user.VisibleIndex = 3
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        '
        'GridColumnid_report_status
        '
        Me.GridColumnid_report_status.Caption = "id_report_status"
        Me.GridColumnid_report_status.FieldName = "id_report_status"
        Me.GridColumnid_report_status.Name = "GridColumnid_report_status"
        '
        'GridColumnreport_status
        '
        Me.GridColumnreport_status.Caption = "Status"
        Me.GridColumnreport_status.FieldName = "report_status"
        Me.GridColumnreport_status.Name = "GridColumnreport_status"
        Me.GridColumnreport_status.Visible = True
        Me.GridColumnreport_status.VisibleIndex = 5
        '
        'GridColumnis_confirm
        '
        Me.GridColumnis_confirm.Caption = "is_confirm"
        Me.GridColumnis_confirm.FieldName = "is_confirm"
        Me.GridColumnis_confirm.Name = "GridColumnis_confirm"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BtnCreateNew)
        Me.PanelControl2.Controls.Add(Me.PanelControl3)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(654, 42)
        Me.PanelControl2.TabIndex = 1
        '
        'BtnCreateNew
        '
        Me.BtnCreateNew.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnCreateNew.Image = CType(resources.GetObject("BtnCreateNew.Image"), System.Drawing.Image)
        Me.BtnCreateNew.Location = New System.Drawing.Point(2, 2)
        Me.BtnCreateNew.Name = "BtnCreateNew"
        Me.BtnCreateNew.Size = New System.Drawing.Size(146, 38)
        Me.BtnCreateNew.TabIndex = 3
        Me.BtnCreateNew.Text = "Create New Propose"
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.BtnViewPropose)
        Me.PanelControl3.Controls.Add(Me.SLEYearPropose)
        Me.PanelControl3.Controls.Add(Me.LabelControl1)
        Me.PanelControl3.Controls.Add(Me.BtnPrint)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl3.Location = New System.Drawing.Point(267, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(385, 38)
        Me.PanelControl3.TabIndex = 2
        '
        'BtnViewPropose
        '
        Me.BtnViewPropose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnViewPropose.Image = CType(resources.GetObject("BtnViewPropose.Image"), System.Drawing.Image)
        Me.BtnViewPropose.Location = New System.Drawing.Point(184, 0)
        Me.BtnViewPropose.Name = "BtnViewPropose"
        Me.BtnViewPropose.Size = New System.Drawing.Size(117, 38)
        Me.BtnViewPropose.TabIndex = 2
        Me.BtnViewPropose.Text = "View Propose"
        '
        'SLEYearPropose
        '
        Me.SLEYearPropose.Location = New System.Drawing.Point(37, 10)
        Me.SLEYearPropose.Name = "SLEYearPropose"
        Me.SLEYearPropose.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEYearPropose.Properties.NullText = "- Select Year -"
        Me.SLEYearPropose.Properties.ShowClearButton = False
        Me.SLEYearPropose.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEYearPropose.Size = New System.Drawing.Size(140, 20)
        Me.SLEYearPropose.TabIndex = 2
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(9, 13)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Year"
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(301, 0)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(84, 38)
        Me.BtnPrint.TabIndex = 3
        Me.BtnPrint.Text = "Print"
        '
        'FormTargetSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 474)
        Me.Controls.Add(Me.XTCSalesTarget)
        Me.MinimizeBox = False
        Me.Name = "FormTargetSales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Target"
        CType(Me.XTCSalesTarget, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCSalesTarget.ResumeLayout(False)
        Me.XTPList.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPPropose.ResumeLayout(False)
        CType(Me.GCPropose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPropose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.SLEYearPropose.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCSalesTarget As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents XTPPropose As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnViewPropose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEYearPropose As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCreateNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCPropose As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPropose As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_b_revenue_propose As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnyear As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_user As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_report_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnis_confirm As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEYear As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
End Class
