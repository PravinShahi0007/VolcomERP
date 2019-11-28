<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMailManagePendingInvoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMailManagePendingInvoice))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnViewDetail = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_comp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumngroup = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumngroup_description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group_office = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnamount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_total = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPSalesInvoice = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPInvoiceJatuhTempo = New DevExpress.XtraTab.XtraTabPage()
        Me.GCUnpaidData = New DevExpress.XtraGrid.GridControl()
        Me.GVUnpaidData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControlJT = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPSalesInvoice.SuspendLayout()
        Me.XTPInvoiceJatuhTempo.SuspendLayout()
        CType(Me.GCUnpaidData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVUnpaidData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnClose)
        Me.PanelControl1.Controls.Add(Me.BtnViewDetail)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 517)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 44)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnClose
        '
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(585, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(90, 40)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        '
        'BtnViewDetail
        '
        Me.BtnViewDetail.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnViewDetail.Image = CType(resources.GetObject("BtnViewDetail.Image"), System.Drawing.Image)
        Me.BtnViewDetail.Location = New System.Drawing.Point(675, 2)
        Me.BtnViewDetail.Name = "BtnViewDetail"
        Me.BtnViewDetail.Size = New System.Drawing.Size(107, 40)
        Me.BtnViewDetail.TabIndex = 0
        Me.BtnViewDetail.Text = "View Detail"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(758, 512)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_comp_group, Me.GridColumngroup, Me.GridColumngroup_description, Me.GridColumncomp_group_office, Me.GridColumntotal_qty, Me.GridColumnamount, Me.GridColumnsales_pos_total})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_comp_group
        '
        Me.GridColumnid_comp_group.Caption = "id_comp_group"
        Me.GridColumnid_comp_group.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group.Name = "GridColumnid_comp_group"
        '
        'GridColumngroup
        '
        Me.GridColumngroup.Caption = "Group"
        Me.GridColumngroup.FieldName = "group"
        Me.GridColumngroup.Name = "GridColumngroup"
        Me.GridColumngroup.Visible = True
        Me.GridColumngroup.VisibleIndex = 0
        '
        'GridColumngroup_description
        '
        Me.GridColumngroup_description.Caption = "Group Description"
        Me.GridColumngroup_description.FieldName = "group_description"
        Me.GridColumngroup_description.Name = "GridColumngroup_description"
        Me.GridColumngroup_description.Visible = True
        Me.GridColumngroup_description.VisibleIndex = 1
        '
        'GridColumncomp_group_office
        '
        Me.GridColumncomp_group_office.Caption = "Store HO"
        Me.GridColumncomp_group_office.FieldName = "comp_group_office"
        Me.GridColumncomp_group_office.Name = "GridColumncomp_group_office"
        Me.GridColumncomp_group_office.Visible = True
        Me.GridColumncomp_group_office.VisibleIndex = 2
        '
        'GridColumntotal_qty
        '
        Me.GridColumntotal_qty.Caption = "Total Qty"
        Me.GridColumntotal_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_qty.FieldName = "total_qty"
        Me.GridColumntotal_qty.Name = "GridColumntotal_qty"
        Me.GridColumntotal_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_qty", "{0:N0}")})
        Me.GridColumntotal_qty.Visible = True
        Me.GridColumntotal_qty.VisibleIndex = 3
        '
        'GridColumnamount
        '
        Me.GridColumnamount.Caption = "Amount Invoice"
        Me.GridColumnamount.DisplayFormat.FormatString = "N2"
        Me.GridColumnamount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnamount.FieldName = "amount"
        Me.GridColumnamount.Name = "GridColumnamount"
        Me.GridColumnamount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumnamount.Visible = True
        Me.GridColumnamount.VisibleIndex = 5
        '
        'GridColumnsales_pos_total
        '
        Me.GridColumnsales_pos_total.Caption = "Total Sales"
        Me.GridColumnsales_pos_total.DisplayFormat.FormatString = "N2"
        Me.GridColumnsales_pos_total.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnsales_pos_total.FieldName = "sales_pos_total"
        Me.GridColumnsales_pos_total.Name = "GridColumnsales_pos_total"
        Me.GridColumnsales_pos_total.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_total", "{0:N2}")})
        Me.GridColumnsales_pos_total.Visible = True
        Me.GridColumnsales_pos_total.VisibleIndex = 4
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPSalesInvoice
        Me.XtraTabControl1.Size = New System.Drawing.Size(784, 517)
        Me.XtraTabControl1.TabIndex = 2
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPSalesInvoice, Me.XTPInvoiceJatuhTempo})
        '
        'XTPSalesInvoice
        '
        Me.XTPSalesInvoice.Controls.Add(Me.GCData)
        Me.XTPSalesInvoice.Name = "XTPSalesInvoice"
        Me.XTPSalesInvoice.PageVisible = False
        Me.XTPSalesInvoice.Size = New System.Drawing.Size(758, 512)
        Me.XTPSalesInvoice.Text = "Sales Invoice"
        '
        'XTPInvoiceJatuhTempo
        '
        Me.XTPInvoiceJatuhTempo.Controls.Add(Me.GCUnpaidData)
        Me.XTPInvoiceJatuhTempo.Controls.Add(Me.PanelControl2)
        Me.XTPInvoiceJatuhTempo.Name = "XTPInvoiceJatuhTempo"
        Me.XTPInvoiceJatuhTempo.PageVisible = False
        Me.XTPInvoiceJatuhTempo.Size = New System.Drawing.Size(758, 512)
        Me.XTPInvoiceJatuhTempo.Text = "Jatuh Tempo"
        '
        'GCUnpaidData
        '
        Me.GCUnpaidData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCUnpaidData.Location = New System.Drawing.Point(0, 45)
        Me.GCUnpaidData.MainView = Me.GVUnpaidData
        Me.GCUnpaidData.Name = "GCUnpaidData"
        Me.GCUnpaidData.Size = New System.Drawing.Size(758, 467)
        Me.GCUnpaidData.TabIndex = 2
        Me.GCUnpaidData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVUnpaidData})
        '
        'GVUnpaidData
        '
        Me.GVUnpaidData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.GVUnpaidData.GridControl = Me.GCUnpaidData
        Me.GVUnpaidData.Name = "GVUnpaidData"
        Me.GVUnpaidData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVUnpaidData.OptionsBehavior.Editable = False
        Me.GVUnpaidData.OptionsFind.AlwaysVisible = True
        Me.GVUnpaidData.OptionsView.ColumnAutoWidth = False
        Me.GVUnpaidData.OptionsView.ShowFooter = True
        Me.GVUnpaidData.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "id_comp_group"
        Me.GridColumn1.FieldName = "id_comp_group"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Group"
        Me.GridColumn2.FieldName = "group"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Group Description"
        Me.GridColumn3.FieldName = "group_description"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Store HO"
        Me.GridColumn4.FieldName = "comp_group_office"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Total Qty"
        Me.GridColumn5.DisplayFormat.FormatString = "N0"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "total_qty"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_qty", "{0:N0}")})
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Amount Invoice"
        Me.GridColumn6.DisplayFormat.FormatString = "N2"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn6.FieldName = "amount"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 3
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Total Sales"
        Me.GridColumn7.DisplayFormat.FormatString = "N2"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn7.FieldName = "sales_pos_total"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_total", "{0:N2}")})
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.LabelControlJT)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(758, 45)
        Me.PanelControl2.TabIndex = 0
        '
        'LabelControlJT
        '
        Me.LabelControlJT.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControlJT.Appearance.ForeColor = System.Drawing.Color.Maroon
        Me.LabelControlJT.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelControlJT.Location = New System.Drawing.Point(617, 2)
        Me.LabelControlJT.Name = "LabelControlJT"
        Me.LabelControlJT.Padding = New System.Windows.Forms.Padding(0, 7, 5, 0)
        Me.LabelControlJT.Size = New System.Drawing.Size(139, 30)
        Me.LabelControlJT.TabIndex = 8936
        Me.LabelControlJT.Text = "LabelControl1"
        '
        'FormMailManagePendingInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.LookAndFeel.SkinName = "Office 2007 Pink"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MinimizeBox = False
        Me.Name = "FormMailManagePendingInvoice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View By Group"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPSalesInvoice.ResumeLayout(False)
        Me.XTPInvoiceJatuhTempo.ResumeLayout(False)
        CType(Me.GCUnpaidData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVUnpaidData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnViewDetail As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnid_comp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumngroup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumngroup_description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group_office As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnamount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_total As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPSalesInvoice As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPInvoiceJatuhTempo As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCUnpaidData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVUnpaidData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControlJT As DevExpress.XtraEditors.LabelControl
End Class
