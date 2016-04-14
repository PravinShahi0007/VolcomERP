<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSampleDelRecInfo
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.LabelSubTitle = New DevExpress.XtraEditors.LabelControl
        Me.LabelTitle = New DevExpress.XtraEditors.LabelControl
        Me.GCSampleDelList = New DevExpress.XtraGrid.GridControl
        Me.GVSampleDelList = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnYearSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnRecQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnRemainingQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyWH = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnRetail = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnRetailAmount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCostAmount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSample = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdPlSalesOrderDel = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Me.GridColumnReceivingQty = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCSampleDelList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSampleDelList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Blue
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.Controls.Add(Me.LabelSubTitle)
        Me.PanelControl1.Controls.Add(Me.LabelTitle)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(789, 59)
        Me.PanelControl1.TabIndex = 34
        '
        'LabelSubTitle
        '
        Me.LabelSubTitle.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSubTitle.Location = New System.Drawing.Point(12, 32)
        Me.LabelSubTitle.Name = "LabelSubTitle"
        Me.LabelSubTitle.Size = New System.Drawing.Size(64, 15)
        Me.LabelSubTitle.TabIndex = 30
        Me.LabelSubTitle.Text = "SRS No : xxx"
        '
        'LabelTitle
        '
        Me.LabelTitle.Appearance.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.Location = New System.Drawing.Point(12, 9)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(115, 23)
        Me.LabelTitle.TabIndex = 29
        Me.LabelTitle.Text = "PL Sample Info"
        '
        'GCSampleDelList
        '
        Me.GCSampleDelList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSampleDelList.Location = New System.Drawing.Point(0, 59)
        Me.GCSampleDelList.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCSampleDelList.MainView = Me.GVSampleDelList
        Me.GCSampleDelList.Name = "GCSampleDelList"
        Me.GCSampleDelList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCSampleDelList.Size = New System.Drawing.Size(789, 401)
        Me.GCSampleDelList.TabIndex = 4
        Me.GCSampleDelList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSampleDelList})
        '
        'GVSampleDelList
        '
        Me.GVSampleDelList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnCode, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnColor, Me.GridColumnSeason, Me.GridColumnYearSeason, Me.GridColumnQty, Me.GridColumnRecQty, Me.GridColumnRemainingQty, Me.GridColumnQtyWH, Me.GridColumnRemark, Me.GridColumnRetail, Me.GridColumnRetailAmount, Me.GridColumnCostAmount, Me.GridColumnIdSample, Me.GridColumnIdPlSalesOrderDel, Me.GridColumnReceivingQty})
        Me.GVSampleDelList.GridControl = Me.GCSampleDelList
        Me.GVSampleDelList.Name = "GVSampleDelList"
        Me.GVSampleDelList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVSampleDelList.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVSampleDelList.OptionsBehavior.ReadOnly = True
        Me.GVSampleDelList.OptionsCustomization.AllowGroup = False
        Me.GVSampleDelList.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVSampleDelList.OptionsView.ShowFooter = True
        Me.GVSampleDelList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 43
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.AllowEdit = False
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        Me.GridColumnCode.Width = 74
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Description"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.FieldNameSortGroup = "id_design"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 2
        Me.GridColumnName.Width = 142
        '
        'GridColumnSize
        '
        Me.GridColumnSize.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.OptionsColumn.AllowEdit = False
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 4
        Me.GridColumnSize.Width = 57
        '
        'GridColumnColor
        '
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.OptionsColumn.AllowEdit = False
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 3
        Me.GridColumnColor.Width = 56
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        Me.GridColumnSeason.OptionsColumn.AllowEdit = False
        Me.GridColumnSeason.Visible = True
        Me.GridColumnSeason.VisibleIndex = 5
        '
        'GridColumnYearSeason
        '
        Me.GridColumnYearSeason.Caption = "Year"
        Me.GridColumnYearSeason.FieldName = "season_year"
        Me.GridColumnYearSeason.Name = "GridColumnYearSeason"
        Me.GridColumnYearSeason.OptionsColumn.AllowEdit = False
        Me.GridColumnYearSeason.Visible = True
        Me.GridColumnYearSeason.VisibleIndex = 6
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Delivered Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "F2"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "sample_del_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowEdit = False
        Me.GridColumnQty.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_del_det_qty", "{0:f2}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 7
        Me.GridColumnQty.Width = 96
        '
        'GridColumnRecQty
        '
        Me.GridColumnRecQty.Caption = "Received Qty"
        Me.GridColumnRecQty.DisplayFormat.FormatString = "{0:f2}"
        Me.GridColumnRecQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRecQty.FieldName = "sample_del_det_qty_received"
        Me.GridColumnRecQty.Name = "GridColumnRecQty"
        Me.GridColumnRecQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_del_det_qty_received", "{0:f2}")})
        Me.GridColumnRecQty.Visible = True
        Me.GridColumnRecQty.VisibleIndex = 8
        '
        'GridColumnRemainingQty
        '
        Me.GridColumnRemainingQty.Caption = "Remaining Qty"
        Me.GridColumnRemainingQty.DisplayFormat.FormatString = "{0:f2}"
        Me.GridColumnRemainingQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRemainingQty.FieldName = "sample_del_det_qty_remaining"
        Me.GridColumnRemainingQty.Name = "GridColumnRemainingQty"
        Me.GridColumnRemainingQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_del_det_qty_remaining", "{0:f2}")})
        Me.GridColumnRemainingQty.Visible = True
        Me.GridColumnRemainingQty.VisibleIndex = 9
        '
        'GridColumnQtyWH
        '
        Me.GridColumnQtyWH.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyWH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyWH.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyWH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyWH.Caption = "Qty From WH"
        Me.GridColumnQtyWH.DisplayFormat.FormatString = "F2"
        Me.GridColumnQtyWH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyWH.FieldName = "sample_del_det_qty_wh"
        Me.GridColumnQtyWH.Name = "GridColumnQtyWH"
        Me.GridColumnQtyWH.OptionsColumn.AllowEdit = False
        Me.GridColumnQtyWH.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_del_det_qty_wh", "{0:f2}")})
        Me.GridColumnQtyWH.Width = 91
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.FieldName = "sample_del_det_note"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.Visible = True
        Me.GridColumnRemark.VisibleIndex = 10
        Me.GridColumnRemark.Width = 93
        '
        'GridColumnRetail
        '
        Me.GridColumnRetail.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnRetail.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnRetail.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnRetail.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnRetail.Caption = "Retail"
        Me.GridColumnRetail.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnRetail.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRetail.FieldName = "sample_ret_price"
        Me.GridColumnRetail.Name = "GridColumnRetail"
        Me.GridColumnRetail.OptionsColumn.AllowEdit = False
        '
        'GridColumnRetailAmount
        '
        Me.GridColumnRetailAmount.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnRetailAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnRetailAmount.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnRetailAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnRetailAmount.Caption = "Retail Amount"
        Me.GridColumnRetailAmount.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnRetailAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRetailAmount.FieldName = "sample_del_det_amount_ret"
        Me.GridColumnRetailAmount.Name = "GridColumnRetailAmount"
        Me.GridColumnRetailAmount.OptionsColumn.AllowEdit = False
        Me.GridColumnRetailAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_del_det_amount_ret", "{0:n2}")})
        '
        'GridColumnCostAmount
        '
        Me.GridColumnCostAmount.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnCostAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnCostAmount.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnCostAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnCostAmount.Caption = "Cost Amount"
        Me.GridColumnCostAmount.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnCostAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCostAmount.FieldName = "sample_del_det_amount"
        Me.GridColumnCostAmount.Name = "GridColumnCostAmount"
        Me.GridColumnCostAmount.OptionsColumn.AllowEdit = False
        Me.GridColumnCostAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_del_det_amount", "{0:n2}")})
        '
        'GridColumnIdSample
        '
        Me.GridColumnIdSample.Caption = "id Sample"
        Me.GridColumnIdSample.FieldName = "id_sample"
        Me.GridColumnIdSample.Name = "GridColumnIdSample"
        Me.GridColumnIdSample.OptionsColumn.AllowEdit = False
        Me.GridColumnIdSample.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdPlSalesOrderDel
        '
        Me.GridColumnIdPlSalesOrderDel.Caption = "Id Sample Del Det"
        Me.GridColumnIdPlSalesOrderDel.FieldName = "id_sample_del_det"
        Me.GridColumnIdPlSalesOrderDel.Name = "GridColumnIdPlSalesOrderDel"
        Me.GridColumnIdPlSalesOrderDel.OptionsColumn.AllowEdit = False
        Me.GridColumnIdPlSalesOrderDel.OptionsColumn.ShowInCustomizationForm = False
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridColumnReceivingQty
        '
        Me.GridColumnReceivingQty.Caption = "Receiving Qty"
        Me.GridColumnReceivingQty.DisplayFormat.FormatString = "{0:f2}"
        Me.GridColumnReceivingQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnReceivingQty.FieldName = "sample_del_det_qty_receiving"
        Me.GridColumnReceivingQty.Name = "GridColumnReceivingQty"
        Me.GridColumnReceivingQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_del_det_qty_receiving", "{0:n2}")})
        '
        'FormSampleDelRecInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 460)
        Me.Controls.Add(Me.GCSampleDelList)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormSampleDelRecInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Packing List Info"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.GCSampleDelList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSampleDelList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelSubTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCSampleDelList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSampleDelList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnYearSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRecQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemainingQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyWH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRetail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRetailAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCostAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPlSalesOrderDel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnReceivingQty As DevExpress.XtraGrid.Columns.GridColumn
End Class
