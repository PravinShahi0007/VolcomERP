<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPIBReview
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
        Me.XTPReview = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.XTPInput = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPlan = New DevExpress.XtraGrid.GridControl()
        Me.GVPlan = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BUpdateDuty = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.DEYearInput = New DevExpress.XtraEditors.DateEdit()
        Me.BViewInput = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPReview.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPInput.SuspendLayout()
        CType(Me.GCPlan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPlan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.DEYearInput.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEYearInput.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPReview
        Me.XtraTabControl1.Size = New System.Drawing.Size(1011, 556)
        Me.XtraTabControl1.TabIndex = 1
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPReview, Me.XTPInput})
        '
        'XTPReview
        '
        Me.XTPReview.Controls.Add(Me.GridControl1)
        Me.XTPReview.Controls.Add(Me.PanelControl1)
        Me.XTPReview.Name = "XTPReview"
        Me.XTPReview.Size = New System.Drawing.Size(1005, 528)
        Me.XTPReview.Text = "Summary"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 49)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1005, 479)
        Me.GridControl1.TabIndex = 1
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn13, Me.GridColumn12})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "id"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Budget Number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "PIB Number"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "PIB Date"
        Me.GridColumn4.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'PanelControl1
        '
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1005, 49)
        Me.PanelControl1.TabIndex = 0
        '
        'XTPInput
        '
        Me.XTPInput.Controls.Add(Me.GCPlan)
        Me.XTPInput.Controls.Add(Me.BUpdateDuty)
        Me.XTPInput.Controls.Add(Me.PanelControl2)
        Me.XTPInput.Name = "XTPInput"
        Me.XTPInput.Size = New System.Drawing.Size(1005, 528)
        Me.XTPInput.Text = "Input Perencanaan"
        '
        'GCPlan
        '
        Me.GCPlan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPlan.Location = New System.Drawing.Point(0, 49)
        Me.GCPlan.MainView = Me.GVPlan
        Me.GCPlan.Name = "GCPlan"
        Me.GCPlan.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCPlan.Size = New System.Drawing.Size(1005, 441)
        Me.GCPlan.TabIndex = 2
        Me.GCPlan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPlan})
        '
        'GVPlan
        '
        Me.GVPlan.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn15, Me.GridColumn16, Me.GridColumn17})
        Me.GVPlan.GridControl = Me.GCPlan
        Me.GVPlan.Name = "GVPlan"
        Me.GVPlan.OptionsView.ShowGroupPanel = False
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "ID"
        Me.GridColumn15.FieldName = "id_month"
        Me.GridColumn15.Name = "GridColumn15"
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Month"
        Me.GridColumn16.FieldName = "month_ind"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 0
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Rencana Import"
        Me.GridColumn17.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumn17.FieldName = "rencana_import"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 1
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "no"
        '
        'BUpdateDuty
        '
        Me.BUpdateDuty.Appearance.BackColor = System.Drawing.Color.SlateBlue
        Me.BUpdateDuty.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BUpdateDuty.Appearance.ForeColor = System.Drawing.Color.White
        Me.BUpdateDuty.Appearance.Options.UseBackColor = True
        Me.BUpdateDuty.Appearance.Options.UseFont = True
        Me.BUpdateDuty.Appearance.Options.UseForeColor = True
        Me.BUpdateDuty.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BUpdateDuty.Location = New System.Drawing.Point(0, 490)
        Me.BUpdateDuty.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BUpdateDuty.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BUpdateDuty.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BUpdateDuty.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BUpdateDuty.Name = "BUpdateDuty"
        Me.BUpdateDuty.Size = New System.Drawing.Size(1005, 38)
        Me.BUpdateDuty.TabIndex = 23
        Me.BUpdateDuty.Text = "Update Perencanaan"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.DEYearInput)
        Me.PanelControl2.Controls.Add(Me.BViewInput)
        Me.PanelControl2.Controls.Add(Me.LabelControl4)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1005, 49)
        Me.PanelControl2.TabIndex = 1
        '
        'DEYearInput
        '
        Me.DEYearInput.EditValue = Nothing
        Me.DEYearInput.Location = New System.Drawing.Point(39, 13)
        Me.DEYearInput.Name = "DEYearInput"
        Me.DEYearInput.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEYearInput.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEYearInput.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.DEYearInput.Properties.Mask.EditMask = "yyyy"
        Me.DEYearInput.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEYearInput.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.QuarterView
        Me.DEYearInput.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView
        Me.DEYearInput.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.DEYearInput.Size = New System.Drawing.Size(171, 20)
        Me.DEYearInput.TabIndex = 6
        '
        'BViewInput
        '
        Me.BViewInput.Location = New System.Drawing.Point(220, 11)
        Me.BViewInput.Name = "BViewInput"
        Me.BViewInput.Size = New System.Drawing.Size(55, 23)
        Me.BViewInput.TabIndex = 4
        Me.BViewInput.Text = "view"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(11, 16)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl4.TabIndex = 1
        Me.LabelControl4.Text = "Year"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "PIB Tax Amount"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Second Payment Date Limit"
        Me.GridColumn6.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "First Payment"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 5
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Import Qty"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 6
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Sales Qty"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 7
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Last Update Sales Qty"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 8
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Sales Thru"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 9
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Remaining Payment"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 10
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Second Payment"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 11
        '
        'FormPIBReview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1011, 556)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPIBReview"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Review PIB"
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPReview.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPInput.ResumeLayout(False)
        CType(Me.GCPlan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPlan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.DEYearInput.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEYearInput.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPReview As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents XTPInput As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCPlan As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPlan As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents BUpdateDuty As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEYearInput As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BViewInput As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
End Class
