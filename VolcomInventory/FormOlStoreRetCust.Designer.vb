<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormOlStoreRetCust
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
        Me.XTCRetCust = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPRetList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCRetCust = New DevExpress.XtraGrid.GridControl()
        Me.GVRetCust = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPRetReq = New DevExpress.XtraTab.XtraTabPage()
        Me.GCRetReq = New DevExpress.XtraGrid.GridControl()
        Me.GVRetReq = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BRetCust = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SLECompGroup = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLEOrder = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.XTCRetCust, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCRetCust.SuspendLayout()
        Me.XTPRetList.SuspendLayout()
        CType(Me.GCRetCust, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRetCust, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPRetReq.SuspendLayout()
        CType(Me.GCRetReq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRetReq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLECompGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCRetCust
        '
        Me.XTCRetCust.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCRetCust.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCRetCust.Location = New System.Drawing.Point(0, 46)
        Me.XTCRetCust.Name = "XTCRetCust"
        Me.XTCRetCust.SelectedTabPage = Me.XTPRetList
        Me.XTCRetCust.Size = New System.Drawing.Size(1026, 502)
        Me.XTCRetCust.TabIndex = 0
        Me.XTCRetCust.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPRetList, Me.XTPRetReq})
        '
        'XTPRetList
        '
        Me.XTPRetList.Controls.Add(Me.GCRetCust)
        Me.XTPRetList.Name = "XTPRetList"
        Me.XTPRetList.Size = New System.Drawing.Size(1020, 474)
        Me.XTPRetList.Text = "Transaction List"
        '
        'GCRetCust
        '
        Me.GCRetCust.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRetCust.Location = New System.Drawing.Point(0, 0)
        Me.GCRetCust.MainView = Me.GVRetCust
        Me.GCRetCust.Name = "GCRetCust"
        Me.GCRetCust.Size = New System.Drawing.Size(1020, 474)
        Me.GCRetCust.TabIndex = 0
        Me.GCRetCust.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRetCust})
        '
        'GVRetCust
        '
        Me.GVRetCust.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn7, Me.GridColumn19, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12})
        Me.GVRetCust.GridControl = Me.GCRetCust
        Me.GVRetCust.Name = "GVRetCust"
        Me.GVRetCust.OptionsView.ShowGroupPanel = False
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "ID"
        Me.GridColumn7.FieldName = "id_ol_store_cust_ret"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Order#"
        Me.GridColumn19.FieldName = "sales_order_ol_shop_number"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 1
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Store Group"
        Me.GridColumn8.FieldName = "store_group"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 0
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Created Date"
        Me.GridColumn9.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn9.FieldName = "created_date"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 3
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Created By"
        Me.GridColumn10.FieldName = "employee_name"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 4
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Number"
        Me.GridColumn11.FieldName = "number"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 2
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Report Status"
        Me.GridColumn12.FieldName = "report_status"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 5
        '
        'XTPRetReq
        '
        Me.XTPRetReq.Controls.Add(Me.GCRetReq)
        Me.XTPRetReq.Controls.Add(Me.BRetCust)
        Me.XTPRetReq.Name = "XTPRetReq"
        Me.XTPRetReq.Size = New System.Drawing.Size(1020, 474)
        Me.XTPRetReq.Text = "Return Request List"
        '
        'GCRetReq
        '
        Me.GCRetReq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRetReq.Location = New System.Drawing.Point(0, 0)
        Me.GCRetReq.MainView = Me.GVRetReq
        Me.GCRetReq.Name = "GCRetReq"
        Me.GCRetReq.Size = New System.Drawing.Size(1020, 442)
        Me.GCRetReq.TabIndex = 1
        Me.GCRetReq.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRetReq})
        '
        'GVRetReq
        '
        Me.GVRetReq.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn6, Me.GridColumn2, Me.GridColumn18, Me.GridColumn5, Me.GridColumn3, Me.GridColumn4, Me.GridColumn17})
        Me.GVRetReq.GridControl = Me.GCRetReq
        Me.GVRetReq.Name = "GVRetReq"
        Me.GVRetReq.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_ol_store_ret_list"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Store Group"
        Me.GridColumn6.FieldName = "store_group"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        Me.GridColumn6.Width = 233
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Order#"
        Me.GridColumn2.FieldName = "sales_order_ol_shop_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 233
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Pre Return Number"
        Me.GridColumn18.FieldName = "number"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 3
        Me.GridColumn18.Width = 233
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Return Request Number"
        Me.GridColumn5.FieldName = "ret_req_number"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        Me.GridColumn5.Width = 233
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Code"
        Me.GridColumn3.FieldName = "full_code"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 4
        Me.GridColumn3.Width = 233
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Description"
        Me.GridColumn4.FieldName = "product_display_name"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 5
        Me.GridColumn4.Width = 327
        '
        'GridColumn17
        '
        Me.GridColumn17.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn17.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn17.Caption = "Size"
        Me.GridColumn17.FieldName = "size"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 6
        Me.GridColumn17.Width = 140
        '
        'BRetCust
        '
        Me.BRetCust.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BRetCust.Location = New System.Drawing.Point(0, 442)
        Me.BRetCust.Name = "BRetCust"
        Me.BRetCust.Size = New System.Drawing.Size(1020, 32)
        Me.BRetCust.TabIndex = 2
        Me.BRetCust.Text = "Create Return to Customer"
        Me.BRetCust.Visible = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SLECompGroup)
        Me.PanelControl1.Controls.Add(Me.SLEOrder)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.BSearch)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1026, 46)
        Me.PanelControl1.TabIndex = 1
        '
        'SLECompGroup
        '
        Me.SLECompGroup.Location = New System.Drawing.Point(45, 12)
        Me.SLECompGroup.Name = "SLECompGroup"
        Me.SLECompGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLECompGroup.Properties.View = Me.GridView1
        Me.SLECompGroup.Size = New System.Drawing.Size(185, 20)
        Me.SLECompGroup.TabIndex = 7
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn13, Me.GridColumn14, Me.GridColumn15})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "ID"
        Me.GridColumn13.FieldName = "id_comp_group"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Group"
        Me.GridColumn14.FieldName = "comp_group"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Description"
        Me.GridColumn15.FieldName = "description"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 1
        '
        'SLEOrder
        '
        Me.SLEOrder.Location = New System.Drawing.Point(310, 12)
        Me.SLEOrder.Name = "SLEOrder"
        Me.SLEOrder.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEOrder.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEOrder.Size = New System.Drawing.Size(185, 20)
        Me.SLEOrder.TabIndex = 6
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn16})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Order Number"
        Me.GridColumn16.FieldName = "sales_order_ol_shop_number"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 0
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(10, 15)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl2.TabIndex = 5
        Me.LabelControl2.Text = "Group"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(236, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(68, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Order Number"
        '
        'BSearch
        '
        Me.BSearch.Location = New System.Drawing.Point(501, 10)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(62, 23)
        Me.BSearch.TabIndex = 0
        Me.BSearch.Text = "Search"
        '
        'FormOlStoreRetCust
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1026, 548)
        Me.Controls.Add(Me.XTCRetCust)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormOlStoreRetCust"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "VIOS Return Refuse"
        CType(Me.XTCRetCust, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCRetCust.ResumeLayout(False)
        Me.XTPRetList.ResumeLayout(False)
        CType(Me.GCRetCust, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRetCust, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPRetReq.ResumeLayout(False)
        CType(Me.GCRetReq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRetReq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLECompGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCRetCust As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPRetList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPRetReq As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCRetCust As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRetCust As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCRetReq As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRetReq As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLECompGroup As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEOrder As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BRetCust As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
End Class
