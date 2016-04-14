<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProdQCAdj
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
        Me.XTCAdj = New DevExpress.XtraTab.XtraTabControl
        Me.XTPAdjIn = New DevExpress.XtraTab.XtraTabPage
        Me.GCAdjIn = New DevExpress.XtraGrid.GridControl
        Me.GVAdjIn = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIdAdjInQC = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdProdOrder = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPONumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnNumberAdjInQCNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnAdjInQCDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdProdOrderStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnTotal = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDesignName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDesignCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.XTPAdjOut = New DevExpress.XtraTab.XtraTabPage
        Me.GCAdjOut = New DevExpress.XtraGrid.GridControl
        Me.GVAdjOut = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GCAdjSampleOut = New DevExpress.XtraGrid.GridControl
        Me.GVAdjSampleOut = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.XTCAdj, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCAdj.SuspendLayout()
        Me.XTPAdjIn.SuspendLayout()
        CType(Me.GCAdjIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAdjIn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPAdjOut.SuspendLayout()
        CType(Me.GCAdjOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAdjOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCAdjSampleOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAdjSampleOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCAdj
        '
        Me.XTCAdj.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCAdj.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right
        Me.XTCAdj.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal
        Me.XTCAdj.Location = New System.Drawing.Point(0, 0)
        Me.XTCAdj.Name = "XTCAdj"
        Me.XTCAdj.SelectedTabPage = Me.XTPAdjIn
        Me.XTCAdj.Size = New System.Drawing.Size(814, 441)
        Me.XTCAdj.TabIndex = 7
        Me.XTCAdj.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPAdjIn, Me.XTPAdjOut})
        '
        'XTPAdjIn
        '
        Me.XTPAdjIn.Controls.Add(Me.GCAdjIn)
        Me.XTPAdjIn.Name = "XTPAdjIn"
        Me.XTPAdjIn.Size = New System.Drawing.Size(720, 435)
        Me.XTPAdjIn.Text = "Adjustment In"
        '
        'GCAdjIn
        '
        Me.GCAdjIn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAdjIn.Location = New System.Drawing.Point(0, 0)
        Me.GCAdjIn.MainView = Me.GVAdjIn
        Me.GCAdjIn.Name = "GCAdjIn"
        Me.GCAdjIn.Size = New System.Drawing.Size(720, 435)
        Me.GCAdjIn.TabIndex = 0
        Me.GCAdjIn.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAdjIn})
        '
        'GVAdjIn
        '
        Me.GVAdjIn.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdAdjInQC, Me.GridColumnIdProdOrder, Me.GridColumnPONumber, Me.GridColumnNumberAdjInQCNumber, Me.GridColumnAdjInQCDate, Me.GridColumnReportStatus, Me.GridColumnIdProdOrderStatus, Me.GridColumnTotal, Me.GridColumnDesignName, Me.GridColumnDesignCode})
        Me.GVAdjIn.GridControl = Me.GCAdjIn
        Me.GVAdjIn.Name = "GVAdjIn"
        Me.GVAdjIn.OptionsBehavior.Editable = False
        Me.GVAdjIn.OptionsFind.AlwaysVisible = True
        Me.GVAdjIn.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdAdjInQC
        '
        Me.GridColumnIdAdjInQC.Caption = "Id Adj In Sample"
        Me.GridColumnIdAdjInQC.FieldName = "id_prod_order_qc_adj_in"
        Me.GridColumnIdAdjInQC.Name = "GridColumnIdAdjInQC"
        '
        'GridColumnIdProdOrder
        '
        Me.GridColumnIdProdOrder.Caption = "ID Prod Order"
        Me.GridColumnIdProdOrder.FieldName = "id_prod_order"
        Me.GridColumnIdProdOrder.Name = "GridColumnIdProdOrder"
        '
        'GridColumnPONumber
        '
        Me.GridColumnPONumber.Caption = "PO Number"
        Me.GridColumnPONumber.FieldName = "prod_order_number"
        Me.GridColumnPONumber.Name = "GridColumnPONumber"
        Me.GridColumnPONumber.Visible = True
        Me.GridColumnPONumber.VisibleIndex = 3
        Me.GridColumnPONumber.Width = 117
        '
        'GridColumnNumberAdjInQCNumber
        '
        Me.GridColumnNumberAdjInQCNumber.Caption = "Number"
        Me.GridColumnNumberAdjInQCNumber.FieldName = "prod_order_qc_adj_in_number"
        Me.GridColumnNumberAdjInQCNumber.Name = "GridColumnNumberAdjInQCNumber"
        Me.GridColumnNumberAdjInQCNumber.Visible = True
        Me.GridColumnNumberAdjInQCNumber.VisibleIndex = 0
        Me.GridColumnNumberAdjInQCNumber.Width = 152
        '
        'GridColumnAdjInQCDate
        '
        Me.GridColumnAdjInQCDate.Caption = "Created Date"
        Me.GridColumnAdjInQCDate.DisplayFormat.FormatString = "dd  MMM yyyy"
        Me.GridColumnAdjInQCDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnAdjInQCDate.FieldName = "prod_order_qc_adj_in_date"
        Me.GridColumnAdjInQCDate.Name = "GridColumnAdjInQCDate"
        Me.GridColumnAdjInQCDate.Visible = True
        Me.GridColumnAdjInQCDate.VisibleIndex = 5
        Me.GridColumnAdjInQCDate.Width = 193
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        Me.GridColumnReportStatus.Visible = True
        Me.GridColumnReportStatus.VisibleIndex = 6
        Me.GridColumnReportStatus.Width = 207
        '
        'GridColumnIdProdOrderStatus
        '
        Me.GridColumnIdProdOrderStatus.Caption = "Id Report Status"
        Me.GridColumnIdProdOrderStatus.Name = "GridColumnIdProdOrderStatus"
        '
        'GridColumnTotal
        '
        Me.GridColumnTotal.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotal.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotal.Caption = "Total"
        Me.GridColumnTotal.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotal.FieldName = "prod_order_qc_adj_in_total"
        Me.GridColumnTotal.Name = "GridColumnTotal"
        Me.GridColumnTotal.Visible = True
        Me.GridColumnTotal.VisibleIndex = 4
        Me.GridColumnTotal.Width = 193
        '
        'GridColumnDesignName
        '
        Me.GridColumnDesignName.Caption = "Design"
        Me.GridColumnDesignName.FieldName = "design_name"
        Me.GridColumnDesignName.Name = "GridColumnDesignName"
        Me.GridColumnDesignName.Visible = True
        Me.GridColumnDesignName.VisibleIndex = 2
        Me.GridColumnDesignName.Width = 185
        '
        'GridColumnDesignCode
        '
        Me.GridColumnDesignCode.Caption = "Design Code"
        Me.GridColumnDesignCode.FieldName = "design_code"
        Me.GridColumnDesignCode.Name = "GridColumnDesignCode"
        Me.GridColumnDesignCode.Visible = True
        Me.GridColumnDesignCode.VisibleIndex = 1
        Me.GridColumnDesignCode.Width = 133
        '
        'XTPAdjOut
        '
        Me.XTPAdjOut.Controls.Add(Me.GCAdjOut)
        Me.XTPAdjOut.Controls.Add(Me.GCAdjSampleOut)
        Me.XTPAdjOut.Name = "XTPAdjOut"
        Me.XTPAdjOut.Size = New System.Drawing.Size(720, 435)
        Me.XTPAdjOut.Text = "Adjustment Out"
        '
        'GCAdjOut
        '
        Me.GCAdjOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAdjOut.Location = New System.Drawing.Point(0, 0)
        Me.GCAdjOut.MainView = Me.GVAdjOut
        Me.GCAdjOut.Name = "GCAdjOut"
        Me.GCAdjOut.Size = New System.Drawing.Size(720, 435)
        Me.GCAdjOut.TabIndex = 2
        Me.GCAdjOut.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAdjOut})
        '
        'GVAdjOut
        '
        Me.GVAdjOut.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16})
        Me.GVAdjOut.GridControl = Me.GCAdjOut
        Me.GVAdjOut.Name = "GVAdjOut"
        Me.GVAdjOut.OptionsBehavior.Editable = False
        Me.GVAdjOut.OptionsFind.AlwaysVisible = True
        Me.GVAdjOut.OptionsView.ShowGroupPanel = False
        '
        'GCAdjSampleOut
        '
        Me.GCAdjSampleOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAdjSampleOut.Location = New System.Drawing.Point(0, 0)
        Me.GCAdjSampleOut.MainView = Me.GVAdjSampleOut
        Me.GCAdjSampleOut.Name = "GCAdjSampleOut"
        Me.GCAdjSampleOut.Size = New System.Drawing.Size(720, 435)
        Me.GCAdjSampleOut.TabIndex = 1
        Me.GCAdjSampleOut.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAdjSampleOut})
        '
        'GVAdjSampleOut
        '
        Me.GVAdjSampleOut.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.GVAdjSampleOut.GridControl = Me.GCAdjSampleOut
        Me.GVAdjSampleOut.Name = "GVAdjSampleOut"
        Me.GVAdjSampleOut.OptionsBehavior.Editable = False
        Me.GVAdjSampleOut.OptionsFind.AlwaysVisible = True
        Me.GVAdjSampleOut.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Sample Return"
        Me.GridColumn1.FieldName = "id_sample_return"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Number"
        Me.GridColumn2.FieldName = "sample_return_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "From"
        Me.GridColumn3.FieldName = "comp_from"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "To"
        Me.GridColumn4.FieldName = "comp_to"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Created Date"
        Me.GridColumn5.FieldName = "sample_return_date"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Status"
        Me.GridColumn6.FieldName = "report_status"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Id Adj In Sample"
        Me.GridColumn7.FieldName = "id_prod_order_qc_adj_out"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "ID Prod Order"
        Me.GridColumn8.FieldName = "id_prod_order"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "PO Number"
        Me.GridColumn9.FieldName = "prod_order_number"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 3
        Me.GridColumn9.Width = 117
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Number"
        Me.GridColumn10.FieldName = "prod_order_qc_adj_out_number"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        Me.GridColumn10.Width = 152
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Created Date"
        Me.GridColumn11.DisplayFormat.FormatString = "dd  MMM yyyy"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn11.FieldName = "prod_order_qc_adj_out_date"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 5
        Me.GridColumn11.Width = 193
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Status"
        Me.GridColumn12.FieldName = "report_status"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 6
        Me.GridColumn12.Width = 207
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Id Report Status"
        Me.GridColumn13.FieldName = "id_report_status"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn14.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn14.Caption = "Total"
        Me.GridColumn14.DisplayFormat.FormatString = "N2"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn14.FieldName = "prod_order_qc_adj_out_total"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 4
        Me.GridColumn14.Width = 193
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Design"
        Me.GridColumn15.FieldName = "design_name"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 2
        Me.GridColumn15.Width = 185
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Design Code"
        Me.GridColumn16.FieldName = "design_code"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 1
        Me.GridColumn16.Width = 133
        '
        'FormProdQCAdj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 441)
        Me.Controls.Add(Me.XTCAdj)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProdQCAdj"
        Me.Text = "QC Adjustment Qty"
        CType(Me.XTCAdj, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCAdj.ResumeLayout(False)
        Me.XTPAdjIn.ResumeLayout(False)
        CType(Me.GCAdjIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAdjIn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPAdjOut.ResumeLayout(False)
        CType(Me.GCAdjOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAdjOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCAdjSampleOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAdjSampleOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCAdj As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPAdjIn As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCAdjIn As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAdjIn As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdAdjInQC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumberAdjInQCNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAdjInQCDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdProdOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPAdjOut As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCAdjOut As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAdjOut As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCAdjSampleOut As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAdjSampleOut As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdProdOrderStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesignName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesignCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
End Class
