<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPolis
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPolis))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.GCPolisToko = New DevExpress.XtraGrid.GridControl()
        Me.GVPolisToko = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTCPolis = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPToko = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPFixedAsset = New DevExpress.XtraTab.XtraTabPage()
        Me.BExpiredSoon = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCPolisToko, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPolisToko, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCPolis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPolis.SuspendLayout()
        Me.XTPToko.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BExpiredSoon)
        Me.PanelControl1.Controls.Add(Me.BRefresh)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1009, 46)
        Me.PanelControl1.TabIndex = 0
        '
        'BRefresh
        '
        Me.BRefresh.Dock = System.Windows.Forms.DockStyle.Right
        Me.BRefresh.Image = CType(resources.GetObject("BRefresh.Image"), System.Drawing.Image)
        Me.BRefresh.ImageIndex = 13
        Me.BRefresh.Location = New System.Drawing.Point(885, 2)
        Me.BRefresh.Name = "BRefresh"
        Me.BRefresh.Size = New System.Drawing.Size(122, 42)
        Me.BRefresh.TabIndex = 18
        Me.BRefresh.TabStop = False
        Me.BRefresh.Text = "Show All"
        '
        'GCPolisToko
        '
        Me.GCPolisToko.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPolisToko.Location = New System.Drawing.Point(0, 0)
        Me.GCPolisToko.MainView = Me.GVPolisToko
        Me.GCPolisToko.Name = "GCPolisToko"
        Me.GCPolisToko.Size = New System.Drawing.Size(1003, 417)
        Me.GCPolisToko.TabIndex = 1
        Me.GCPolisToko.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPolisToko})
        '
        'GVPolisToko
        '
        Me.GVPolisToko.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn10, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9})
        Me.GVPolisToko.GridControl = Me.GCPolisToko
        Me.GVPolisToko.Name = "GVPolisToko"
        Me.GVPolisToko.OptionsView.ShowGroupPanel = False
        Me.GVPolisToko.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn10, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_polis"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Store"
        Me.GridColumn2.FieldName = "polis_object"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 142
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Location"
        Me.GridColumn3.FieldName = "polis_object_location"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 142
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Start Date"
        Me.GridColumn4.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn4.FieldName = "start_date"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 142
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "End Date"
        Me.GridColumn5.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn5.FieldName = "end_date"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        Me.GridColumn5.Width = 142
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Polis By"
        Me.GridColumn6.FieldName = "comp_name_polis"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        Me.GridColumn6.Width = 142
        '
        'XTCPolis
        '
        Me.XTCPolis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCPolis.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCPolis.Location = New System.Drawing.Point(0, 46)
        Me.XTCPolis.Name = "XTCPolis"
        Me.XTCPolis.SelectedTabPage = Me.XTPToko
        Me.XTCPolis.Size = New System.Drawing.Size(1009, 445)
        Me.XTCPolis.TabIndex = 2
        Me.XTCPolis.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPToko, Me.XTPFixedAsset})
        '
        'XTPToko
        '
        Me.XTPToko.Controls.Add(Me.GCPolisToko)
        Me.XTPToko.Name = "XTPToko"
        Me.XTPToko.Size = New System.Drawing.Size(1003, 417)
        Me.XTPToko.Text = "Toko"
        '
        'XTPFixedAsset
        '
        Me.XTPFixedAsset.Name = "XTPFixedAsset"
        Me.XTPFixedAsset.Size = New System.Drawing.Size(1003, 417)
        Me.XTPFixedAsset.Text = "Fixed Asset"
        '
        'BExpiredSoon
        '
        Me.BExpiredSoon.Dock = System.Windows.Forms.DockStyle.Right
        Me.BExpiredSoon.Image = CType(resources.GetObject("BExpiredSoon.Image"), System.Drawing.Image)
        Me.BExpiredSoon.ImageIndex = 13
        Me.BExpiredSoon.Location = New System.Drawing.Point(769, 2)
        Me.BExpiredSoon.Name = "BExpiredSoon"
        Me.BExpiredSoon.Size = New System.Drawing.Size(116, 42)
        Me.BExpiredSoon.TabIndex = 19
        Me.BExpiredSoon.TabStop = False
        Me.BExpiredSoon.Text = "Expired Soon"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Polis Number"
        Me.GridColumn7.FieldName = "polis_number"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 5
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Polis Untuk"
        Me.GridColumn8.FieldName = "polis_untuk"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 7
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Premi"
        Me.GridColumn9.DisplayFormat.FormatString = "N2"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn9.FieldName = "premi"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 8
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Expired In (days)"
        Me.GridColumn10.DisplayFormat.FormatString = "N0"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn10.FieldName = "expired_in"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 6
        '
        'FormPolis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1009, 491)
        Me.Controls.Add(Me.XTCPolis)
        Me.Controls.Add(Me.PanelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPolis"
        Me.Text = "List Polis"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCPolisToko, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPolisToko, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCPolis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCPolis.ResumeLayout(False)
        Me.XTPToko.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCPolisToko As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPolisToko As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTCPolis As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPToko As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPFixedAsset As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents BExpiredSoon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
End Class
