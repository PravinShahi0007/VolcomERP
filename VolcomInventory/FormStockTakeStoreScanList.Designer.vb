<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStockTakeStoreScanList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormStockTakeStoreScanList))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnExportToXLS = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_product = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnscanned_code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnqty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnis_unique_not_found_view = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnis_no_tag_view = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemHyperLinkEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.GridColumnunique_code_remark = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnExportToXLS)
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(652, 48)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnExportToXLS
        '
        Me.BtnExportToXLS.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnExportToXLS.Image = CType(resources.GetObject("BtnExportToXLS.Image"), System.Drawing.Image)
        Me.BtnExportToXLS.Location = New System.Drawing.Point(442, 2)
        Me.BtnExportToXLS.Name = "BtnExportToXLS"
        Me.BtnExportToXLS.Size = New System.Drawing.Size(121, 44)
        Me.BtnExportToXLS.TabIndex = 0
        Me.BtnExportToXLS.Text = "Export to XLS"
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(563, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(87, 44)
        Me.BtnPrint.TabIndex = 1
        Me.BtnPrint.Text = "Print"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 48)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemHyperLinkEdit1})
        Me.GCData.Size = New System.Drawing.Size(652, 403)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_product, Me.GridColumnscanned_code, Me.GridColumnname, Me.GridColumnsize, Me.GridColumnqty, Me.GridColumncreated_date, Me.GridColumnis_unique_not_found_view, Me.GridColumnis_no_tag_view, Me.GridColumn1, Me.GridColumnunique_code_remark})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_product
        '
        Me.GridColumnid_product.Caption = "id_product"
        Me.GridColumnid_product.FieldName = "id_product"
        Me.GridColumnid_product.Name = "GridColumnid_product"
        '
        'GridColumnscanned_code
        '
        Me.GridColumnscanned_code.Caption = "Scanned Code"
        Me.GridColumnscanned_code.FieldName = "scanned_code"
        Me.GridColumnscanned_code.Name = "GridColumnscanned_code"
        Me.GridColumnscanned_code.Visible = True
        Me.GridColumnscanned_code.VisibleIndex = 1
        '
        'GridColumnname
        '
        Me.GridColumnname.Caption = "Description"
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
        Me.GridColumnqty.VisibleIndex = 4
        '
        'GridColumncreated_date
        '
        Me.GridColumncreated_date.Caption = "Scanned Date"
        Me.GridColumncreated_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumncreated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumncreated_date.FieldName = "created_date"
        Me.GridColumncreated_date.Name = "GridColumncreated_date"
        Me.GridColumncreated_date.Visible = True
        Me.GridColumncreated_date.VisibleIndex = 0
        '
        'GridColumnis_unique_not_found_view
        '
        Me.GridColumnis_unique_not_found_view.Caption = "Unique Not Found"
        Me.GridColumnis_unique_not_found_view.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnis_unique_not_found_view.FieldName = "is_unique_not_found_view"
        Me.GridColumnis_unique_not_found_view.Name = "GridColumnis_unique_not_found_view"
        Me.GridColumnis_unique_not_found_view.Visible = True
        Me.GridColumnis_unique_not_found_view.VisibleIndex = 6
        Me.GridColumnis_unique_not_found_view.Width = 99
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GridColumnis_no_tag_view
        '
        Me.GridColumnis_no_tag_view.Caption = "No Tag"
        Me.GridColumnis_no_tag_view.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnis_no_tag_view.FieldName = "is_no_tag_view"
        Me.GridColumnis_no_tag_view.Name = "GridColumnis_no_tag_view"
        Me.GridColumnis_no_tag_view.Visible = True
        Me.GridColumnis_no_tag_view.VisibleIndex = 7
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Photo"
        Me.GridColumn1.ColumnEdit = Me.RepositoryItemHyperLinkEdit1
        Me.GridColumn1.FieldName = "image"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 8
        '
        'RepositoryItemHyperLinkEdit1
        '
        Me.RepositoryItemHyperLinkEdit1.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit1.Name = "RepositoryItemHyperLinkEdit1"
        '
        'GridColumnunique_code_remark
        '
        Me.GridColumnunique_code_remark.Caption = "Unique Code Remark"
        Me.GridColumnunique_code_remark.FieldName = "unique_code_remark"
        Me.GridColumnunique_code_remark.Name = "GridColumnunique_code_remark"
        Me.GridColumnunique_code_remark.Visible = True
        Me.GridColumnunique_code_remark.VisibleIndex = 5
        Me.GridColumnunique_code_remark.Width = 163
        '
        'FormStockTakeStoreScanList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 451)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormStockTakeStoreScanList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Scanned Item List"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_product As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnscanned_code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnis_unique_not_found_view As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnis_no_tag_view As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnExportToXLS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemHyperLinkEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents GridColumnunique_code_remark As DevExpress.XtraGrid.Columns.GridColumn
End Class
