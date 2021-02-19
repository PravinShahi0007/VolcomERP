<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterItemStockCard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterItemStockCard))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BNewItem = New DevExpress.XtraEditors.SimpleButton()
        Me.BRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.GCItem = New DevExpress.XtraGrid.GridControl()
        Me.GVItem = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RIMDetail = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIMDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BNewItem)
        Me.PanelControl1.Controls.Add(Me.BRefresh)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(886, 49)
        Me.PanelControl1.TabIndex = 0
        '
        'BNewItem
        '
        Me.BNewItem.Dock = System.Windows.Forms.DockStyle.Left
        Me.BNewItem.Image = CType(resources.GetObject("BNewItem.Image"), System.Drawing.Image)
        Me.BNewItem.Location = New System.Drawing.Point(2, 2)
        Me.BNewItem.Name = "BNewItem"
        Me.BNewItem.Size = New System.Drawing.Size(111, 45)
        Me.BNewItem.TabIndex = 1
        Me.BNewItem.Text = "New Item"
        '
        'BRefresh
        '
        Me.BRefresh.Dock = System.Windows.Forms.DockStyle.Right
        Me.BRefresh.Image = CType(resources.GetObject("BRefresh.Image"), System.Drawing.Image)
        Me.BRefresh.Location = New System.Drawing.Point(773, 2)
        Me.BRefresh.Name = "BRefresh"
        Me.BRefresh.Size = New System.Drawing.Size(111, 45)
        Me.BRefresh.TabIndex = 0
        Me.BRefresh.Text = "Refresh"
        '
        'GCItem
        '
        Me.GCItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCItem.Location = New System.Drawing.Point(0, 49)
        Me.GCItem.MainView = Me.GVItem
        Me.GCItem.Name = "GCItem"
        Me.GCItem.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RIMDetail})
        Me.GCItem.Size = New System.Drawing.Size(886, 418)
        Me.GCItem.TabIndex = 1
        Me.GCItem.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVItem})
        '
        'GVItem
        '
        Me.GVItem.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4})
        Me.GVItem.GridControl = Me.GCItem
        Me.GVItem.Name = "GVItem"
        Me.GVItem.OptionsView.RowAutoHeight = True
        Me.GVItem.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_item_detail"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Item"
        Me.GridColumn2.FieldName = "item_desc"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Detail"
        Me.GridColumn3.ColumnEdit = Me.RIMDetail
        Me.GridColumn3.FieldName = "item_detail"
        Me.GridColumn3.MinWidth = 600
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 600
        '
        'RIMDetail
        '
        Me.RIMDetail.Name = "RIMDetail"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Remark"
        Me.GridColumn4.FieldName = "remark"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'FormMasterItemStockCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(886, 467)
        Me.Controls.Add(Me.GCItem)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormMasterItemStockCard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Item"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIMDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCItem As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVItem As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RIMDetail As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BNewItem As DevExpress.XtraEditors.SimpleButton
End Class
