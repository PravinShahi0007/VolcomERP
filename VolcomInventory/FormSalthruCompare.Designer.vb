<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalthruCompare
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
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_design = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnseason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndelivery_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnclass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncolor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncolor_desc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsilhouette = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnfit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnage_in_store = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnfirst_del = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsal_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsoh_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnactual_salthru = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntarget_salthru = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(613, 61)
        Me.PanelControl1.TabIndex = 0
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 61)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(613, 358)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_design, Me.GridColumnseason, Me.GridColumndel, Me.GridColumndelivery_date, Me.GridColumndesign_code, Me.GridColumnclass, Me.GridColumndescription, Me.GridColumncolor, Me.GridColumncolor_desc, Me.GridColumnsilhouette, Me.GridColumnfit, Me.GridColumncomp_number, Me.GridColumncomp_name, Me.GridColumnage_in_store, Me.GridColumnfirst_del, Me.GridColumnsal_qty, Me.GridColumnsoh_qty, Me.GridColumnactual_salthru, Me.GridColumntarget_salthru})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sal_qty", Me.GridColumnsal_qty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "soh_qty", Me.GridColumnsoh_qty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "actual_salthru", Me.GridColumnactual_salthru, "", "act_salthru_groupsum"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "target_salthru", Me.GridColumntarget_salthru, "{0:N2}")})
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_design
        '
        Me.GridColumnid_design.Caption = "id_design"
        Me.GridColumnid_design.FieldName = "id_design"
        Me.GridColumnid_design.Name = "GridColumnid_design"
        '
        'GridColumnseason
        '
        Me.GridColumnseason.Caption = "Season"
        Me.GridColumnseason.FieldName = "season"
        Me.GridColumnseason.Name = "GridColumnseason"
        Me.GridColumnseason.Visible = True
        Me.GridColumnseason.VisibleIndex = 0
        '
        'GridColumndel
        '
        Me.GridColumndel.Caption = "Del"
        Me.GridColumndel.FieldName = "del"
        Me.GridColumndel.Name = "GridColumndel"
        Me.GridColumndel.Visible = True
        Me.GridColumndel.VisibleIndex = 1
        '
        'GridColumndelivery_date
        '
        Me.GridColumndelivery_date.Caption = "In Store Date"
        Me.GridColumndelivery_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumndelivery_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumndelivery_date.FieldName = "delivery_date"
        Me.GridColumndelivery_date.Name = "GridColumndelivery_date"
        '
        'GridColumndesign_code
        '
        Me.GridColumndesign_code.Caption = "Code"
        Me.GridColumndesign_code.FieldName = "design_code"
        Me.GridColumndesign_code.Name = "GridColumndesign_code"
        Me.GridColumndesign_code.Visible = True
        Me.GridColumndesign_code.VisibleIndex = 2
        '
        'GridColumnclass
        '
        Me.GridColumnclass.Caption = "Class"
        Me.GridColumnclass.FieldName = "class"
        Me.GridColumnclass.Name = "GridColumnclass"
        Me.GridColumnclass.Visible = True
        Me.GridColumnclass.VisibleIndex = 3
        '
        'GridColumndescription
        '
        Me.GridColumndescription.Caption = "Description"
        Me.GridColumndescription.FieldName = "description"
        Me.GridColumndescription.Name = "GridColumndescription"
        Me.GridColumndescription.Visible = True
        Me.GridColumndescription.VisibleIndex = 4
        '
        'GridColumncolor
        '
        Me.GridColumncolor.Caption = "Color"
        Me.GridColumncolor.FieldName = "color"
        Me.GridColumncolor.Name = "GridColumncolor"
        Me.GridColumncolor.Visible = True
        Me.GridColumncolor.VisibleIndex = 5
        '
        'GridColumncolor_desc
        '
        Me.GridColumncolor_desc.Caption = "Color Description"
        Me.GridColumncolor_desc.FieldName = "color_desc"
        Me.GridColumncolor_desc.Name = "GridColumncolor_desc"
        Me.GridColumncolor_desc.Visible = True
        Me.GridColumncolor_desc.VisibleIndex = 6
        '
        'GridColumnsilhouette
        '
        Me.GridColumnsilhouette.Caption = "Silhouette"
        Me.GridColumnsilhouette.FieldName = "silhouette"
        Me.GridColumnsilhouette.Name = "GridColumnsilhouette"
        Me.GridColumnsilhouette.Visible = True
        Me.GridColumnsilhouette.VisibleIndex = 7
        '
        'GridColumnfit
        '
        Me.GridColumnfit.Caption = "Fit"
        Me.GridColumnfit.FieldName = "fit"
        Me.GridColumnfit.Name = "GridColumnfit"
        Me.GridColumnfit.Visible = True
        Me.GridColumnfit.VisibleIndex = 8
        '
        'GridColumncomp_number
        '
        Me.GridColumncomp_number.Caption = "Store Acc."
        Me.GridColumncomp_number.FieldName = "comp_number"
        Me.GridColumncomp_number.Name = "GridColumncomp_number"
        Me.GridColumncomp_number.Visible = True
        Me.GridColumncomp_number.VisibleIndex = 9
        '
        'GridColumncomp_name
        '
        Me.GridColumncomp_name.Caption = "Store"
        Me.GridColumncomp_name.FieldName = "comp_name"
        Me.GridColumncomp_name.Name = "GridColumncomp_name"
        Me.GridColumncomp_name.Visible = True
        Me.GridColumncomp_name.VisibleIndex = 10
        '
        'GridColumnage_in_store
        '
        Me.GridColumnage_in_store.Caption = "Age in Store"
        Me.GridColumnage_in_store.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnage_in_store.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnage_in_store.FieldName = "age_in_store"
        Me.GridColumnage_in_store.Name = "GridColumnage_in_store"
        Me.GridColumnage_in_store.Visible = True
        Me.GridColumnage_in_store.VisibleIndex = 11
        '
        'GridColumnfirst_del
        '
        Me.GridColumnfirst_del.Caption = "First Del. Date"
        Me.GridColumnfirst_del.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnfirst_del.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnfirst_del.FieldName = "first_del"
        Me.GridColumnfirst_del.Name = "GridColumnfirst_del"
        '
        'GridColumnsal_qty
        '
        Me.GridColumnsal_qty.Caption = "Sales"
        Me.GridColumnsal_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumnsal_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnsal_qty.FieldName = "sal_qty"
        Me.GridColumnsal_qty.Name = "GridColumnsal_qty"
        Me.GridColumnsal_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sal_qty", "{0:N0}")})
        Me.GridColumnsal_qty.Visible = True
        Me.GridColumnsal_qty.VisibleIndex = 12
        '
        'GridColumnsoh_qty
        '
        Me.GridColumnsoh_qty.Caption = "SOH"
        Me.GridColumnsoh_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumnsoh_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnsoh_qty.FieldName = "soh_qty"
        Me.GridColumnsoh_qty.Name = "GridColumnsoh_qty"
        Me.GridColumnsoh_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "soh_qty", "{0:N0}")})
        Me.GridColumnsoh_qty.Visible = True
        Me.GridColumnsoh_qty.VisibleIndex = 13
        '
        'GridColumnactual_salthru
        '
        Me.GridColumnactual_salthru.Caption = "Actual Salthru"
        Me.GridColumnactual_salthru.DisplayFormat.FormatString = "N2"
        Me.GridColumnactual_salthru.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnactual_salthru.FieldName = "actual_salthru"
        Me.GridColumnactual_salthru.Name = "GridColumnactual_salthru"
        Me.GridColumnactual_salthru.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "actual_salthru", "", "act_salthru_sum")})
        Me.GridColumnactual_salthru.Visible = True
        Me.GridColumnactual_salthru.VisibleIndex = 14
        '
        'GridColumntarget_salthru
        '
        Me.GridColumntarget_salthru.Caption = "Target Salthru"
        Me.GridColumntarget_salthru.DisplayFormat.FormatString = "N2"
        Me.GridColumntarget_salthru.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntarget_salthru.FieldName = "target_salthru"
        Me.GridColumntarget_salthru.Name = "GridColumntarget_salthru"
        Me.GridColumntarget_salthru.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "target_salthru", "{0:N2}")})
        Me.GridColumntarget_salthru.Visible = True
        Me.GridColumntarget_salthru.VisibleIndex = 15
        '
        'FormSalthruCompare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 419)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormSalthruCompare"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compare Sales Thru  "
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_design As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnseason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndelivery_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnclass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncolor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncolor_desc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsilhouette As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnfit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnage_in_store As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnfirst_del As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsal_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsoh_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnactual_salthru As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntarget_salthru As DevExpress.XtraGrid.Columns.GridColumn
End Class
