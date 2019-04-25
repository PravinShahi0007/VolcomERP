<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesReturnOrder
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
        Me.GCSalesReturnOrder = New DevExpress.XtraGrid.GridControl()
        Me.GVSalesReturnOrder = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnSalesTargetNumb = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSalesTargetDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEstDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDSalesTargetNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrepareStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XTCROR = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPOrder = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPOnHold = New DevExpress.XtraTab.XtraTabPage()
        Me.GCOnHold = New DevExpress.XtraGrid.GridControl()
        Me.GVOnHold = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControlNavOnHold = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEStore = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_sales_return_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_sales_return_order_det = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_return_order_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_return_order_est_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1sales_return_order_est_del_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstore = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_product = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCSalesReturnOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSalesReturnOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCROR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCROR.SuspendLayout()
        Me.XTPOrder.SuspendLayout()
        Me.XTPOnHold.SuspendLayout()
        CType(Me.GCOnHold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOnHold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlNavOnHold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNavOnHold.SuspendLayout()
        CType(Me.SLEStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCSalesReturnOrder
        '
        Me.GCSalesReturnOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSalesReturnOrder.Location = New System.Drawing.Point(0, 0)
        Me.GCSalesReturnOrder.MainView = Me.GVSalesReturnOrder
        Me.GCSalesReturnOrder.Name = "GCSalesReturnOrder"
        Me.GCSalesReturnOrder.Size = New System.Drawing.Size(710, 398)
        Me.GCSalesReturnOrder.TabIndex = 2
        Me.GCSalesReturnOrder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSalesReturnOrder, Me.GridView2})
        '
        'GVSalesReturnOrder
        '
        Me.GVSalesReturnOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnSalesTargetNumb, Me.GridColumnTo, Me.GridColumnSalesTargetDate, Me.GridColumnEstDate, Me.GridColumnDSalesTargetNote, Me.GridColumnReportStatus, Me.GridColumnPrepareStatus})
        Me.GVSalesReturnOrder.GridControl = Me.GCSalesReturnOrder
        Me.GVSalesReturnOrder.Name = "GVSalesReturnOrder"
        Me.GVSalesReturnOrder.OptionsBehavior.ReadOnly = True
        Me.GVSalesReturnOrder.OptionsFind.AlwaysVisible = True
        Me.GVSalesReturnOrder.OptionsView.ShowGroupPanel = False
        '
        'GridColumnSalesTargetNumb
        '
        Me.GridColumnSalesTargetNumb.Caption = "Number"
        Me.GridColumnSalesTargetNumb.FieldName = "sales_return_order_number"
        Me.GridColumnSalesTargetNumb.Name = "GridColumnSalesTargetNumb"
        Me.GridColumnSalesTargetNumb.Visible = True
        Me.GridColumnSalesTargetNumb.VisibleIndex = 0
        Me.GridColumnSalesTargetNumb.Width = 83
        '
        'GridColumnTo
        '
        Me.GridColumnTo.Caption = "To"
        Me.GridColumnTo.FieldName = "store_name_to"
        Me.GridColumnTo.Name = "GridColumnTo"
        Me.GridColumnTo.Visible = True
        Me.GridColumnTo.VisibleIndex = 1
        '
        'GridColumnSalesTargetDate
        '
        Me.GridColumnSalesTargetDate.Caption = "Created Date"
        Me.GridColumnSalesTargetDate.FieldName = "sales_return_order_date"
        Me.GridColumnSalesTargetDate.Name = "GridColumnSalesTargetDate"
        Me.GridColumnSalesTargetDate.Visible = True
        Me.GridColumnSalesTargetDate.VisibleIndex = 2
        '
        'GridColumnEstDate
        '
        Me.GridColumnEstDate.Caption = "Estimate Return"
        Me.GridColumnEstDate.FieldName = "sales_return_order_est_date"
        Me.GridColumnEstDate.Name = "GridColumnEstDate"
        Me.GridColumnEstDate.Visible = True
        Me.GridColumnEstDate.VisibleIndex = 3
        '
        'GridColumnDSalesTargetNote
        '
        Me.GridColumnDSalesTargetNote.Caption = "Note"
        Me.GridColumnDSalesTargetNote.FieldName = "sales_return_order_note"
        Me.GridColumnDSalesTargetNote.Name = "GridColumnDSalesTargetNote"
        Me.GridColumnDSalesTargetNote.Visible = True
        Me.GridColumnDSalesTargetNote.VisibleIndex = 4
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        Me.GridColumnReportStatus.Visible = True
        Me.GridColumnReportStatus.VisibleIndex = 5
        '
        'GridColumnPrepareStatus
        '
        Me.GridColumnPrepareStatus.Caption = "WH Status"
        Me.GridColumnPrepareStatus.FieldName = "prepare_status"
        Me.GridColumnPrepareStatus.Name = "GridColumnPrepareStatus"
        Me.GridColumnPrepareStatus.Visible = True
        Me.GridColumnPrepareStatus.VisibleIndex = 6
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCSalesReturnOrder
        Me.GridView2.Name = "GridView2"
        '
        'XTCROR
        '
        Me.XTCROR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCROR.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCROR.Location = New System.Drawing.Point(0, 0)
        Me.XTCROR.Name = "XTCROR"
        Me.XTCROR.SelectedTabPage = Me.XTPOrder
        Me.XTCROR.Size = New System.Drawing.Size(716, 426)
        Me.XTCROR.TabIndex = 3
        Me.XTCROR.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPOrder, Me.XTPOnHold})
        '
        'XTPOrder
        '
        Me.XTPOrder.Controls.Add(Me.GCSalesReturnOrder)
        Me.XTPOrder.Name = "XTPOrder"
        Me.XTPOrder.Size = New System.Drawing.Size(710, 398)
        Me.XTPOrder.Text = "Return Order List"
        '
        'XTPOnHold
        '
        Me.XTPOnHold.Controls.Add(Me.GCOnHold)
        Me.XTPOnHold.Controls.Add(Me.PanelControlNavOnHold)
        Me.XTPOnHold.Name = "XTPOnHold"
        Me.XTPOnHold.Size = New System.Drawing.Size(710, 398)
        Me.XTPOnHold.Text = "On Hold"
        '
        'GCOnHold
        '
        Me.GCOnHold.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOnHold.Location = New System.Drawing.Point(0, 46)
        Me.GCOnHold.MainView = Me.GVOnHold
        Me.GCOnHold.Name = "GCOnHold"
        Me.GCOnHold.Size = New System.Drawing.Size(710, 352)
        Me.GCOnHold.TabIndex = 1
        Me.GCOnHold.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOnHold})
        '
        'GVOnHold
        '
        Me.GVOnHold.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_sales_return_order, Me.GridColumnid_sales_return_order_det, Me.GridColumnsales_return_order_date, Me.GridColumnsales_return_order_est_date, Me.GridColumn1sales_return_order_est_del_date, Me.GridColumnstore, Me.GridColumnid_product})
        Me.GVOnHold.GridControl = Me.GCOnHold
        Me.GVOnHold.Name = "GVOnHold"
        Me.GVOnHold.OptionsBehavior.Editable = False
        Me.GVOnHold.OptionsFind.AlwaysVisible = True
        Me.GVOnHold.OptionsView.ShowGroupPanel = False
        '
        'PanelControlNavOnHold
        '
        Me.PanelControlNavOnHold.Controls.Add(Me.SLEStore)
        Me.PanelControlNavOnHold.Controls.Add(Me.BtnView)
        Me.PanelControlNavOnHold.Controls.Add(Me.LabelControl1)
        Me.PanelControlNavOnHold.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNavOnHold.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlNavOnHold.Name = "PanelControlNavOnHold"
        Me.PanelControlNavOnHold.Size = New System.Drawing.Size(710, 46)
        Me.PanelControlNavOnHold.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(15, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Store"
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(284, 11)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 23)
        Me.BtnView.TabIndex = 4
        Me.BtnView.Text = "View"
        '
        'SLEStore
        '
        Me.SLEStore.Location = New System.Drawing.Point(50, 14)
        Me.SLEStore.Name = "SLEStore"
        Me.SLEStore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStore.Properties.View = Me.GridView1
        Me.SLEStore.Size = New System.Drawing.Size(228, 20)
        Me.SLEStore.TabIndex = 8895
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn5, Me.GridColumn6, Me.GridColumn19})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Id Comp"
        Me.GridColumn5.FieldName = "id_comp"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Account"
        Me.GridColumn6.FieldName = "comp_number"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Description"
        Me.GridColumn19.FieldName = "comp_name"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 1
        '
        'GridColumnid_sales_return_order
        '
        Me.GridColumnid_sales_return_order.Caption = "Id "
        Me.GridColumnid_sales_return_order.FieldName = "id_sales_return_order"
        Me.GridColumnid_sales_return_order.Name = "GridColumnid_sales_return_order"
        '
        'GridColumnid_sales_return_order_det
        '
        Me.GridColumnid_sales_return_order_det.Caption = "Id Detail"
        Me.GridColumnid_sales_return_order_det.FieldName = "id_sales_return_order_det"
        Me.GridColumnid_sales_return_order_det.Name = "GridColumnid_sales_return_order_det"
        '
        'GridColumnsales_return_order_date
        '
        Me.GridColumnsales_return_order_date.Caption = "Created Date"
        Me.GridColumnsales_return_order_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsales_return_order_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_return_order_date.FieldName = "sales_return_order_date"
        Me.GridColumnsales_return_order_date.Name = "GridColumnsales_return_order_date"
        Me.GridColumnsales_return_order_date.Visible = True
        Me.GridColumnsales_return_order_date.VisibleIndex = 0
        '
        'GridColumnsales_return_order_est_date
        '
        Me.GridColumnsales_return_order_est_date.Caption = "Est. Return Date"
        Me.GridColumnsales_return_order_est_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsales_return_order_est_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_return_order_est_date.FieldName = "sales_return_order_est_date"
        Me.GridColumnsales_return_order_est_date.Name = "GridColumnsales_return_order_est_date"
        Me.GridColumnsales_return_order_est_date.Visible = True
        Me.GridColumnsales_return_order_est_date.VisibleIndex = 1
        '
        'GridColumn1sales_return_order_est_del_date
        '
        Me.GridColumn1sales_return_order_est_del_date.Caption = "Est. Delivery Date"
        Me.GridColumn1sales_return_order_est_del_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn1sales_return_order_est_del_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn1sales_return_order_est_del_date.FieldName = "sales_return_order_est_del_date"
        Me.GridColumn1sales_return_order_est_del_date.Name = "GridColumn1sales_return_order_est_del_date"
        Me.GridColumn1sales_return_order_est_del_date.Visible = True
        Me.GridColumn1sales_return_order_est_del_date.VisibleIndex = 2
        '
        'GridColumnstore
        '
        Me.GridColumnstore.Caption = "Store"
        Me.GridColumnstore.FieldName = "store"
        Me.GridColumnstore.Name = "GridColumnstore"
        Me.GridColumnstore.Visible = True
        Me.GridColumnstore.VisibleIndex = 3
        '
        'GridColumnid_product
        '
        Me.GridColumnid_product.Caption = "Id Product"
        Me.GridColumnid_product.FieldName = "id_product"
        Me.GridColumnid_product.Name = "GridColumnid_product"
        '
        'FormSalesReturnOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 426)
        Me.Controls.Add(Me.XTCROR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesReturnOrder"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Return Order"
        CType(Me.GCSalesReturnOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSalesReturnOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCROR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCROR.ResumeLayout(False)
        Me.XTPOrder.ResumeLayout(False)
        Me.XTPOnHold.ResumeLayout(False)
        CType(Me.GCOnHold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVOnHold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlNavOnHold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNavOnHold.ResumeLayout(False)
        Me.PanelControlNavOnHold.PerformLayout()
        CType(Me.SLEStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCSalesReturnOrder As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSalesReturnOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnSalesTargetNumb As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSalesTargetDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDSalesTargetNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnEstDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrepareStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTCROR As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPOrder As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPOnHold As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCOnHold As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOnHold As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControlNavOnHold As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEStore As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_sales_return_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_sales_return_order_det As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_return_order_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_return_order_est_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1sales_return_order_est_del_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstore As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_product As DevExpress.XtraGrid.Columns.GridColumn
End Class
