<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesPOSCheck
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesPOSCheck))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnProceed = New DevExpress.XtraEditors.SimpleButton()
        Me.XTCData = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPMaster = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPStock = New DevExpress.XtraTab.XtraTabPage()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_pos_combine_summary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnitem_code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnqty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCStock = New DevExpress.XtraGrid.GridControl()
        Me.GVStock = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnproduct_full_code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnis_unique_report = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_design_price = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.XTPMaster.SuspendLayout()
        Me.XTPStock.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnDiscard)
        Me.PanelControl1.Controls.Add(Me.BtnProceed)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 368)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(684, 43)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDiscard.Image = CType(resources.GetObject("BtnDiscard.Image"), System.Drawing.Image)
        Me.BtnDiscard.Location = New System.Drawing.Point(508, 2)
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(85, 39)
        Me.BtnDiscard.TabIndex = 1
        Me.BtnDiscard.Text = "Discard"
        '
        'BtnProceed
        '
        Me.BtnProceed.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnProceed.Image = CType(resources.GetObject("BtnProceed.Image"), System.Drawing.Image)
        Me.BtnProceed.Location = New System.Drawing.Point(593, 2)
        Me.BtnProceed.Name = "BtnProceed"
        Me.BtnProceed.Size = New System.Drawing.Size(89, 39)
        Me.BtnProceed.TabIndex = 0
        Me.BtnProceed.Text = "Proceed"
        '
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCData.Location = New System.Drawing.Point(0, 0)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPMaster
        Me.XTCData.Size = New System.Drawing.Size(684, 368)
        Me.XTCData.TabIndex = 1
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPMaster, Me.XTPStock})
        '
        'XTPMaster
        '
        Me.XTPMaster.Controls.Add(Me.GCData)
        Me.XTPMaster.Name = "XTPMaster"
        Me.XTPMaster.Size = New System.Drawing.Size(678, 340)
        Me.XTPMaster.Text = "Check Master"
        '
        'XTPStock
        '
        Me.XTPStock.Controls.Add(Me.GCStock)
        Me.XTPStock.Name = "XTPStock"
        Me.XTPStock.Size = New System.Drawing.Size(678, 340)
        Me.XTPStock.Text = "Check Stock"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(678, 340)
        Me.GCData.TabIndex = 0
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_pos_combine_summary, Me.GridColumnitem_code, Me.GridColumnname, Me.GridColumnsize, Me.GridColumnqty, Me.GridColumnstatus, Me.GridColumnproduct_full_code, Me.GridColumnis_unique_report, Me.GridColumndesign_price, Me.GridColumnid_design_price})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_pos_combine_summary
        '
        Me.GridColumnid_pos_combine_summary.Caption = "id_pos_combine_summary"
        Me.GridColumnid_pos_combine_summary.FieldName = "id_pos_combine_summary"
        Me.GridColumnid_pos_combine_summary.Name = "GridColumnid_pos_combine_summary"
        '
        'GridColumnitem_code
        '
        Me.GridColumnitem_code.Caption = "Code"
        Me.GridColumnitem_code.FieldName = "item_code"
        Me.GridColumnitem_code.Name = "GridColumnitem_code"
        Me.GridColumnitem_code.Visible = True
        Me.GridColumnitem_code.VisibleIndex = 0
        '
        'GridColumnname
        '
        Me.GridColumnname.Caption = "Style"
        Me.GridColumnname.FieldName = "name"
        Me.GridColumnname.Name = "GridColumnname"
        Me.GridColumnname.Visible = True
        Me.GridColumnname.VisibleIndex = 2
        '
        'GridColumnsize
        '
        Me.GridColumnsize.Caption = "Size"
        Me.GridColumnsize.FieldName = "size"
        Me.GridColumnsize.Name = "GridColumnsize"
        Me.GridColumnsize.Visible = True
        Me.GridColumnsize.VisibleIndex = 3
        '
        'GridColumnqty
        '
        Me.GridColumnqty.Caption = "Qty"
        Me.GridColumnqty.DisplayFormat.FormatString = "N0"
        Me.GridColumnqty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnqty.FieldName = "qty"
        Me.GridColumnqty.Name = "GridColumnqty"
        Me.GridColumnqty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumnqty.Visible = True
        Me.GridColumnqty.VisibleIndex = 5
        '
        'GridColumnstatus
        '
        Me.GridColumnstatus.Caption = "Status"
        Me.GridColumnstatus.FieldName = "status"
        Me.GridColumnstatus.Name = "GridColumnstatus"
        Me.GridColumnstatus.Visible = True
        Me.GridColumnstatus.VisibleIndex = 6
        '
        'GCStock
        '
        Me.GCStock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCStock.Location = New System.Drawing.Point(0, 0)
        Me.GCStock.MainView = Me.GVStock
        Me.GCStock.Name = "GCStock"
        Me.GCStock.Size = New System.Drawing.Size(678, 340)
        Me.GCStock.TabIndex = 1
        Me.GCStock.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVStock})
        '
        'GVStock
        '
        Me.GVStock.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.GVStock.GridControl = Me.GCStock
        Me.GVStock.Name = "GVStock"
        Me.GVStock.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVStock.OptionsBehavior.Editable = False
        Me.GVStock.OptionsView.ShowFooter = True
        Me.GVStock.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "id_pos_combine_summary"
        Me.GridColumn1.FieldName = "id_pos_combine_summary"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Code"
        Me.GridColumn2.FieldName = "product_full_code"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Style"
        Me.GridColumn3.FieldName = "name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Size"
        Me.GridColumn4.FieldName = "size"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Qty"
        Me.GridColumn5.DisplayFormat.FormatString = "N0"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "qty"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Status"
        Me.GridColumn6.FieldName = "status"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        '
        'GridColumnproduct_full_code
        '
        Me.GridColumnproduct_full_code.Caption = "Product Code"
        Me.GridColumnproduct_full_code.FieldName = "product_full_code"
        Me.GridColumnproduct_full_code.Name = "GridColumnproduct_full_code"
        Me.GridColumnproduct_full_code.Visible = True
        Me.GridColumnproduct_full_code.VisibleIndex = 1
        '
        'GridColumnis_unique_report
        '
        Me.GridColumnis_unique_report.Caption = "is_unique_report"
        Me.GridColumnis_unique_report.FieldName = "is_unique_report"
        Me.GridColumnis_unique_report.Name = "GridColumnis_unique_report"
        '
        'GridColumndesign_price
        '
        Me.GridColumndesign_price.Caption = "Price"
        Me.GridColumndesign_price.DisplayFormat.FormatString = "N2"
        Me.GridColumndesign_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndesign_price.FieldName = "design_price"
        Me.GridColumndesign_price.Name = "GridColumndesign_price"
        Me.GridColumndesign_price.Visible = True
        Me.GridColumndesign_price.VisibleIndex = 4
        '
        'GridColumnid_design_price
        '
        Me.GridColumnid_design_price.Caption = "id_design_price"
        Me.GridColumnid_design_price.FieldName = "id_design_price"
        Me.GridColumnid_design_price.Name = "GridColumnid_design_price"
        '
        'FormSalesPOSCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 411)
        Me.Controls.Add(Me.XTCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormSalesPOSCheck"
        Me.Text = "Checking Result"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.XTPMaster.ResumeLayout(False)
        Me.XTPStock.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnProceed As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPMaster As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPStock As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_pos_combine_summary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnitem_code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCStock As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVStock As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnproduct_full_code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnis_unique_report As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_design_price As DevExpress.XtraGrid.Columns.GridColumn
End Class
