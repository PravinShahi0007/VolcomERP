<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProdDebitNote
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SLEVendor = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView14 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEDesignStockStore = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GVSLEDesgSearch = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnCodeSearch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.GCMatPR = New DevExpress.XtraGrid.GridControl()
        Me.GVMatPR = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdMatPurchase = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPRNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPayTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColMatPurcDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPONumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIDStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIDPO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnWONumber = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEDesignStockStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSLEDesgSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCMatPR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMatPR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.PanelControl1.Size = New System.Drawing.Size(1057, 38)
        Me.PanelControl1.TabIndex = 5
        '
        'SLEVendor
        '
        Me.SLEVendor.Location = New System.Drawing.Point(512, 8)
        Me.SLEVendor.Name = "SLEVendor"
        Me.SLEVendor.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEVendor.Properties.Appearance.Options.UseFont = True
        Me.SLEVendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEVendor.Properties.View = Me.GridView14
        Me.SLEVendor.Size = New System.Drawing.Size(197, 20)
        Me.SLEVendor.TabIndex = 8905
        '
        'GridView14
        '
        Me.GridView14.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn12, Me.GridColumn13, Me.GridColumn14})
        Me.GridView14.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView14.Name = "GridView14"
        Me.GridView14.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView14.OptionsView.ShowGroupPanel = False
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Id Comp"
        Me.GridColumn12.FieldName = "id_comp"
        Me.GridColumn12.Name = "GridColumn12"
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Comp Number"
        Me.GridColumn13.FieldName = "comp_number"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 0
        Me.GridColumn13.Width = 188
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Comp Name"
        Me.GridColumn14.FieldName = "comp_name"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 1
        Me.GridColumn14.Width = 504
        '
        'SLESeason
        '
        Me.SLESeason.Location = New System.Drawing.Point(303, 8)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(163, 20)
        Me.SLESeason.TabIndex = 8904
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn15, Me.GridColumn16})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Id Season"
        Me.GridColumn15.FieldName = "id_season"
        Me.GridColumn15.Name = "GridColumn15"
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Season"
        Me.GridColumn16.FieldName = "season"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 0
        '
        'BSearch
        '
        Me.BSearch.Location = New System.Drawing.Point(715, 6)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(59, 23)
        Me.BSearch.TabIndex = 8903
        Me.BSearch.Text = "Search"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(472, 11)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl3.TabIndex = 8901
        Me.LabelControl3.Text = "Vendor"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(262, 11)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl1.TabIndex = 8897
        Me.LabelControl1.Text = "Season"
        '
        'SLEDesignStockStore
        '
        Me.SLEDesignStockStore.Location = New System.Drawing.Point(49, 8)
        Me.SLEDesignStockStore.Name = "SLEDesignStockStore"
        Me.SLEDesignStockStore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEDesignStockStore.Properties.View = Me.GVSLEDesgSearch
        Me.SLEDesignStockStore.Size = New System.Drawing.Size(195, 20)
        Me.SLEDesignStockStore.TabIndex = 8896
        '
        'GVSLEDesgSearch
        '
        Me.GVSLEDesgSearch.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCodeSearch, Me.GridColumn17, Me.GridColumn18})
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
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Description"
        Me.GridColumn17.FieldName = "display_name"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 1
        Me.GridColumn17.Width = 360
        '
        'GridColumn18
        '
        Me.GridColumn18.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn18.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn18.Caption = "Color"
        Me.GridColumn18.FieldName = "color"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 2
        Me.GridColumn18.Width = 146
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
        'GCMatPR
        '
        Me.GCMatPR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMatPR.Location = New System.Drawing.Point(0, 38)
        Me.GCMatPR.MainView = Me.GVMatPR
        Me.GCMatPR.Name = "GCMatPR"
        Me.GCMatPR.Size = New System.Drawing.Size(1057, 450)
        Me.GCMatPR.TabIndex = 6
        Me.GCMatPR.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMatPR})
        '
        'GVMatPR
        '
        Me.GVMatPR.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdMatPurchase, Me.ColPRNumber, Me.ColPayTo, Me.ColMatPurcDate, Me.ColDueDate, Me.ColPONumber, Me.GridColumnWONumber, Me.ColNote, Me.ColStatus, Me.ColIDStatus, Me.GridColumnIDPO, Me.GridColumn10, Me.GridColumn11, Me.GridColumn9})
        Me.GVMatPR.GridControl = Me.GCMatPR
        Me.GVMatPR.Name = "GVMatPR"
        Me.GVMatPR.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVMatPR.OptionsBehavior.Editable = False
        Me.GVMatPR.OptionsFind.AlwaysVisible = True
        Me.GVMatPR.OptionsView.ShowGroupPanel = False
        '
        'ColIdMatPurchase
        '
        Me.ColIdMatPurchase.Caption = "ID PR"
        Me.ColIdMatPurchase.FieldName = "id_pr_prod_order"
        Me.ColIdMatPurchase.Name = "ColIdMatPurchase"
        '
        'ColPRNumber
        '
        Me.ColPRNumber.Caption = "Number"
        Me.ColPRNumber.FieldName = "pr_prod_order_number"
        Me.ColPRNumber.Name = "ColPRNumber"
        Me.ColPRNumber.Visible = True
        Me.ColPRNumber.VisibleIndex = 0
        Me.ColPRNumber.Width = 73
        '
        'ColPayTo
        '
        Me.ColPayTo.Caption = "Claim To"
        Me.ColPayTo.FieldName = "comp_to"
        Me.ColPayTo.Name = "ColPayTo"
        Me.ColPayTo.Visible = True
        Me.ColPayTo.VisibleIndex = 1
        Me.ColPayTo.Width = 113
        '
        'ColMatPurcDate
        '
        Me.ColMatPurcDate.Caption = "Create Date"
        Me.ColMatPurcDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColMatPurcDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColMatPurcDate.FieldName = "pr_prod_order_date"
        Me.ColMatPurcDate.Name = "ColMatPurcDate"
        Me.ColMatPurcDate.Visible = True
        Me.ColMatPurcDate.VisibleIndex = 6
        Me.ColMatPurcDate.Width = 100
        '
        'ColDueDate
        '
        Me.ColDueDate.Caption = "Due Date"
        Me.ColDueDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColDueDate.FieldName = "pr_prod_order_due_date"
        Me.ColDueDate.Name = "ColDueDate"
        Me.ColDueDate.Visible = True
        Me.ColDueDate.VisibleIndex = 7
        Me.ColDueDate.Width = 103
        '
        'ColPONumber
        '
        Me.ColPONumber.Caption = "F. G. PO Number"
        Me.ColPONumber.FieldName = "prod_order_number"
        Me.ColPONumber.Name = "ColPONumber"
        Me.ColPONumber.Visible = True
        Me.ColPONumber.VisibleIndex = 2
        Me.ColPONumber.Width = 73
        '
        'ColNote
        '
        Me.ColNote.Caption = "Note"
        Me.ColNote.FieldName = "pr_prod_order_note"
        Me.ColNote.Name = "ColNote"
        Me.ColNote.Width = 132
        '
        'ColStatus
        '
        Me.ColStatus.Caption = "Status"
        Me.ColStatus.FieldName = "report_status"
        Me.ColStatus.Name = "ColStatus"
        Me.ColStatus.Visible = True
        Me.ColStatus.VisibleIndex = 8
        '
        'ColIDStatus
        '
        Me.ColIDStatus.Caption = "ID Status"
        Me.ColIDStatus.FieldName = "id_report_status"
        Me.ColIDStatus.Name = "ColIDStatus"
        '
        'GridColumnIDPO
        '
        Me.GridColumnIDPO.Caption = "ID PO"
        Me.GridColumnIDPO.FieldName = "id_prod_order"
        Me.GridColumnIDPO.Name = "GridColumnIDPO"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Design Code"
        Me.GridColumn10.FieldName = "design_code"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 3
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Description"
        Me.GridColumn11.FieldName = "design_display_name"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 4
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Last Mark By"
        Me.GridColumn9.FieldName = "last_mark"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 9
        '
        'GridColumnWONumber
        '
        Me.GridColumnWONumber.Caption = "WO Number"
        Me.GridColumnWONumber.FieldName = "prod_order_wo_number"
        Me.GridColumnWONumber.Name = "GridColumnWONumber"
        Me.GridColumnWONumber.Visible = True
        Me.GridColumnWONumber.VisibleIndex = 5
        '
        'FormProdDebitNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1057, 488)
        Me.Controls.Add(Me.GCMatPR)
        Me.Controls.Add(Me.PanelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProdDebitNote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Debit Note"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEDesignStockStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSLEDesgSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCMatPR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMatPR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLEVendor As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView14 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEDesignStockStore As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GVSLEDesgSearch As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCodeSearch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCMatPR As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMatPR As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdMatPurchase As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPRNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPayTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMatPurcDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIDStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIDPO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWONumber As DevExpress.XtraGrid.Columns.GridColumn
End Class
