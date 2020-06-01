<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormWHAwbillTrackCollection
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormWHAwbillTrackCollection))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.TECodeScan = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.Bimport = New DevExpress.XtraEditors.SimpleButton()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLECargo = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SLVCargo = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRange = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCCollection = New DevExpress.XtraGrid.GridControl()
        Me.GVCollection = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTCAWBCollection = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPAWBCollection = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPPickAWB = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.TEScanGenerate = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.GCVendorCollection = New DevExpress.XtraGrid.GridControl()
        Me.GVVendorCollection = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TECodeScan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLECargo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLVCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCAWBCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCAWBCollection.SuspendLayout()
        Me.XTPAWBCollection.SuspendLayout()
        Me.XTPPickAWB.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.TEScanGenerate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCVendorCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVVendorCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.TECodeScan)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.Bimport)
        Me.PanelControl1.Controls.Add(Me.BView)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.SLECargo)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(955, 41)
        Me.PanelControl1.TabIndex = 0
        '
        'TECodeScan
        '
        Me.TECodeScan.Location = New System.Drawing.Point(403, 9)
        Me.TECodeScan.Name = "TECodeScan"
        Me.TECodeScan.Size = New System.Drawing.Size(195, 20)
        Me.TECodeScan.TabIndex = 15
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(311, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl2.TabIndex = 14
        Me.LabelControl2.Text = "Scan to collection "
        '
        'Bimport
        '
        Me.Bimport.Dock = System.Windows.Forms.DockStyle.Right
        Me.Bimport.Image = CType(resources.GetObject("Bimport.Image"), System.Drawing.Image)
        Me.Bimport.Location = New System.Drawing.Point(810, 2)
        Me.Bimport.Name = "Bimport"
        Me.Bimport.Size = New System.Drawing.Size(143, 37)
        Me.Bimport.TabIndex = 13
        Me.Bimport.Text = "Import Collection"
        Me.Bimport.Visible = False
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(257, 7)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(48, 23)
        Me.BView.TabIndex = 12
        Me.BView.Text = "view"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl1.TabIndex = 11
        Me.LabelControl1.Text = "Vendor"
        '
        'SLECargo
        '
        Me.SLECargo.Location = New System.Drawing.Point(52, 9)
        Me.SLECargo.Name = "SLECargo"
        Me.SLECargo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLECargo.Properties.Appearance.Options.UseFont = True
        Me.SLECargo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLECargo.Properties.NullText = "-"
        Me.SLECargo.Properties.View = Me.SLVCargo
        Me.SLECargo.Size = New System.Drawing.Size(199, 20)
        Me.SLECargo.TabIndex = 10
        '
        'SLVCargo
        '
        Me.SLVCargo.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdSeason, Me.GridColumnRange})
        Me.SLVCargo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SLVCargo.Name = "SLVCargo"
        Me.SLVCargo.OptionsBehavior.ReadOnly = True
        Me.SLVCargo.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SLVCargo.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "ID Cargo"
        Me.GridColumnIdSeason.FieldName = "id_comp"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        '
        'GridColumnRange
        '
        Me.GridColumnRange.Caption = "Vendor"
        Me.GridColumnRange.FieldName = "comp_name"
        Me.GridColumnRange.Name = "GridColumnRange"
        Me.GridColumnRange.Visible = True
        Me.GridColumnRange.VisibleIndex = 0
        '
        'GCCollection
        '
        Me.GCCollection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCollection.Location = New System.Drawing.Point(0, 41)
        Me.GCCollection.MainView = Me.GVCollection
        Me.GCCollection.Name = "GCCollection"
        Me.GCCollection.Size = New System.Drawing.Size(955, 437)
        Me.GCCollection.TabIndex = 1
        Me.GCCollection.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCollection})
        '
        'GVCollection
        '
        Me.GVCollection.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn5, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4})
        Me.GVCollection.GridControl = Me.GCCollection
        Me.GVCollection.Name = "GVCollection"
        Me.GVCollection.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID "
        Me.GridColumn1.FieldName = "id_track_no"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "IS Use"
        Me.GridColumn5.FieldName = "is_use"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Vendor"
        Me.GridColumn2.FieldName = "comp_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Tracking Number"
        Me.GridColumn3.FieldName = "track_no"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Status"
        Me.GridColumn4.FieldName = "used"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'XTCAWBCollection
        '
        Me.XTCAWBCollection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCAWBCollection.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCAWBCollection.Location = New System.Drawing.Point(0, 0)
        Me.XTCAWBCollection.Name = "XTCAWBCollection"
        Me.XTCAWBCollection.SelectedTabPage = Me.XTPAWBCollection
        Me.XTCAWBCollection.Size = New System.Drawing.Size(961, 506)
        Me.XTCAWBCollection.TabIndex = 2
        Me.XTCAWBCollection.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPAWBCollection, Me.XTPPickAWB})
        '
        'XTPAWBCollection
        '
        Me.XTPAWBCollection.Controls.Add(Me.GCCollection)
        Me.XTPAWBCollection.Controls.Add(Me.PanelControl1)
        Me.XTPAWBCollection.Name = "XTPAWBCollection"
        Me.XTPAWBCollection.Size = New System.Drawing.Size(955, 478)
        Me.XTPAWBCollection.Text = "Collection"
        '
        'XTPPickAWB
        '
        Me.XTPPickAWB.Controls.Add(Me.GCVendorCollection)
        Me.XTPPickAWB.Controls.Add(Me.PanelControl2)
        Me.XTPPickAWB.Name = "XTPPickAWB"
        Me.XTPPickAWB.Size = New System.Drawing.Size(955, 478)
        Me.XTPPickAWB.Text = "Pick AWB"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.TEScanGenerate)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(955, 41)
        Me.PanelControl2.TabIndex = 1
        '
        'TEScanGenerate
        '
        Me.TEScanGenerate.Location = New System.Drawing.Point(126, 11)
        Me.TEScanGenerate.Name = "TEScanGenerate"
        Me.TEScanGenerate.Size = New System.Drawing.Size(375, 20)
        Me.TEScanGenerate.TabIndex = 15
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(11, 14)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(109, 13)
        Me.LabelControl3.TabIndex = 14
        Me.LabelControl3.Text = "Scan to generate AWB"
        '
        'GCVendorCollection
        '
        Me.GCVendorCollection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCVendorCollection.Location = New System.Drawing.Point(0, 41)
        Me.GCVendorCollection.MainView = Me.GVVendorCollection
        Me.GCVendorCollection.Name = "GCVendorCollection"
        Me.GCVendorCollection.Size = New System.Drawing.Size(955, 437)
        Me.GCVendorCollection.TabIndex = 2
        Me.GCVendorCollection.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVVendorCollection})
        '
        'GVVendorCollection
        '
        Me.GVVendorCollection.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12})
        Me.GVVendorCollection.GridControl = Me.GCVendorCollection
        Me.GVVendorCollection.Name = "GVVendorCollection"
        Me.GVVendorCollection.OptionsView.ShowGroupPanel = False
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "ID "
        Me.GridColumn8.FieldName = "id_track_no"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "IS Use"
        Me.GridColumn9.FieldName = "is_use"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Vendor"
        Me.GridColumn10.FieldName = "comp_name"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Tracking Number"
        Me.GridColumn11.FieldName = "track_no"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 1
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Status"
        Me.GridColumn12.FieldName = "used"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 2
        '
        'FormWHAwbillTrackCollection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 506)
        Me.Controls.Add(Me.XTCAWBCollection)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormWHAwbillTrackCollection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tracking Number Collection"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TECodeScan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLECargo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLVCargo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCAWBCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCAWBCollection.ResumeLayout(False)
        Me.XTPAWBCollection.ResumeLayout(False)
        Me.XTPPickAWB.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.TEScanGenerate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCVendorCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVVendorCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCCollection As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCollection As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLECargo As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SLVCargo As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRange As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Bimport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TECodeScan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XTCAWBCollection As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPAWBCollection As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPPickAWB As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCVendorCollection As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVVendorCollection As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEScanGenerate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
End Class
