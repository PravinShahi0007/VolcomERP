<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpPD
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
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl
        Me.GroupControlProdNumber = New DevExpress.XtraEditors.GroupControl
        Me.GCProdDemand = New DevExpress.XtraGrid.GridControl
        Me.GVProdDemand = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnProdDemand = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnProdDemandNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdReportStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColReportStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.GCProduct = New DevExpress.XtraGrid.GridControl
        Me.GVProduct = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnCodeFull = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDelivery = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStyleOrigin = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStyleCountry = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnAging = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnReturn = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnEstimateCost = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnProposePrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnMarkUp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQuantitiy = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnTotalCost = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnTotalAmount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDesign = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCategory = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BChoose = New DevExpress.XtraEditors.SimpleButton
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupControlProdNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlProdNumber.SuspendLayout()
        CType(Me.GCProdDemand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProdDemand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupControlProdNumber)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupControl1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(955, 482)
        Me.SplitContainerControl1.SplitterPosition = 200
        Me.SplitContainerControl1.TabIndex = 5
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupControlProdNumber
        '
        Me.GroupControlProdNumber.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlProdNumber.Controls.Add(Me.GCProdDemand)
        Me.GroupControlProdNumber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlProdNumber.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlProdNumber.Name = "GroupControlProdNumber"
        Me.GroupControlProdNumber.Size = New System.Drawing.Size(955, 200)
        Me.GroupControlProdNumber.TabIndex = 0
        Me.GroupControlProdNumber.Text = "PD Number"
        '
        'GCProdDemand
        '
        Me.GCProdDemand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProdDemand.Location = New System.Drawing.Point(22, 2)
        Me.GCProdDemand.MainView = Me.GVProdDemand
        Me.GCProdDemand.Name = "GCProdDemand"
        Me.GCProdDemand.Size = New System.Drawing.Size(931, 196)
        Me.GCProdDemand.TabIndex = 0
        Me.GCProdDemand.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProdDemand})
        '
        'GVProdDemand
        '
        Me.GVProdDemand.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnProdDemand, Me.GridColumnProdDemandNumber, Me.GridColumnSeason, Me.GridColumnIdSeason, Me.ColIdReportStatus, Me.ColReportStatus})
        Me.GVProdDemand.GridControl = Me.GCProdDemand
        Me.GVProdDemand.Name = "GVProdDemand"
        Me.GVProdDemand.OptionsBehavior.Editable = False
        Me.GVProdDemand.OptionsFind.AlwaysVisible = True
        Me.GVProdDemand.OptionsView.ShowGroupPanel = False
        '
        'GridColumnProdDemand
        '
        Me.GridColumnProdDemand.Caption = "ID"
        Me.GridColumnProdDemand.FieldName = "id_prod_demand"
        Me.GridColumnProdDemand.Name = "GridColumnProdDemand"
        '
        'GridColumnProdDemandNumber
        '
        Me.GridColumnProdDemandNumber.Caption = "Production Demand Number"
        Me.GridColumnProdDemandNumber.FieldName = "prod_demand_number"
        Me.GridColumnProdDemandNumber.Name = "GridColumnProdDemandNumber"
        Me.GridColumnProdDemandNumber.Visible = True
        Me.GridColumnProdDemandNumber.VisibleIndex = 0
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        Me.GridColumnSeason.Visible = True
        Me.GridColumnSeason.VisibleIndex = 1
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "Id season"
        Me.GridColumnIdSeason.FieldName = "id_season"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        '
        'ColIdReportStatus
        '
        Me.ColIdReportStatus.Caption = "Id Status"
        Me.ColIdReportStatus.FieldName = "id_report_status"
        Me.ColIdReportStatus.Name = "ColIdReportStatus"
        '
        'ColReportStatus
        '
        Me.ColReportStatus.Caption = "Status"
        Me.ColReportStatus.FieldName = "report_status"
        Me.ColReportStatus.Name = "ColReportStatus"
        Me.ColReportStatus.Visible = True
        Me.ColReportStatus.VisibleIndex = 2
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.GCProduct)
        Me.GroupControl1.Controls.Add(Me.PanelControl1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(955, 277)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Product List"
        '
        'GCProduct
        '
        Me.GCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProduct.Location = New System.Drawing.Point(22, 2)
        Me.GCProduct.MainView = Me.GVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.Size = New System.Drawing.Size(931, 236)
        Me.GCProduct.TabIndex = 4
        Me.GCProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProduct})
        '
        'GVProduct
        '
        Me.GVProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCodeFull, Me.GridColumnDelivery, Me.GridColumnStyleOrigin, Me.GridColumnStyleCountry, Me.GridColumnColor, Me.GridColumnSize, Me.GridColumnAging, Me.GridColumnReturn, Me.GridColumnEstimateCost, Me.GridColumnProposePrice, Me.GridColumnMarkUp, Me.GridColumnQuantitiy, Me.GridColumnTotalCost, Me.GridColumnTotalAmount, Me.GridColumnDesign, Me.GridColumnCategory})
        Me.GVProduct.GridControl = Me.GCProduct
        Me.GVProduct.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_demand_product_qty", Me.GridColumnQuantitiy, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_cost", Me.GridColumnTotalCost, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_amount", Me.GridColumnTotalAmount, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "mark_up", Me.GridColumnMarkUp, "Sub Total")})
        Me.GVProduct.Name = "GVProduct"
        Me.GVProduct.OptionsBehavior.Editable = False
        Me.GVProduct.OptionsFind.AlwaysVisible = True
        Me.GVProduct.OptionsView.ShowFooter = True
        Me.GVProduct.OptionsView.ShowGroupPanel = False
        '
        'GridColumnCodeFull
        '
        Me.GridColumnCodeFull.Caption = "Code"
        Me.GridColumnCodeFull.FieldName = "product_full_code"
        Me.GridColumnCodeFull.Name = "GridColumnCodeFull"
        Me.GridColumnCodeFull.Visible = True
        Me.GridColumnCodeFull.VisibleIndex = 0
        Me.GridColumnCodeFull.Width = 150
        '
        'GridColumnDelivery
        '
        Me.GridColumnDelivery.Caption = "Delivery"
        Me.GridColumnDelivery.FieldName = "delivery"
        Me.GridColumnDelivery.Name = "GridColumnDelivery"
        '
        'GridColumnStyleOrigin
        '
        Me.GridColumnStyleOrigin.Caption = "Style Origin"
        Me.GridColumnStyleOrigin.FieldName = "season_orign_display"
        Me.GridColumnStyleOrigin.Name = "GridColumnStyleOrigin"
        '
        'GridColumnStyleCountry
        '
        Me.GridColumnStyleCountry.Caption = "Style Country"
        Me.GridColumnStyleCountry.FieldName = "country_orign"
        Me.GridColumnStyleCountry.Name = "GridColumnStyleCountry"
        '
        'GridColumnColor
        '
        Me.GridColumnColor.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "Color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 1
        Me.GridColumnColor.Width = 46
        '
        'GridColumnSize
        '
        Me.GridColumnSize.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "Size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 2
        Me.GridColumnSize.Width = 46
        '
        'GridColumnAging
        '
        Me.GridColumnAging.Caption = "Aging (day)"
        Me.GridColumnAging.FieldName = "lifetime"
        Me.GridColumnAging.Name = "GridColumnAging"
        '
        'GridColumnReturn
        '
        Me.GridColumnReturn.Caption = "Return"
        Me.GridColumnReturn.FieldName = "return_date"
        Me.GridColumnReturn.Name = "GridColumnReturn"
        '
        'GridColumnEstimateCost
        '
        Me.GridColumnEstimateCost.Caption = "Estimate Cost"
        Me.GridColumnEstimateCost.DisplayFormat.FormatString = "N2"
        Me.GridColumnEstimateCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnEstimateCost.FieldName = "estimate_cost"
        Me.GridColumnEstimateCost.Name = "GridColumnEstimateCost"
        Me.GridColumnEstimateCost.Visible = True
        Me.GridColumnEstimateCost.VisibleIndex = 3
        Me.GridColumnEstimateCost.Width = 93
        '
        'GridColumnProposePrice
        '
        Me.GridColumnProposePrice.Caption = "Propose Price"
        Me.GridColumnProposePrice.DisplayFormat.FormatString = "N2"
        Me.GridColumnProposePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnProposePrice.FieldName = "prod_demand_design_propose_price"
        Me.GridColumnProposePrice.Name = "GridColumnProposePrice"
        Me.GridColumnProposePrice.Visible = True
        Me.GridColumnProposePrice.VisibleIndex = 4
        Me.GridColumnProposePrice.Width = 93
        '
        'GridColumnMarkUp
        '
        Me.GridColumnMarkUp.Caption = "Mark Up"
        Me.GridColumnMarkUp.FieldName = "mark_up"
        Me.GridColumnMarkUp.Name = "GridColumnMarkUp"
        Me.GridColumnMarkUp.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "mark_up", "Total")})
        '
        'GridColumnQuantitiy
        '
        Me.GridColumnQuantitiy.Caption = "Quantitiy"
        Me.GridColumnQuantitiy.DisplayFormat.FormatString = "N2"
        Me.GridColumnQuantitiy.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQuantitiy.FieldName = "prod_demand_product_qty"
        Me.GridColumnQuantitiy.Name = "GridColumnQuantitiy"
        Me.GridColumnQuantitiy.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_demand_product_qty", "{0:N2}")})
        Me.GridColumnQuantitiy.Visible = True
        Me.GridColumnQuantitiy.VisibleIndex = 5
        Me.GridColumnQuantitiy.Width = 93
        '
        'GridColumnTotalCost
        '
        Me.GridColumnTotalCost.Caption = "Total Cost"
        Me.GridColumnTotalCost.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotalCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotalCost.FieldName = "total_cost"
        Me.GridColumnTotalCost.Name = "GridColumnTotalCost"
        Me.GridColumnTotalCost.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_cost", "{0:N2}")})
        Me.GridColumnTotalCost.Visible = True
        Me.GridColumnTotalCost.VisibleIndex = 6
        Me.GridColumnTotalCost.Width = 93
        '
        'GridColumnTotalAmount
        '
        Me.GridColumnTotalAmount.Caption = "Total Amount"
        Me.GridColumnTotalAmount.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotalAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotalAmount.FieldName = "total_amount"
        Me.GridColumnTotalAmount.Name = "GridColumnTotalAmount"
        Me.GridColumnTotalAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_amount", "{0:N2}")})
        Me.GridColumnTotalAmount.Visible = True
        Me.GridColumnTotalAmount.VisibleIndex = 7
        Me.GridColumnTotalAmount.Width = 93
        '
        'GridColumnDesign
        '
        Me.GridColumnDesign.Caption = "Design"
        Me.GridColumnDesign.FieldName = "design_name"
        Me.GridColumnDesign.Name = "GridColumnDesign"
        Me.GridColumnDesign.Visible = True
        Me.GridColumnDesign.VisibleIndex = 8
        Me.GridColumnDesign.Width = 93
        '
        'GridColumnCategory
        '
        Me.GridColumnCategory.Caption = "Category"
        Me.GridColumnCategory.FieldName = "category"
        Me.GridColumnCategory.Name = "GridColumnCategory"
        Me.GridColumnCategory.Visible = True
        Me.GridColumnCategory.VisibleIndex = 9
        Me.GridColumnCategory.Width = 115
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BCancel)
        Me.PanelControl1.Controls.Add(Me.BChoose)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(22, 238)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(931, 37)
        Me.PanelControl1.TabIndex = 3
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.Enabled = False
        Me.BCancel.Location = New System.Drawing.Point(779, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(75, 33)
        Me.BCancel.TabIndex = 2
        Me.BCancel.Text = "Cancel"
        '
        'BChoose
        '
        Me.BChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BChoose.Enabled = False
        Me.BChoose.Location = New System.Drawing.Point(854, 2)
        Me.BChoose.Name = "BChoose"
        Me.BChoose.Size = New System.Drawing.Size(75, 33)
        Me.BChoose.TabIndex = 1
        Me.BChoose.Text = "Choose"
        '
        'FormPopUpPD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 482)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpPD"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Production Demand"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupControlProdNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlProdNumber.ResumeLayout(False)
        CType(Me.GCProdDemand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProdDemand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlProdNumber As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProdDemand As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProdDemand As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnProdDemand As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProdDemandNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCodeFull As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStyleOrigin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStyleCountry As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAging As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReturn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEstimateCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProposePrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMarkUp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQuantitiy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotalCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotalAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BChoose As DevExpress.XtraEditors.SimpleButton
End Class
