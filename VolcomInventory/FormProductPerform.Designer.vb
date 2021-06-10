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
        Me.SBExportExcel = New DevExpress.XtraEditors.SimpleButton()
        Me.SBView = New DevExpress.XtraEditors.SimpleButton()
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
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.XTCData = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPeriod = New DevExpress.XtraTab.XtraTabPage()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPStore = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SLUECompGroup = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView11 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.SLUEProvince = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView10 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPDesign = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControlTop = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LEArea.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUEMonthTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUEMonthFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.XTPPeriod.SuspendLayout()
        Me.XTPStore.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.SLUECompGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUEProvince.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlTop.SuspendLayout()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBExportExcel)
        Me.PanelControl1.Controls.Add(Me.SBView)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl1.Location = New System.Drawing.Point(851, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(105, 165)
        Me.PanelControl1.TabIndex = 1
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
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(11, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl1.TabIndex = 28
        Me.LabelControl1.Text = "Area"
        '
        'LEArea
        '
        Me.LEArea.Location = New System.Drawing.Point(84, 11)
        Me.LEArea.Name = "LEArea"
        Me.LEArea.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEArea.Size = New System.Drawing.Size(171, 20)
        Me.LEArea.TabIndex = 27
        '
        'SLUEMonthTo
        '
        Me.SLUEMonthTo.Location = New System.Drawing.Point(11, 80)
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
        Me.SLUEMonthFrom.Location = New System.Drawing.Point(11, 35)
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
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 165)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(956, 342)
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
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.Location = New System.Drawing.Point(0, 0)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPPeriod
        Me.XTCData.Size = New System.Drawing.Size(956, 165)
        Me.XTCData.TabIndex = 29
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPeriod, Me.XTPStore, Me.XTPDesign})
        '
        'XTPPeriod
        '
        Me.XTPPeriod.Controls.Add(Me.LabelControl3)
        Me.XTPPeriod.Controls.Add(Me.LabelControl2)
        Me.XTPPeriod.Controls.Add(Me.SLUEMonthTo)
        Me.XTPPeriod.Controls.Add(Me.SLUEMonthFrom)
        Me.XTPPeriod.Name = "XTPPeriod"
        Me.XTPPeriod.Size = New System.Drawing.Size(950, 137)
        Me.XTPPeriod.Text = "Filter by Period"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(11, 61)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl3.TabIndex = 30
        Me.LabelControl3.Text = "Until"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(11, 16)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl2.TabIndex = 29
        Me.LabelControl2.Text = "From"
        '
        'XTPStore
        '
        Me.XTPStore.Controls.Add(Me.PanelControl3)
        Me.XTPStore.Controls.Add(Me.PanelControl2)
        Me.XTPStore.Name = "XTPStore"
        Me.XTPStore.Size = New System.Drawing.Size(950, 137)
        Me.XTPStore.Text = "Filter by Store"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.PanelControl4)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl3.Location = New System.Drawing.Point(271, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(679, 137)
        Me.PanelControl3.TabIndex = 40
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.LEArea)
        Me.PanelControl2.Controls.Add(Me.SLUECompGroup)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.Label11)
        Me.PanelControl2.Controls.Add(Me.Label10)
        Me.PanelControl2.Controls.Add(Me.SLUEProvince)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(271, 137)
        Me.PanelControl2.TabIndex = 39
        '
        'SLUECompGroup
        '
        Me.SLUECompGroup.Location = New System.Drawing.Point(84, 63)
        Me.SLUECompGroup.Name = "SLUECompGroup"
        Me.SLUECompGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUECompGroup.Properties.View = Me.GridView11
        Me.SLUECompGroup.Size = New System.Drawing.Size(171, 20)
        Me.SLUECompGroup.TabIndex = 38
        '
        'GridView11
        '
        Me.GridView11.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn21, Me.GridColumn22})
        Me.GridView11.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView11.Name = "GridView11"
        Me.GridView11.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView11.OptionsView.ShowGroupPanel = False
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "GridColumn23"
        Me.GridColumn21.FieldName = "id_comp_group"
        Me.GridColumn21.Name = "GridColumn21"
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Group Store"
        Me.GridColumn22.FieldName = "comp_group"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 66)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 13)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Group Store"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "Province"
        '
        'SLUEProvince
        '
        Me.SLUEProvince.Location = New System.Drawing.Point(84, 37)
        Me.SLUEProvince.Name = "SLUEProvince"
        Me.SLUEProvince.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEProvince.Properties.View = Me.GridView10
        Me.SLUEProvince.Size = New System.Drawing.Size(171, 20)
        Me.SLUEProvince.TabIndex = 36
        '
        'GridView10
        '
        Me.GridView10.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn17, Me.GridColumn18})
        Me.GridView10.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView10.Name = "GridView10"
        Me.GridView10.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView10.OptionsView.ShowGroupPanel = False
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "GridColumn19"
        Me.GridColumn17.FieldName = "id_province"
        Me.GridColumn17.Name = "GridColumn17"
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Province"
        Me.GridColumn18.FieldName = "province"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 0
        '
        'XTPDesign
        '
        Me.XTPDesign.Name = "XTPDesign"
        Me.XTPDesign.Size = New System.Drawing.Size(950, 137)
        Me.XTPDesign.Text = "Filter by Product"
        '
        'PanelControlTop
        '
        Me.PanelControlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlTop.Controls.Add(Me.PanelControl1)
        Me.PanelControlTop.Controls.Add(Me.XTCData)
        Me.PanelControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlTop.Name = "PanelControlTop"
        Me.PanelControlTop.Size = New System.Drawing.Size(956, 165)
        Me.PanelControlTop.TabIndex = 30
        '
        'PanelControl4
        '
        Me.PanelControl4.Location = New System.Drawing.Point(169, 29)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(200, 23)
        Me.PanelControl4.TabIndex = 0
        '
        'FormProductPerform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 507)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControlTop)
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
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.XTPPeriod.ResumeLayout(False)
        Me.XTPPeriod.PerformLayout()
        Me.XTPStore.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.SLUECompGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUEProvince.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlTop.ResumeLayout(False)
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPeriod As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XTPStore As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPDesign As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControlTop As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLUEProvince As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView10 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label10 As Label
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLUECompGroup As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView11 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label11 As Label
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
End Class
