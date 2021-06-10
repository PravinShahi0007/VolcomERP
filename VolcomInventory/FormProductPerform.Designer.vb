<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductPerform
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProductPerform))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LEArea = New DevExpress.XtraEditors.LookUpEdit()
        Me.SLUEMonthTo = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLUEMonthFrom = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SBExportExcel = New DevExpress.XtraEditors.SimpleButton()
        Me.SBView = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPeriod = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPStore = New DevExpress.XtraTab.XtraTabPage()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.Top = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPDesign = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LEArea.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUEMonthTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUEMonthFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPPeriod.SuspendLayout()
        Me.XTPStore.SuspendLayout()
        CType(Me.Top, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Top.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBExportExcel)
        Me.PanelControl1.Controls.Add(Me.SBView)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl1.Location = New System.Drawing.Point(851, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(105, 144)
        Me.PanelControl1.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(20, 27)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl1.TabIndex = 28
        Me.LabelControl1.Text = "Area"
        '
        'LEArea
        '
        Me.LEArea.Location = New System.Drawing.Point(49, 24)
        Me.LEArea.Name = "LEArea"
        Me.LEArea.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEArea.Size = New System.Drawing.Size(171, 20)
        Me.LEArea.TabIndex = 27
        '
        'SLUEMonthTo
        '
        Me.SLUEMonthTo.Location = New System.Drawing.Point(61, 39)
        Me.SLUEMonthTo.Name = "SLUEMonthTo"
        Me.SLUEMonthTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEMonthTo.Properties.View = Me.GridView6
        Me.SLUEMonthTo.Size = New System.Drawing.Size(362, 20)
        Me.SLUEMonthTo.TabIndex = 26
        '
        'GridView6
        '
        Me.GridView6.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn13, Me.GridColumn14})
        Me.GridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView6.Name = "GridView6"
        Me.GridView6.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView6.OptionsView.ShowGroupPanel = False
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "GridColumn12"
        Me.GridColumn13.FieldName = "month_code"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Month"
        Me.GridColumn14.FieldName = "month"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        '
        'SLUEMonthFrom
        '
        Me.SLUEMonthFrom.Location = New System.Drawing.Point(61, 13)
        Me.SLUEMonthFrom.Name = "SLUEMonthFrom"
        Me.SLUEMonthFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEMonthFrom.Properties.View = Me.GridView5
        Me.SLUEMonthFrom.Size = New System.Drawing.Size(362, 20)
        Me.SLUEMonthFrom.TabIndex = 20
        '
        'GridView5
        '
        Me.GridView5.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn12, Me.GridColumn11})
        Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView5.OptionsView.ShowGroupPanel = False
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "GridColumn12"
        Me.GridColumn12.FieldName = "month_code"
        Me.GridColumn12.Name = "GridColumn12"
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Month"
        Me.GridColumn11.FieldName = "month"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 0
        '
        'SBExportExcel
        '
        Me.SBExportExcel.Dock = System.Windows.Forms.DockStyle.Top
        Me.SBExportExcel.Image = CType(resources.GetObject("SBExportExcel.Image"), System.Drawing.Image)
        Me.SBExportExcel.Location = New System.Drawing.Point(2, 28)
        Me.SBExportExcel.Name = "SBExportExcel"
        Me.SBExportExcel.Size = New System.Drawing.Size(101, 29)
        Me.SBExportExcel.TabIndex = 2
        Me.SBExportExcel.Text = "Export Excel"
        '
        'SBView
        '
        Me.SBView.Dock = System.Windows.Forms.DockStyle.Top
        Me.SBView.Image = CType(resources.GetObject("SBView.Image"), System.Drawing.Image)
        Me.SBView.Location = New System.Drawing.Point(2, 2)
        Me.SBView.Name = "SBView"
        Me.SBView.Size = New System.Drawing.Size(101, 26)
        Me.SBView.TabIndex = 0
        Me.SBView.Text = "View"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 144)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(956, 363)
        Me.GCData.TabIndex = 2
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPPeriod
        Me.XtraTabControl1.Size = New System.Drawing.Size(956, 144)
        Me.XtraTabControl1.TabIndex = 29
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPeriod, Me.XTPStore, Me.XTPDesign})
        '
        'XTPPeriod
        '
        Me.XTPPeriod.Controls.Add(Me.LabelControl3)
        Me.XTPPeriod.Controls.Add(Me.LabelControl2)
        Me.XTPPeriod.Controls.Add(Me.SLUEMonthTo)
        Me.XTPPeriod.Controls.Add(Me.SLUEMonthFrom)
        Me.XTPPeriod.Name = "XTPPeriod"
        Me.XTPPeriod.Size = New System.Drawing.Size(950, 116)
        Me.XTPPeriod.Text = "Filter by Period"
        '
        'XTPStore
        '
        Me.XTPStore.Controls.Add(Me.LEArea)
        Me.XTPStore.Controls.Add(Me.LabelControl1)
        Me.XTPStore.Name = "XTPStore"
        Me.XTPStore.Size = New System.Drawing.Size(950, 116)
        Me.XTPStore.Text = "Filter by Store"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(11, 16)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl2.TabIndex = 29
        Me.LabelControl2.Text = "From"
        '
        'Top
        '
        Me.Top.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.Top.Controls.Add(Me.PanelControl1)
        Me.Top.Controls.Add(Me.XtraTabControl1)
        Me.Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.Top.Location = New System.Drawing.Point(0, 0)
        Me.Top.Name = "Top"
        Me.Top.Size = New System.Drawing.Size(956, 144)
        Me.Top.TabIndex = 30
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(11, 42)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl3.TabIndex = 30
        Me.LabelControl3.Text = "Until"
        '
        'XTPDesign
        '
        Me.XTPDesign.Name = "XTPDesign"
        Me.XTPDesign.Size = New System.Drawing.Size(0, 0)
        Me.XTPDesign.Text = "Filter by Product"
        '
        'FormProductPerform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 507)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.Top)
        Me.Name = "FormProductPerform"
        Me.Text = "FormProductPerform"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LEArea.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUEMonthTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUEMonthFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPPeriod.ResumeLayout(False)
        Me.XTPPeriod.PerformLayout()
        Me.XTPStore.ResumeLayout(False)
        Me.XTPStore.PerformLayout()
        CType(Me.Top, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Top.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLUEMonthTo As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLUEMonthFrom As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SBExportExcel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEArea As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPeriod As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XTPStore As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPDesign As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Top As DevExpress.XtraEditors.PanelControl
End Class
