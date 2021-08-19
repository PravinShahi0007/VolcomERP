<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStockTakeStoreVer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormStockTakeStoreVer))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SBSynctoWeb = New DevExpress.XtraEditors.SimpleButton()
        Me.SBNew = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBSynctoWeb)
        Me.PanelControl1.Controls.Add(Me.SBNew)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 48)
        Me.PanelControl1.TabIndex = 0
        '
        'SBSynctoWeb
        '
        Me.SBSynctoWeb.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBSynctoWeb.Image = CType(resources.GetObject("SBSynctoWeb.Image"), System.Drawing.Image)
        Me.SBSynctoWeb.Location = New System.Drawing.Point(667, 2)
        Me.SBSynctoWeb.Name = "SBSynctoWeb"
        Me.SBSynctoWeb.Size = New System.Drawing.Size(115, 44)
        Me.SBSynctoWeb.TabIndex = 1
        Me.SBSynctoWeb.Text = "Sync to Web"
        '
        'SBNew
        '
        Me.SBNew.Dock = System.Windows.Forms.DockStyle.Left
        Me.SBNew.Image = CType(resources.GetObject("SBNew.Image"), System.Drawing.Image)
        Me.SBNew.Location = New System.Drawing.Point(2, 2)
        Me.SBNew.Name = "SBNew"
        Me.SBNew.Size = New System.Drawing.Size(90, 44)
        Me.SBNew.TabIndex = 0
        Me.SBNew.Text = "New"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 48)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(784, 513)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn6, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn7})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "id_st_store_bap"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Number"
        Me.GridColumn6.FieldName = "number"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Account"
        Me.GridColumn2.FieldName = "comp_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Created At"
        Me.GridColumn3.FieldName = "created_at"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Created By"
        Me.GridColumn4.FieldName = "created_by"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Report Status"
        Me.GridColumn5.FieldName = "report_status"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        '
        'GridColumn7
        '
        Me.GridColumn7.FieldName = "id_report_status"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'FormStockTakeStoreVer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormStockTakeStoreVer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Take Store Verification"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SBNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SBSynctoWeb As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
End Class
