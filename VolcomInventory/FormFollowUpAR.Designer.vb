<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFollowUpAR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFollowUpAR))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEStoreGroup = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.XTCAR = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_follow_up_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_comp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumngroup = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumngroup_description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndue_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnfollow_up = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnfollow_up_result = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnfollow_up_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnfollow_up_input = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPInvoiceOpen = New DevExpress.XtraTab.XtraTabPage()
        Me.GCActive = New DevExpress.XtraGrid.GridControl()
        Me.GVActive = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCAR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCAR.SuspendLayout()
        Me.XTPList.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPInvoiceOpen.SuspendLayout()
        CType(Me.GCActive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVActive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BView)
        Me.PanelControl1.Controls.Add(Me.SLEStoreGroup)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1019, 43)
        Me.PanelControl1.TabIndex = 4
        '
        'BView
        '
        Me.BView.Image = CType(resources.GetObject("BView.Image"), System.Drawing.Image)
        Me.BView.Location = New System.Drawing.Point(231, 11)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(60, 20)
        Me.BView.TabIndex = 8928
        Me.BView.Text = "View"
        '
        'SLEStoreGroup
        '
        Me.SLEStoreGroup.Location = New System.Drawing.Point(80, 11)
        Me.SLEStoreGroup.Name = "SLEStoreGroup"
        Me.SLEStoreGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStoreGroup.Properties.View = Me.GridView3
        Me.SLEStoreGroup.Size = New System.Drawing.Size(145, 20)
        Me.SLEStoreGroup.TabIndex = 8927
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumncomp_group, Me.GridColumndescription})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "id_comp_group"
        Me.GridColumn1.FieldName = "id_comp_group"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumncomp_group
        '
        Me.GridColumncomp_group.Caption = "Group"
        Me.GridColumncomp_group.FieldName = "comp_group"
        Me.GridColumncomp_group.Name = "GridColumncomp_group"
        Me.GridColumncomp_group.Visible = True
        Me.GridColumncomp_group.VisibleIndex = 0
        '
        'GridColumndescription
        '
        Me.GridColumndescription.Caption = "Description"
        Me.GridColumndescription.FieldName = "description"
        Me.GridColumndescription.Name = "GridColumndescription"
        Me.GridColumndescription.Visible = True
        Me.GridColumndescription.VisibleIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(16, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl1.TabIndex = 8926
        Me.LabelControl1.Text = "Store Group"
        '
        'XTCAR
        '
        Me.XTCAR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCAR.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCAR.Location = New System.Drawing.Point(0, 43)
        Me.XTCAR.Name = "XTCAR"
        Me.XTCAR.SelectedTabPage = Me.XTPList
        Me.XTCAR.Size = New System.Drawing.Size(1019, 485)
        Me.XTCAR.TabIndex = 5
        Me.XTCAR.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPList, Me.XTPInvoiceOpen})
        '
        'XTPList
        '
        Me.XTPList.Controls.Add(Me.GCData)
        Me.XTPList.Name = "XTPList"
        Me.XTPList.Size = New System.Drawing.Size(1013, 457)
        Me.XTPList.Text = "List"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(1013, 457)
        Me.GCData.TabIndex = 5
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_follow_up_ar, Me.GridColumnid_comp_group, Me.GridColumngroup, Me.GridColumngroup_description, Me.GridColumndue_date, Me.GridColumnfollow_up, Me.GridColumnfollow_up_result, Me.GridColumnfollow_up_date, Me.GridColumnfollow_up_input})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_rec", Nothing, "{0:N2}")})
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupedColumns = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_follow_up_ar
        '
        Me.GridColumnid_follow_up_ar.Caption = "id_follow_up_ar"
        Me.GridColumnid_follow_up_ar.FieldName = "id_follow_up_ar"
        Me.GridColumnid_follow_up_ar.Name = "GridColumnid_follow_up_ar"
        '
        'GridColumnid_comp_group
        '
        Me.GridColumnid_comp_group.Caption = "id_comp_group"
        Me.GridColumnid_comp_group.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group.Name = "GridColumnid_comp_group"
        '
        'GridColumngroup
        '
        Me.GridColumngroup.Caption = "Group"
        Me.GridColumngroup.FieldName = "group"
        Me.GridColumngroup.Name = "GridColumngroup"
        Me.GridColumngroup.Visible = True
        Me.GridColumngroup.VisibleIndex = 0
        '
        'GridColumngroup_description
        '
        Me.GridColumngroup_description.Caption = "Group Description"
        Me.GridColumngroup_description.FieldName = "group_description"
        Me.GridColumngroup_description.Name = "GridColumngroup_description"
        Me.GridColumngroup_description.Visible = True
        Me.GridColumngroup_description.VisibleIndex = 1
        '
        'GridColumndue_date
        '
        Me.GridColumndue_date.Caption = "Due Date"
        Me.GridColumndue_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumndue_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumndue_date.FieldName = "due_date"
        Me.GridColumndue_date.Name = "GridColumndue_date"
        Me.GridColumndue_date.Visible = True
        Me.GridColumndue_date.VisibleIndex = 2
        '
        'GridColumnfollow_up
        '
        Me.GridColumnfollow_up.Caption = "Follow Up"
        Me.GridColumnfollow_up.FieldName = "follow_up"
        Me.GridColumnfollow_up.Name = "GridColumnfollow_up"
        Me.GridColumnfollow_up.Visible = True
        Me.GridColumnfollow_up.VisibleIndex = 3
        '
        'GridColumnfollow_up_result
        '
        Me.GridColumnfollow_up_result.Caption = "Follow Up Result"
        Me.GridColumnfollow_up_result.FieldName = "follow_up_result"
        Me.GridColumnfollow_up_result.Name = "GridColumnfollow_up_result"
        Me.GridColumnfollow_up_result.Visible = True
        Me.GridColumnfollow_up_result.VisibleIndex = 4
        '
        'GridColumnfollow_up_date
        '
        Me.GridColumnfollow_up_date.Caption = "Date"
        Me.GridColumnfollow_up_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnfollow_up_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnfollow_up_date.FieldName = "follow_up_date"
        Me.GridColumnfollow_up_date.Name = "GridColumnfollow_up_date"
        Me.GridColumnfollow_up_date.Visible = True
        Me.GridColumnfollow_up_date.VisibleIndex = 5
        '
        'GridColumnfollow_up_input
        '
        Me.GridColumnfollow_up_input.Caption = "Updated at"
        Me.GridColumnfollow_up_input.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumnfollow_up_input.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnfollow_up_input.FieldName = "follow_up_input"
        Me.GridColumnfollow_up_input.Name = "GridColumnfollow_up_input"
        Me.GridColumnfollow_up_input.Visible = True
        Me.GridColumnfollow_up_input.VisibleIndex = 6
        '
        'XTPInvoiceOpen
        '
        Me.XTPInvoiceOpen.Controls.Add(Me.GCActive)
        Me.XTPInvoiceOpen.Name = "XTPInvoiceOpen"
        Me.XTPInvoiceOpen.Size = New System.Drawing.Size(1013, 457)
        Me.XTPInvoiceOpen.Text = "Current Invoice Open"
        '
        'GCActive
        '
        Me.GCActive.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCActive.Location = New System.Drawing.Point(0, 0)
        Me.GCActive.MainView = Me.GVActive
        Me.GCActive.Name = "GCActive"
        Me.GCActive.Size = New System.Drawing.Size(1013, 457)
        Me.GCActive.TabIndex = 0
        Me.GCActive.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVActive})
        '
        'GVActive
        '
        Me.GVActive.GridControl = Me.GCActive
        Me.GVActive.Name = "GVActive"
        Me.GVActive.OptionsView.ShowGroupPanel = False
        '
        'FormFollowUpAR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1019, 528)
        Me.Controls.Add(Me.XTCAR)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormFollowUpAR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Follow Up AR"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCAR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCAR.ResumeLayout(False)
        Me.XTPList.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPInvoiceOpen.ResumeLayout(False)
        CType(Me.GCActive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVActive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents XTCAR As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPInvoiceOpen As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_follow_up_ar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_comp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumngroup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumngroup_description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndue_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnfollow_up As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnfollow_up_result As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnfollow_up_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnfollow_up_input As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEStoreGroup As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCActive As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVActive As DevExpress.XtraGrid.Views.Grid.GridView
End Class
