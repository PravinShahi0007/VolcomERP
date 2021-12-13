<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSOPIndex
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSOPIndex))
        Me.XTCSOPIndex = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPBySOP = New DevExpress.XtraTab.XtraTabPage()
        Me.GCBySOP = New DevExpress.XtraGrid.GridControl()
        Me.GVBySOP = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoLinkFile = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoLinkMenuERP = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.BNewSOP = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPByModul = New DevExpress.XtraTab.XtraTabPage()
        Me.GCByModul = New DevExpress.XtraGrid.GridControl()
        Me.GVByModul = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemHyperLinkEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemHyperLinkEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BRefresh = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.XTCSOPIndex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCSOPIndex.SuspendLayout()
        Me.XTPBySOP.SuspendLayout()
        CType(Me.GCBySOP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBySOP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoLinkFile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoLinkMenuERP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPByModul.SuspendLayout()
        CType(Me.GCByModul, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVByModul, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCSOPIndex
        '
        Me.XTCSOPIndex.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCSOPIndex.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCSOPIndex.Location = New System.Drawing.Point(0, 48)
        Me.XTCSOPIndex.Name = "XTCSOPIndex"
        Me.XTCSOPIndex.SelectedTabPage = Me.XTPBySOP
        Me.XTCSOPIndex.Size = New System.Drawing.Size(1046, 520)
        Me.XTCSOPIndex.TabIndex = 0
        Me.XTCSOPIndex.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPBySOP, Me.XTPByModul})
        '
        'XTPBySOP
        '
        Me.XTPBySOP.Controls.Add(Me.GCBySOP)
        Me.XTPBySOP.Controls.Add(Me.BNewSOP)
        Me.XTPBySOP.Name = "XTPBySOP"
        Me.XTPBySOP.Size = New System.Drawing.Size(1040, 492)
        Me.XTPBySOP.Text = "By SOP"
        '
        'GCBySOP
        '
        Me.GCBySOP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBySOP.Location = New System.Drawing.Point(0, 0)
        Me.GCBySOP.MainView = Me.GVBySOP
        Me.GCBySOP.Name = "GCBySOP"
        Me.GCBySOP.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepoLinkFile, Me.RepoLinkMenuERP})
        Me.GCBySOP.Size = New System.Drawing.Size(1040, 452)
        Me.GCBySOP.TabIndex = 0
        Me.GCBySOP.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBySOP})
        '
        'GVBySOP
        '
        Me.GVBySOP.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn6, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4})
        Me.GVBySOP.GridControl = Me.GCBySOP
        Me.GVBySOP.Name = "GVBySOP"
        Me.GVBySOP.OptionsBehavior.ReadOnly = True
        Me.GVBySOP.OptionsView.AllowCellMerge = True
        Me.GVBySOP.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_sop"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Departement"
        Me.GridColumn6.FieldName = "departement"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "SOP"
        Me.GridColumn2.FieldName = "sop_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "File SOP"
        Me.GridColumn3.ColumnEdit = Me.RepoLinkFile
        Me.GridColumn3.FieldName = "doc_desc"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'RepoLinkFile
        '
        Me.RepoLinkFile.AutoHeight = False
        Me.RepoLinkFile.Name = "RepoLinkFile"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Menu ERP"
        Me.GridColumn4.ColumnEdit = Me.RepoLinkMenuERP
        Me.GridColumn4.FieldName = "menu_caption"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        '
        'RepoLinkMenuERP
        '
        Me.RepoLinkMenuERP.AutoHeight = False
        Me.RepoLinkMenuERP.Name = "RepoLinkMenuERP"
        '
        'BNewSOP
        '
        Me.BNewSOP.Appearance.BackColor = System.Drawing.Color.DarkBlue
        Me.BNewSOP.Appearance.ForeColor = System.Drawing.Color.White
        Me.BNewSOP.Appearance.Options.UseBackColor = True
        Me.BNewSOP.Appearance.Options.UseForeColor = True
        Me.BNewSOP.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BNewSOP.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BNewSOP.Location = New System.Drawing.Point(0, 452)
        Me.BNewSOP.Name = "BNewSOP"
        Me.BNewSOP.Size = New System.Drawing.Size(1040, 40)
        Me.BNewSOP.TabIndex = 7
        Me.BNewSOP.Text = "New SOP"
        '
        'XTPByModul
        '
        Me.XTPByModul.Controls.Add(Me.GCByModul)
        Me.XTPByModul.Name = "XTPByModul"
        Me.XTPByModul.Size = New System.Drawing.Size(1040, 492)
        Me.XTPByModul.Text = "By Modul ERP"
        '
        'GCByModul
        '
        Me.GCByModul.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCByModul.Location = New System.Drawing.Point(0, 0)
        Me.GCByModul.MainView = Me.GVByModul
        Me.GCByModul.Name = "GCByModul"
        Me.GCByModul.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemHyperLinkEdit1, Me.RepositoryItemHyperLinkEdit2})
        Me.GCByModul.Size = New System.Drawing.Size(1040, 492)
        Me.GCByModul.TabIndex = 1
        Me.GCByModul.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVByModul})
        '
        'GVByModul
        '
        Me.GVByModul.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn5, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10})
        Me.GVByModul.GridControl = Me.GCByModul
        Me.GVByModul.Name = "GVByModul"
        Me.GVByModul.OptionsBehavior.ReadOnly = True
        Me.GVByModul.OptionsView.AllowCellMerge = True
        Me.GVByModul.OptionsView.ShowGroupPanel = False
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "ID"
        Me.GridColumn5.FieldName = "id_sop"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Departement"
        Me.GridColumn7.FieldName = "departement"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 2
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "SOP"
        Me.GridColumn8.FieldName = "sop_name"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "File SOP"
        Me.GridColumn9.ColumnEdit = Me.RepositoryItemHyperLinkEdit1
        Me.GridColumn9.FieldName = "doc_desc"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 3
        '
        'RepositoryItemHyperLinkEdit1
        '
        Me.RepositoryItemHyperLinkEdit1.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit1.Name = "RepositoryItemHyperLinkEdit1"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Menu ERP"
        Me.GridColumn10.ColumnEdit = Me.RepositoryItemHyperLinkEdit2
        Me.GridColumn10.FieldName = "menu_caption"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        '
        'RepositoryItemHyperLinkEdit2
        '
        Me.RepositoryItemHyperLinkEdit2.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit2.Name = "RepositoryItemHyperLinkEdit2"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BRefresh)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1046, 48)
        Me.PanelControl1.TabIndex = 1
        '
        'BRefresh
        '
        Me.BRefresh.Dock = System.Windows.Forms.DockStyle.Right
        Me.BRefresh.Image = CType(resources.GetObject("BRefresh.Image"), System.Drawing.Image)
        Me.BRefresh.Location = New System.Drawing.Point(928, 2)
        Me.BRefresh.Name = "BRefresh"
        Me.BRefresh.Size = New System.Drawing.Size(116, 44)
        Me.BRefresh.TabIndex = 1
        Me.BRefresh.Text = "Refresh"
        '
        'FormSOPIndex
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1046, 568)
        Me.ControlBox = False
        Me.Controls.Add(Me.XTCSOPIndex)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSOPIndex"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Index SOP"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.XTCSOPIndex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCSOPIndex.ResumeLayout(False)
        Me.XTPBySOP.ResumeLayout(False)
        CType(Me.GCBySOP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBySOP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoLinkFile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoLinkMenuERP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPByModul.ResumeLayout(False)
        CType(Me.GCByModul, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVByModul, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCSOPIndex As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPBySOP As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPByModul As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCBySOP As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBySOP As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BNewSOP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RepoLinkFile As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents RepoLinkMenuERP As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents GCByModul As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVByModul As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemHyperLinkEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemHyperLinkEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
End Class
