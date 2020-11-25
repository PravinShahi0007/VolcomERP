<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBatchUploadOnlineStore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBatchUploadOnlineStore))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SBExportExcel = New DevExpress.XtraEditors.SimpleButton()
        Me.SBView = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SLUEOnlineStore = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCBatchUpload = New DevExpress.XtraGrid.GridControl()
        Me.GVBatchUpload = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLUEOnlineStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCBatchUpload, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBatchUpload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBExportExcel)
        Me.PanelControl1.Controls.Add(Me.SBView)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Controls.Add(Me.SLUEOnlineStore)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 50)
        Me.PanelControl1.TabIndex = 0
        '
        'SBExportExcel
        '
        Me.SBExportExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBExportExcel.Image = CType(resources.GetObject("SBExportExcel.Image"), System.Drawing.Image)
        Me.SBExportExcel.Location = New System.Drawing.Point(672, 13)
        Me.SBExportExcel.Name = "SBExportExcel"
        Me.SBExportExcel.Size = New System.Drawing.Size(100, 23)
        Me.SBExportExcel.TabIndex = 3
        Me.SBExportExcel.Text = "Export Excel"
        '
        'SBView
        '
        Me.SBView.Image = CType(resources.GetObject("SBView.Image"), System.Drawing.Image)
        Me.SBView.Location = New System.Drawing.Point(297, 13)
        Me.SBView.Name = "SBView"
        Me.SBView.Size = New System.Drawing.Size(75, 23)
        Me.SBView.TabIndex = 2
        Me.SBView.Text = "View"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Online Store"
        '
        'SLUEOnlineStore
        '
        Me.SLUEOnlineStore.Location = New System.Drawing.Point(91, 15)
        Me.SLUEOnlineStore.Name = "SLUEOnlineStore"
        Me.SLUEOnlineStore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEOnlineStore.Properties.View = Me.SearchLookUpEdit1View
        Me.SLUEOnlineStore.Size = New System.Drawing.Size(200, 20)
        Me.SLUEOnlineStore.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GCBatchUpload
        '
        Me.GCBatchUpload.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBatchUpload.Location = New System.Drawing.Point(0, 50)
        Me.GCBatchUpload.MainView = Me.GVBatchUpload
        Me.GCBatchUpload.Name = "GCBatchUpload"
        Me.GCBatchUpload.Size = New System.Drawing.Size(784, 511)
        Me.GCBatchUpload.TabIndex = 1
        Me.GCBatchUpload.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBatchUpload})
        '
        'GVBatchUpload
        '
        Me.GVBatchUpload.GridControl = Me.GCBatchUpload
        Me.GVBatchUpload.Name = "GVBatchUpload"
        Me.GVBatchUpload.OptionsView.ColumnAutoWidth = False
        Me.GVBatchUpload.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "id_design_column_type"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Online Store"
        Me.GridColumn2.FieldName = "column_type"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'FormBatchUploadOnlineStore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCBatchUpload)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormBatchUploadOnlineStore"
        Me.Text = "Batch Upload Online Store"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLUEOnlineStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCBatchUpload, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBatchUpload, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCBatchUpload As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBatchUpload As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label1 As Label
    Friend WithEvents SLUEOnlineStore As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SBExportExcel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
End Class
