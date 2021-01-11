<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCompareStockWebsite
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCompareStockWebsite))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelLast = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SBExport = New DevExpress.XtraEditors.SimpleButton()
        Me.SBSync = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnHistory = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControlStock = New DevExpress.XtraGrid.GridControl()
        Me.GridViewStock = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnqty_web_open = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnqty_web_all = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GridControlStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelLast)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Controls.Add(Me.SBExport)
        Me.PanelControl1.Controls.Add(Me.SBSync)
        Me.PanelControl1.Controls.Add(Me.BtnHistory)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 40)
        Me.PanelControl1.TabIndex = 0
        '
        'LabelLast
        '
        Me.LabelLast.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLast.Location = New System.Drawing.Point(287, 12)
        Me.LabelLast.Name = "LabelLast"
        Me.LabelLast.Size = New System.Drawing.Size(5, 13)
        Me.LabelLast.TabIndex = 4
        Me.LabelLast.Text = "-"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(227, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Last Sync : "
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Left
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(94, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(127, 36)
        Me.SimpleButton1.TabIndex = 2
        Me.SimpleButton1.Text = "View Last Sync"
        '
        'SBExport
        '
        Me.SBExport.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBExport.Image = CType(resources.GetObject("SBExport.Image"), System.Drawing.Image)
        Me.SBExport.Location = New System.Drawing.Point(551, 2)
        Me.SBExport.Name = "SBExport"
        Me.SBExport.Size = New System.Drawing.Size(94, 36)
        Me.SBExport.TabIndex = 1
        Me.SBExport.Text = "Export XLS"
        '
        'SBSync
        '
        Me.SBSync.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBSync.Image = CType(resources.GetObject("SBSync.Image"), System.Drawing.Image)
        Me.SBSync.Location = New System.Drawing.Point(645, 2)
        Me.SBSync.Name = "SBSync"
        Me.SBSync.Size = New System.Drawing.Size(137, 36)
        Me.SBSync.TabIndex = 0
        Me.SBSync.Text = "Sync From Website"
        '
        'BtnHistory
        '
        Me.BtnHistory.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnHistory.Image = CType(resources.GetObject("BtnHistory.Image"), System.Drawing.Image)
        Me.BtnHistory.Location = New System.Drawing.Point(2, 2)
        Me.BtnHistory.Name = "BtnHistory"
        Me.BtnHistory.Size = New System.Drawing.Size(92, 36)
        Me.BtnHistory.TabIndex = 5
        Me.BtnHistory.Text = "History"
        '
        'GridControlStock
        '
        Me.GridControlStock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlStock.Location = New System.Drawing.Point(0, 40)
        Me.GridControlStock.MainView = Me.GridViewStock
        Me.GridControlStock.Name = "GridControlStock"
        Me.GridControlStock.Size = New System.Drawing.Size(784, 521)
        Me.GridControlStock.TabIndex = 1
        Me.GridControlStock.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewStock})
        '
        'GridViewStock
        '
        Me.GridViewStock.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand2, Me.gridBand3, Me.gridBand4})
        Me.GridViewStock.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.BandedGridColumnqty_web_open, Me.BandedGridColumnqty_web_all})
        Me.GridViewStock.GridControl = Me.GridControlStock
        Me.GridViewStock.Name = "GridViewStock"
        Me.GridViewStock.OptionsBehavior.ReadOnly = True
        Me.GridViewStock.OptionsFind.AlwaysVisible = True
        Me.GridViewStock.OptionsView.ShowFooter = True
        Me.GridViewStock.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Code"
        Me.GridColumn1.FieldName = "product_full_code"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Description"
        Me.GridColumn2.FieldName = "name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Size"
        Me.GridColumn3.FieldName = "size"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Normal"
        Me.GridColumn4.DisplayFormat.FormatString = "N0"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "qty_acc_normal"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_acc_normal", "{0:N0}")})
        Me.GridColumn4.Visible = True
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Sale"
        Me.GridColumn5.DisplayFormat.FormatString = "N0"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "qty_acc_sale"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_acc_sale", "{0:N0}")})
        Me.GridColumn5.Visible = True
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Total"
        Me.GridColumn6.DisplayFormat.FormatString = "N0"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn6.FieldName = "qty_acc_total"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_acc_total", "{0:N0}")})
        Me.GridColumn6.Visible = True
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Available"
        Me.GridColumn7.DisplayFormat.FormatString = "N0"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn7.FieldName = "qty_web"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_web", "{0:N0}")})
        Me.GridColumn7.Visible = True
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Match"
        Me.GridColumn8.FieldName = "match"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        '
        'BandedGridColumnqty_web_open
        '
        Me.BandedGridColumnqty_web_open.Caption = "Booked"
        Me.BandedGridColumnqty_web_open.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnqty_web_open.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnqty_web_open.FieldName = "qty_web_open"
        Me.BandedGridColumnqty_web_open.Name = "BandedGridColumnqty_web_open"
        Me.BandedGridColumnqty_web_open.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_web_open", "{0:N0}")})
        Me.BandedGridColumnqty_web_open.Visible = True
        '
        'BandedGridColumnqty_web_all
        '
        Me.BandedGridColumnqty_web_all.Caption = "Total"
        Me.BandedGridColumnqty_web_all.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnqty_web_all.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnqty_web_all.FieldName = "qty_web_all"
        Me.BandedGridColumnqty_web_all.Name = "BandedGridColumnqty_web_all"
        Me.BandedGridColumnqty_web_all.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_web_all", "{0:N0}")})
        Me.BandedGridColumnqty_web_all.Visible = True
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "Product"
        Me.GridBand1.Columns.Add(Me.GridColumn1)
        Me.GridBand1.Columns.Add(Me.GridColumn2)
        Me.GridBand1.Columns.Add(Me.GridColumn3)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 225
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "ERP"
        Me.gridBand2.Columns.Add(Me.GridColumn4)
        Me.gridBand2.Columns.Add(Me.GridColumn5)
        Me.gridBand2.Columns.Add(Me.GridColumn6)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 225
        '
        'gridBand3
        '
        Me.gridBand3.Caption = "SHOPIFY"
        Me.gridBand3.Columns.Add(Me.GridColumn7)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnqty_web_open)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnqty_web_all)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 2
        Me.gridBand3.Width = 225
        '
        'gridBand4
        '
        Me.gridBand4.Columns.Add(Me.GridColumn8)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 3
        Me.gridBand4.Width = 75
        '
        'FormCompareStockWebsite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GridControlStock)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormCompareStockWebsite"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compare Stock Website"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.GridControlStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridControlStock As DevExpress.XtraGrid.GridControl
    Friend WithEvents SBSync As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBExport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelLast As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnHistory As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridViewStock As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnqty_web_open As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnqty_web_all As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
