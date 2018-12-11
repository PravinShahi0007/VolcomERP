<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPurcAsset
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
        Me.XTCAsset = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPending = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPending = New DevExpress.XtraGrid.GridControl()
        Me.GVPending = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnAcqDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnItem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRecNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.XTPActive = New DevExpress.XtraTab.XtraTabPage()
        Me.GCActive = New DevExpress.XtraGrid.GridControl()
        Me.GVActive = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XTPSold = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XTPDepresiasi = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RecordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCAsset, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCAsset.SuspendLayout()
        Me.XTPPending.SuspendLayout()
        CType(Me.GCPending, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPending, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPActive.SuspendLayout()
        CType(Me.GCActive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVActive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPSold.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPDepresiasi.SuspendLayout()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCAsset
        '
        Me.XTCAsset.AppearancePage.Header.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTCAsset.AppearancePage.Header.Options.UseFont = True
        Me.XTCAsset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCAsset.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCAsset.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal
        Me.XTCAsset.Location = New System.Drawing.Point(0, 0)
        Me.XTCAsset.LookAndFeel.SkinName = "Metropolis"
        Me.XTCAsset.LookAndFeel.UseDefaultLookAndFeel = False
        Me.XTCAsset.Name = "XTCAsset"
        Me.XTCAsset.SelectedTabPage = Me.XTPPending
        Me.XTCAsset.Size = New System.Drawing.Size(777, 471)
        Me.XTCAsset.TabIndex = 0
        Me.XTCAsset.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPending, Me.XTPActive, Me.XTPSold, Me.XTPDepresiasi})
        '
        'XTPPending
        '
        Me.XTPPending.Controls.Add(Me.GCPending)
        Me.XTPPending.Name = "XTPPending"
        Me.XTPPending.Size = New System.Drawing.Size(775, 443)
        Me.XTPPending.Text = "Pending Asset"
        '
        'GCPending
        '
        Me.GCPending.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPending.Location = New System.Drawing.Point(0, 0)
        Me.GCPending.MainView = Me.GVPending
        Me.GCPending.Name = "GCPending"
        Me.GCPending.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1})
        Me.GCPending.Size = New System.Drawing.Size(775, 443)
        Me.GCPending.TabIndex = 0
        Me.GCPending.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPending})
        '
        'GVPending
        '
        Me.GVPending.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnAcqDate, Me.GridColumnItem, Me.GridColumndept, Me.GridColumnRecNumber, Me.GridColumnCost})
        Me.GVPending.GridControl = Me.GCPending
        Me.GVPending.Name = "GVPending"
        Me.GVPending.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVPending.OptionsBehavior.Editable = False
        Me.GVPending.OptionsFind.AlwaysVisible = True
        Me.GVPending.OptionsView.ShowGroupPanel = False
        '
        'GridColumnAcqDate
        '
        Me.GridColumnAcqDate.Caption = "Acquisition Date"
        Me.GridColumnAcqDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnAcqDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnAcqDate.FieldName = "acq_date"
        Me.GridColumnAcqDate.Name = "GridColumnAcqDate"
        Me.GridColumnAcqDate.Visible = True
        Me.GridColumnAcqDate.VisibleIndex = 1
        '
        'GridColumnItem
        '
        Me.GridColumnItem.Caption = "Item"
        Me.GridColumnItem.FieldName = "asset_name"
        Me.GridColumnItem.Name = "GridColumnItem"
        Me.GridColumnItem.Visible = True
        Me.GridColumnItem.VisibleIndex = 2
        '
        'GridColumndept
        '
        Me.GridColumndept.Caption = "Departement"
        Me.GridColumndept.FieldName = "departement"
        Me.GridColumndept.Name = "GridColumndept"
        Me.GridColumndept.Visible = True
        Me.GridColumndept.VisibleIndex = 0
        '
        'GridColumnRecNumber
        '
        Me.GridColumnRecNumber.Caption = "Receive#"
        Me.GridColumnRecNumber.FieldName = "purc_rec_number"
        Me.GridColumnRecNumber.Name = "GridColumnRecNumber"
        Me.GridColumnRecNumber.Visible = True
        Me.GridColumnRecNumber.VisibleIndex = 3
        '
        'GridColumnCost
        '
        Me.GridColumnCost.Caption = "Acquisition Cost"
        Me.GridColumnCost.DisplayFormat.FormatString = "N2"
        Me.GridColumnCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCost.FieldName = "acq_cost"
        Me.GridColumnCost.Name = "GridColumnCost"
        Me.GridColumnCost.Visible = True
        Me.GridColumnCost.VisibleIndex = 4
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'XTPActive
        '
        Me.XTPActive.Controls.Add(Me.GCActive)
        Me.XTPActive.Name = "XTPActive"
        Me.XTPActive.Size = New System.Drawing.Size(775, 443)
        Me.XTPActive.Text = "Active Asset"
        '
        'GCActive
        '
        Me.GCActive.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCActive.Location = New System.Drawing.Point(0, 0)
        Me.GCActive.MainView = Me.GVActive
        Me.GCActive.Name = "GCActive"
        Me.GCActive.Size = New System.Drawing.Size(775, 443)
        Me.GCActive.TabIndex = 1
        Me.GCActive.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVActive})
        '
        'GVActive
        '
        Me.GVActive.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5})
        Me.GVActive.GridControl = Me.GCActive
        Me.GVActive.Name = "GVActive"
        Me.GVActive.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVActive.OptionsBehavior.Editable = False
        Me.GVActive.OptionsFind.AlwaysVisible = True
        Me.GVActive.OptionsView.ShowGroupPanel = False
        '
        'XTPSold
        '
        Me.XTPSold.Controls.Add(Me.GridControl2)
        Me.XTPSold.Name = "XTPSold"
        Me.XTPSold.PageVisible = False
        Me.XTPSold.Size = New System.Drawing.Size(775, 443)
        Me.XTPSold.Text = "Sold/Disposed"
        '
        'GridControl2
        '
        Me.GridControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl2.Location = New System.Drawing.Point(0, 0)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(775, 443)
        Me.GridControl2.TabIndex = 1
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.AutoExpandAllGroups = True
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsFind.AlwaysVisible = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'XTPDepresiasi
        '
        Me.XTPDepresiasi.Controls.Add(Me.GridControl3)
        Me.XTPDepresiasi.Name = "XTPDepresiasi"
        Me.XTPDepresiasi.Size = New System.Drawing.Size(775, 443)
        Me.XTPDepresiasi.Text = "Depreciation"
        '
        'GridControl3
        '
        Me.GridControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl3.Location = New System.Drawing.Point(0, 0)
        Me.GridControl3.MainView = Me.GridView3
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(775, 443)
        Me.GridControl3.TabIndex = 1
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GridControl3
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.AutoExpandAllGroups = True
        Me.GridView3.OptionsBehavior.Editable = False
        Me.GridView3.OptionsFind.AlwaysVisible = True
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RecordToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(112, 26)
        '
        'RecordToolStripMenuItem
        '
        Me.RecordToolStripMenuItem.Name = "RecordToolStripMenuItem"
        Me.RecordToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.RecordToolStripMenuItem.Text = "Record"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Acquisition Date"
        Me.GridColumn1.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn1.FieldName = "acq_date"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Item"
        Me.GridColumn2.FieldName = "asset_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 2
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Departement"
        Me.GridColumn3.FieldName = "departement"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Receive#"
        Me.GridColumn4.FieldName = "purc_rec_number"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Acquisition Cost"
        Me.GridColumn5.DisplayFormat.FormatString = "N2"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "acq_cost"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        '
        'FormPurcAsset
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 471)
        Me.Controls.Add(Me.XTCAsset)
        Me.MinimizeBox = False
        Me.Name = "FormPurcAsset"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asset Management"
        CType(Me.XTCAsset, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCAsset.ResumeLayout(False)
        Me.XTPPending.ResumeLayout(False)
        CType(Me.GCPending, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPending, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPActive.ResumeLayout(False)
        CType(Me.GCActive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVActive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPSold.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPDepresiasi.ResumeLayout(False)
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCAsset As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPending As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCPending As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPending As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XTPActive As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPSold As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPDepresiasi As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCActive As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVActive As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnAcqDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnItem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRecNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents RecordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
End Class
