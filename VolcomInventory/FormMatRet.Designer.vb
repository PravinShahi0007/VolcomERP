<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMatRet
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
        Me.XTCReturnMat = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPurchase = New DevExpress.XtraTab.XtraTabPage()
        Me.XTCReturnPruchase = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPRetOut = New DevExpress.XtraTab.XtraTabPage()
        Me.GCRetOut = New DevExpress.XtraGrid.GridControl()
        Me.GVRetOut = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdSampleRetOut = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRetOutNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColShipFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColShipTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRecDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPSONumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IDReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPRetIn = New DevExpress.XtraTab.XtraTabPage()
        Me.GCRetIn = New DevExpress.XtraGrid.GridControl()
        Me.GVRetIn = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPProduction = New DevExpress.XtraTab.XtraTabPage()
        Me.XTCReturnProd = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPRetInProd = New DevExpress.XtraTab.XtraTabPage()
        Me.GCRetInProd = New DevExpress.XtraGrid.GridControl()
        Me.GVRetInProd = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCReturnMat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCReturnMat.SuspendLayout()
        Me.XTPPurchase.SuspendLayout()
        CType(Me.XTCReturnPruchase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCReturnPruchase.SuspendLayout()
        Me.XTPRetOut.SuspendLayout()
        CType(Me.GCRetOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRetOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPRetIn.SuspendLayout()
        CType(Me.GCRetIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRetIn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPProduction.SuspendLayout()
        CType(Me.XTCReturnProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCReturnProd.SuspendLayout()
        Me.XTPRetInProd.SuspendLayout()
        CType(Me.GCRetInProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRetInProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCReturnMat
        '
        Me.XTCReturnMat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCReturnMat.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right
        Me.XTCReturnMat.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal
        Me.XTCReturnMat.Location = New System.Drawing.Point(0, 0)
        Me.XTCReturnMat.Name = "XTCReturnMat"
        Me.XTCReturnMat.SelectedTabPage = Me.XTPPurchase
        Me.XTCReturnMat.Size = New System.Drawing.Size(837, 360)
        Me.XTCReturnMat.TabIndex = 5
        Me.XTCReturnMat.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPurchase, Me.XTPProduction})
        '
        'XTPPurchase
        '
        Me.XTPPurchase.Controls.Add(Me.XTCReturnPruchase)
        Me.XTPPurchase.Name = "XTPPurchase"
        Me.XTPPurchase.Size = New System.Drawing.Size(766, 354)
        Me.XTPPurchase.Text = "Purchase "
        '
        'XTCReturnPruchase
        '
        Me.XTCReturnPruchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCReturnPruchase.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCReturnPruchase.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal
        Me.XTCReturnPruchase.Location = New System.Drawing.Point(0, 0)
        Me.XTCReturnPruchase.LookAndFeel.SkinName = "Xmas 2008 Blue"
        Me.XTCReturnPruchase.LookAndFeel.UseDefaultLookAndFeel = False
        Me.XTCReturnPruchase.Name = "XTCReturnPruchase"
        Me.XTCReturnPruchase.SelectedTabPage = Me.XTPRetOut
        Me.XTCReturnPruchase.Size = New System.Drawing.Size(766, 354)
        Me.XTCReturnPruchase.TabIndex = 3
        Me.XTCReturnPruchase.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPRetOut, Me.XTPRetIn})
        '
        'XTPRetOut
        '
        Me.XTPRetOut.Controls.Add(Me.GCRetOut)
        Me.XTPRetOut.Name = "XTPRetOut"
        Me.XTPRetOut.Size = New System.Drawing.Size(761, 329)
        Me.XTPRetOut.Text = "Return Out"
        '
        'GCRetOut
        '
        Me.GCRetOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRetOut.Location = New System.Drawing.Point(0, 0)
        Me.GCRetOut.MainView = Me.GVRetOut
        Me.GCRetOut.Name = "GCRetOut"
        Me.GCRetOut.Size = New System.Drawing.Size(761, 329)
        Me.GCRetOut.TabIndex = 3
        Me.GCRetOut.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRetOut})
        '
        'GVRetOut
        '
        Me.GVRetOut.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdSampleRetOut, Me.ColSeason, Me.ColRetOutNumber, Me.ColShipFrom, Me.ColShipTo, Me.ColRecDate, Me.ColDueDate, Me.ColPSONumber, Me.Status, Me.IDReportStatus})
        Me.GVRetOut.GridControl = Me.GCRetOut
        Me.GVRetOut.GroupCount = 1
        Me.GVRetOut.Name = "GVRetOut"
        Me.GVRetOut.OptionsBehavior.Editable = False
        Me.GVRetOut.OptionsView.ShowGroupPanel = False
        Me.GVRetOut.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColSeason, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColIdSampleRetOut
        '
        Me.ColIdSampleRetOut.Caption = "ID Sample Ret Out"
        Me.ColIdSampleRetOut.FieldName = "id_mat_purc_ret_out"
        Me.ColIdSampleRetOut.Name = "ColIdSampleRetOut"
        '
        'ColSeason
        '
        Me.ColSeason.Caption = "Season"
        Me.ColSeason.FieldName = "season"
        Me.ColSeason.Name = "ColSeason"
        '
        'ColRetOutNumber
        '
        Me.ColRetOutNumber.Caption = "Number"
        Me.ColRetOutNumber.FieldName = "mat_purc_ret_out_number"
        Me.ColRetOutNumber.Name = "ColRetOutNumber"
        Me.ColRetOutNumber.Visible = True
        Me.ColRetOutNumber.VisibleIndex = 0
        Me.ColRetOutNumber.Width = 73
        '
        'ColShipFrom
        '
        Me.ColShipFrom.Caption = "From"
        Me.ColShipFrom.FieldName = "comp_from"
        Me.ColShipFrom.Name = "ColShipFrom"
        Me.ColShipFrom.Visible = True
        Me.ColShipFrom.VisibleIndex = 3
        Me.ColShipFrom.Width = 142
        '
        'ColShipTo
        '
        Me.ColShipTo.Caption = "To"
        Me.ColShipTo.FieldName = "comp_to"
        Me.ColShipTo.Name = "ColShipTo"
        Me.ColShipTo.Visible = True
        Me.ColShipTo.VisibleIndex = 4
        Me.ColShipTo.Width = 142
        '
        'ColRecDate
        '
        Me.ColRecDate.Caption = "Return Out Date"
        Me.ColRecDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColRecDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColRecDate.FieldName = "mat_purc_ret_out_date"
        Me.ColRecDate.Name = "ColRecDate"
        Me.ColRecDate.Visible = True
        Me.ColRecDate.VisibleIndex = 5
        Me.ColRecDate.Width = 131
        '
        'ColDueDate
        '
        Me.ColDueDate.Caption = "Due Date"
        Me.ColDueDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColDueDate.FieldName = "mat_purc_ret_out_due_date"
        Me.ColDueDate.Name = "ColDueDate"
        Me.ColDueDate.Visible = True
        Me.ColDueDate.VisibleIndex = 2
        Me.ColDueDate.Width = 144
        '
        'ColPSONumber
        '
        Me.ColPSONumber.Caption = "PO Number"
        Me.ColPSONumber.FieldName = "mat_purc_number"
        Me.ColPSONumber.Name = "ColPSONumber"
        Me.ColPSONumber.Visible = True
        Me.ColPSONumber.VisibleIndex = 1
        '
        'Status
        '
        Me.Status.Caption = "Status"
        Me.Status.FieldName = "report_status"
        Me.Status.Name = "Status"
        Me.Status.Visible = True
        Me.Status.VisibleIndex = 6
        '
        'IDReportStatus
        '
        Me.IDReportStatus.Caption = "GridColumn7"
        Me.IDReportStatus.FieldName = "id_report_status"
        Me.IDReportStatus.Name = "IDReportStatus"
        '
        'XTPRetIn
        '
        Me.XTPRetIn.Controls.Add(Me.GCRetIn)
        Me.XTPRetIn.Name = "XTPRetIn"
        Me.XTPRetIn.Size = New System.Drawing.Size(761, 329)
        Me.XTPRetIn.Text = "Return In"
        '
        'GCRetIn
        '
        Me.GCRetIn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRetIn.Location = New System.Drawing.Point(0, 0)
        Me.GCRetIn.MainView = Me.GVRetIn
        Me.GCRetIn.Name = "GCRetIn"
        Me.GCRetIn.Size = New System.Drawing.Size(761, 329)
        Me.GCRetIn.TabIndex = 4
        Me.GCRetIn.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRetIn})
        '
        'GVRetIn
        '
        Me.GVRetIn.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn8, Me.GridColumn7, Me.GridColumn9})
        Me.GVRetIn.GridControl = Me.GCRetIn
        Me.GVRetIn.GroupCount = 1
        Me.GVRetIn.Name = "GVRetIn"
        Me.GVRetIn.OptionsBehavior.Editable = False
        Me.GVRetIn.OptionsView.ShowGroupPanel = False
        Me.GVRetIn.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn2, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID Sample Ret Out"
        Me.GridColumn1.FieldName = "id_mat_purc_ret_in"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Season"
        Me.GridColumn2.FieldName = "season"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Number"
        Me.GridColumn3.FieldName = "mat_purc_ret_in_number"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        Me.GridColumn3.Width = 73
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "From"
        Me.GridColumn4.FieldName = "comp_from"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 142
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "To"
        Me.GridColumn5.FieldName = "comp_to"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 142
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Return Out Date"
        Me.GridColumn6.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn6.FieldName = "mat_purc_ret_in_date"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 131
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "PO Number"
        Me.GridColumn8.FieldName = "mat_purc_number"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Status"
        Me.GridColumn7.FieldName = "report_status"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 5
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "ID Report Status"
        Me.GridColumn9.FieldName = "id_report_status"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'XTPProduction
        '
        Me.XTPProduction.Controls.Add(Me.XTCReturnProd)
        Me.XTPProduction.Name = "XTPProduction"
        Me.XTPProduction.Size = New System.Drawing.Size(766, 354)
        Me.XTPProduction.Text = "Production"
        '
        'XTCReturnProd
        '
        Me.XTCReturnProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCReturnProd.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCReturnProd.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal
        Me.XTCReturnProd.Location = New System.Drawing.Point(0, 0)
        Me.XTCReturnProd.LookAndFeel.SkinName = "Xmas 2008 Blue"
        Me.XTCReturnProd.LookAndFeel.UseDefaultLookAndFeel = False
        Me.XTCReturnProd.Name = "XTCReturnProd"
        Me.XTCReturnProd.SelectedTabPage = Me.XTPRetInProd
        Me.XTCReturnProd.Size = New System.Drawing.Size(766, 354)
        Me.XTCReturnProd.TabIndex = 4
        Me.XTCReturnProd.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPRetInProd})
        '
        'XTPRetInProd
        '
        Me.XTPRetInProd.Controls.Add(Me.GCRetInProd)
        Me.XTPRetInProd.Name = "XTPRetInProd"
        Me.XTPRetInProd.Size = New System.Drawing.Size(761, 329)
        Me.XTPRetInProd.Text = "Return In"
        '
        'GCRetInProd
        '
        Me.GCRetInProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRetInProd.Location = New System.Drawing.Point(0, 0)
        Me.GCRetInProd.MainView = Me.GVRetInProd
        Me.GCRetInProd.Name = "GCRetInProd"
        Me.GCRetInProd.Size = New System.Drawing.Size(761, 329)
        Me.GCRetInProd.TabIndex = 4
        Me.GCRetInProd.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRetInProd})
        '
        'GVRetInProd
        '
        Me.GVRetInProd.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn20, Me.GridColumn22, Me.GridColumn23, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn10, Me.GridColumnDesign})
        Me.GVRetInProd.GridControl = Me.GCRetInProd
        Me.GVRetInProd.Name = "GVRetInProd"
        Me.GVRetInProd.OptionsBehavior.Editable = False
        Me.GVRetInProd.OptionsView.ShowGroupPanel = False
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "ID Sample Ret Out"
        Me.GridColumn20.FieldName = "id_mat_prod_ret_in"
        Me.GridColumn20.Name = "GridColumn20"
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Number"
        Me.GridColumn22.FieldName = "mat_prod_ret_in_number"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 0
        Me.GridColumn22.Width = 68
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "From"
        Me.GridColumn23.FieldName = "comp_from"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 3
        Me.GridColumn23.Width = 126
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Return In Date"
        Me.GridColumn25.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn25.FieldName = "mat_prod_ret_in_date"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 4
        Me.GridColumn25.Width = 104
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "PO Number"
        Me.GridColumn26.FieldName = "prod_order_number"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 1
        Me.GridColumn26.Width = 77
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "Status"
        Me.GridColumn27.FieldName = "report_status"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 5
        Me.GridColumn27.Width = 71
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "ID Report Status"
        Me.GridColumn28.FieldName = "id_report_status"
        Me.GridColumn28.Name = "GridColumn28"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "WO Number"
        Me.GridColumn10.FieldName = "prod_order_wo_number"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Width = 78
        '
        'GridColumnDesign
        '
        Me.GridColumnDesign.Caption = "Design"
        Me.GridColumnDesign.FieldName = "design_name"
        Me.GridColumnDesign.Name = "GridColumnDesign"
        Me.GridColumnDesign.Visible = True
        Me.GridColumnDesign.VisibleIndex = 2
        Me.GridColumnDesign.Width = 79
        '
        'FormMatRet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 360)
        Me.Controls.Add(Me.XTCReturnMat)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMatRet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Return Raw Material"
        CType(Me.XTCReturnMat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCReturnMat.ResumeLayout(False)
        Me.XTPPurchase.ResumeLayout(False)
        CType(Me.XTCReturnPruchase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCReturnPruchase.ResumeLayout(False)
        Me.XTPRetOut.ResumeLayout(False)
        CType(Me.GCRetOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRetOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPRetIn.ResumeLayout(False)
        CType(Me.GCRetIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRetIn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPProduction.ResumeLayout(False)
        CType(Me.XTCReturnProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCReturnProd.ResumeLayout(False)
        Me.XTPRetInProd.ResumeLayout(False)
        CType(Me.GCRetInProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRetInProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCReturnMat As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPurchase As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTCReturnPruchase As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPRetOut As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCRetOut As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRetOut As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdSampleRetOut As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRetOutNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPSONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IDReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPRetIn As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCRetIn As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRetIn As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPProduction As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTCReturnProd As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPRetInProd As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCRetInProd As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRetInProd As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesign As DevExpress.XtraGrid.Columns.GridColumn
End Class
