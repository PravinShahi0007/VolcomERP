<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStockQC
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
        Me.XTCStock = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPSOH = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SLEVendor = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView14 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEDesignStockStore = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GVSLEDesgSearch = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnCodeSearch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.XTCStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCStock.SuspendLayout()
        Me.XTPSOH.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEDesignStockStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSLEDesgSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCStock
        '
        Me.XTCStock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCStock.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCStock.Location = New System.Drawing.Point(0, 0)
        Me.XTCStock.Name = "XTCStock"
        Me.XTCStock.SelectedTabPage = Me.XTPSOH
        Me.XTCStock.Size = New System.Drawing.Size(1072, 528)
        Me.XTCStock.TabIndex = 0
        Me.XTCStock.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPSOH})
        '
        'XTPSOH
        '
        Me.XTPSOH.Controls.Add(Me.PanelControl1)
        Me.XTPSOH.Name = "XTPSOH"
        Me.XTPSOH.Size = New System.Drawing.Size(1066, 500)
        Me.XTPSOH.Text = "Stock On Hand"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SLEVendor)
        Me.PanelControl1.Controls.Add(Me.SLESeason)
        Me.PanelControl1.Controls.Add(Me.BSearch)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.SLEDesignStockStore)
        Me.PanelControl1.Controls.Add(Me.LabelControl9)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1066, 38)
        Me.PanelControl1.TabIndex = 4
        '
        'SLEVendor
        '
        Me.SLEVendor.Location = New System.Drawing.Point(450, 8)
        Me.SLEVendor.Name = "SLEVendor"
        Me.SLEVendor.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEVendor.Properties.Appearance.Options.UseFont = True
        Me.SLEVendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEVendor.Properties.View = Me.GridView14
        Me.SLEVendor.Size = New System.Drawing.Size(148, 20)
        Me.SLEVendor.TabIndex = 8905
        '
        'GridView14
        '
        Me.GridView14.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn10, Me.GridColumn11, Me.GridColumn12})
        Me.GridView14.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView14.Name = "GridView14"
        Me.GridView14.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView14.OptionsView.ShowGroupPanel = False
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Id Comp"
        Me.GridColumn10.FieldName = "id_comp"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Comp Number"
        Me.GridColumn11.FieldName = "comp_number"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 0
        Me.GridColumn11.Width = 188
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Comp Name"
        Me.GridColumn12.FieldName = "comp_name"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 1
        Me.GridColumn12.Width = 504
        '
        'SLESeason
        '
        Me.SLESeason.Location = New System.Drawing.Point(251, 8)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(153, 20)
        Me.SLESeason.TabIndex = 8904
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn8})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Id Season"
        Me.GridColumn6.FieldName = "id_season"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Season"
        Me.GridColumn8.FieldName = "season"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 0
        '
        'BSearch
        '
        Me.BSearch.Location = New System.Drawing.Point(604, 6)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(59, 23)
        Me.BSearch.TabIndex = 8903
        Me.BSearch.Text = "Search"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(410, 11)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl3.TabIndex = 8901
        Me.LabelControl3.Text = "Vendor"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(210, 11)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl1.TabIndex = 8897
        Me.LabelControl1.Text = "Season"
        '
        'SLEDesignStockStore
        '
        Me.SLEDesignStockStore.Location = New System.Drawing.Point(53, 8)
        Me.SLEDesignStockStore.Name = "SLEDesignStockStore"
        Me.SLEDesignStockStore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEDesignStockStore.Properties.View = Me.GVSLEDesgSearch
        Me.SLEDesignStockStore.Size = New System.Drawing.Size(151, 20)
        Me.SLEDesignStockStore.TabIndex = 8896
        '
        'GVSLEDesgSearch
        '
        Me.GVSLEDesgSearch.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCodeSearch, Me.GridColumn7, Me.GridColumn9})
        Me.GVSLEDesgSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GVSLEDesgSearch.Name = "GVSLEDesgSearch"
        Me.GVSLEDesgSearch.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GVSLEDesgSearch.OptionsView.ShowGroupPanel = False
        '
        'GridColumnCodeSearch
        '
        Me.GridColumnCodeSearch.Caption = "Code"
        Me.GridColumnCodeSearch.FieldName = "design_code"
        Me.GridColumnCodeSearch.Name = "GridColumnCodeSearch"
        Me.GridColumnCodeSearch.Visible = True
        Me.GridColumnCodeSearch.VisibleIndex = 0
        Me.GridColumnCodeSearch.Width = 186
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Description"
        Me.GridColumn7.FieldName = "display_name"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 1
        Me.GridColumn7.Width = 360
        '
        'GridColumn9
        '
        Me.GridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn9.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn9.Caption = "Color"
        Me.GridColumn9.FieldName = "color"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 2
        Me.GridColumn9.Width = 146
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(11, 11)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl9.TabIndex = 8895
        Me.LabelControl9.Text = "Design"
        '
        'FormStockQC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1072, 528)
        Me.Controls.Add(Me.XTCStock)
        Me.Name = "FormStockQC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock"
        CType(Me.XTCStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCStock.ResumeLayout(False)
        Me.XTPSOH.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEDesignStockStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSLEDesgSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCStock As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPSOH As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLEVendor As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView14 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEDesignStockStore As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GVSLEDesgSearch As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCodeSearch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
End Class
