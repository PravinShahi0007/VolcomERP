<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterSilhouetteDet
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.TxtClassDesc = New DevExpress.XtraEditors.TextEdit()
        Me.TxtClass = New DevExpress.XtraEditors.TextEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteMappingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_sht = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsht_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnList = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSet = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLESHT = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_code_detail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncode_detail_name = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TxtClassDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtClass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.SLESHT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.TxtClassDesc)
        Me.PanelControl1.Controls.Add(Me.TxtClass)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(521, 53)
        Me.PanelControl1.TabIndex = 0
        '
        'TxtClassDesc
        '
        Me.TxtClassDesc.EditValue = "CLASS DESCRIPTION"
        Me.TxtClassDesc.Enabled = False
        Me.TxtClassDesc.Location = New System.Drawing.Point(77, 12)
        Me.TxtClassDesc.Name = "TxtClassDesc"
        Me.TxtClassDesc.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClassDesc.Properties.Appearance.Options.UseFont = True
        Me.TxtClassDesc.Size = New System.Drawing.Size(435, 26)
        Me.TxtClassDesc.TabIndex = 2
        '
        'TxtClass
        '
        Me.TxtClass.EditValue = "WWW"
        Me.TxtClass.Enabled = False
        Me.TxtClass.Location = New System.Drawing.Point(12, 12)
        Me.TxtClass.Name = "TxtClass"
        Me.TxtClass.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClass.Properties.Appearance.Options.UseFont = True
        Me.TxtClass.Size = New System.Drawing.Size(62, 26)
        Me.TxtClass.TabIndex = 1
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControl1.Controls.Add(Me.GCData)
        Me.GroupControl1.Controls.Add(Me.PanelControl2)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 53)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(521, 282)
        Me.GroupControl1.TabIndex = 1
        '
        'GCData
        '
        Me.GCData.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(2, 20)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(517, 220)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteMappingToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(159, 26)
        '
        'DeleteMappingToolStripMenuItem
        '
        Me.DeleteMappingToolStripMenuItem.Name = "DeleteMappingToolStripMenuItem"
        Me.DeleteMappingToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.DeleteMappingToolStripMenuItem.Text = "Delete Mapping"
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_sht, Me.GridColumnsht_name})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_sht
        '
        Me.GridColumnid_sht.Caption = "id_code_detail"
        Me.GridColumnid_sht.FieldName = "id_sht"
        Me.GridColumnid_sht.Name = "GridColumnid_sht"
        '
        'GridColumnsht_name
        '
        Me.GridColumnsht_name.Caption = "Silhouette"
        Me.GridColumnsht_name.FieldName = "sht_name"
        Me.GridColumnsht_name.Name = "GridColumnsht_name"
        Me.GridColumnsht_name.Visible = True
        Me.GridColumnsht_name.VisibleIndex = 0
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BtnList)
        Me.PanelControl2.Controls.Add(Me.BtnSet)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.SLESHT)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(2, 240)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(517, 40)
        Me.PanelControl2.TabIndex = 0
        '
        'BtnList
        '
        Me.BtnList.Location = New System.Drawing.Point(283, 9)
        Me.BtnList.Name = "BtnList"
        Me.BtnList.Size = New System.Drawing.Size(97, 23)
        Me.BtnList.TabIndex = 4
        Me.BtnList.Text = "Silhouette List"
        '
        'BtnSet
        '
        Me.BtnSet.Location = New System.Drawing.Point(230, 9)
        Me.BtnSet.Name = "BtnSet"
        Me.BtnSet.Size = New System.Drawing.Size(49, 23)
        Me.BtnSet.TabIndex = 2
        Me.BtnSet.Text = "Set"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(10, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(80, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Select Silhouette"
        '
        'SLESHT
        '
        Me.SLESHT.Location = New System.Drawing.Point(96, 11)
        Me.SLESHT.Name = "SLESHT"
        Me.SLESHT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESHT.Properties.ShowClearButton = False
        Me.SLESHT.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESHT.Size = New System.Drawing.Size(131, 20)
        Me.SLESHT.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_code_detail, Me.GridColumncode_detail_name})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_code_detail
        '
        Me.GridColumnid_code_detail.Caption = "id_code_detail"
        Me.GridColumnid_code_detail.FieldName = "id_code_detail"
        Me.GridColumnid_code_detail.Name = "GridColumnid_code_detail"
        '
        'GridColumncode_detail_name
        '
        Me.GridColumncode_detail_name.Caption = "Silhouette"
        Me.GridColumncode_detail_name.FieldName = "code_detail_name"
        Me.GridColumncode_detail_name.Name = "GridColumncode_detail_name"
        Me.GridColumncode_detail_name.Visible = True
        Me.GridColumncode_detail_name.VisibleIndex = 0
        '
        'FormMasterSilhouetteDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 335)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterSilhouetteDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Silhouette Mapping"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.TxtClassDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtClass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.SLESHT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TxtClassDesc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtClass As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnList As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSet As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLESHT As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents DeleteMappingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridColumnid_code_detail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncode_detail_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_sht As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsht_name As DevExpress.XtraGrid.Columns.GridColumn
End Class
