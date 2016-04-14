<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportSampleReq
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer
        Me.GCRetDetail = New DevExpress.XtraGrid.GridControl
        Me.GVRetDetail = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdReq = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSamplePurcDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyAll = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand
        Me.XrPanel1 = New DevExpress.XtraReports.UI.XRPanel
        Me.LDivision = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel
        Me.LabelFromDepartement = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel
        Me.LabelFromUser = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel
        Me.LabelDurationDate = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel
        Me.LabelFrom = New DevExpress.XtraReports.UI.XRLabel
        Me.LTitle = New DevExpress.XtraReports.UI.XRLabel
        Me.LabelDate = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel
        Me.LabelNo = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell
        Me.XrPanel2 = New DevExpress.XtraReports.UI.XRPanel
        Me.LabelNote = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel
        CType(Me.GCRetDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRetDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 203.8489!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(649.9999!, 164.2655!)
        Me.WinControlContainer1.WinControl = Me.GCRetDetail
        '
        'GCRetDetail
        '
        Me.GCRetDetail.Location = New System.Drawing.Point(22, 44)
        Me.GCRetDetail.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GCRetDetail.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCRetDetail.MainView = Me.GVRetDetail
        Me.GCRetDetail.Name = "GCRetDetail"
        Me.GCRetDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCRetDetail.Size = New System.Drawing.Size(624, 158)
        Me.GCRetDetail.TabIndex = 1
        Me.GCRetDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRetDetail})
        '
        'GVRetDetail
        '
        Me.GVRetDetail.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.EvenRow.BackColor2 = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.EvenRow.BorderColor = System.Drawing.Color.Black
        Me.GVRetDetail.AppearancePrint.EvenRow.Options.UseBackColor = True
        Me.GVRetDetail.AppearancePrint.EvenRow.Options.UseBorderColor = True
        Me.GVRetDetail.AppearancePrint.FilterPanel.BackColor = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.FilterPanel.BackColor2 = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.FilterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVRetDetail.AppearancePrint.FilterPanel.Options.UseBackColor = True
        Me.GVRetDetail.AppearancePrint.FilterPanel.Options.UseBorderColor = True
        Me.GVRetDetail.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.FooterPanel.BackColor2 = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVRetDetail.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVRetDetail.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVRetDetail.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.GroupFooter.BackColor2 = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVRetDetail.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVRetDetail.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVRetDetail.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.GroupRow.BackColor2 = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVRetDetail.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVRetDetail.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVRetDetail.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.HeaderPanel.BackColor2 = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVRetDetail.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVRetDetail.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVRetDetail.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVRetDetail.AppearancePrint.Lines.BackColor2 = System.Drawing.Color.Black
        Me.GVRetDetail.AppearancePrint.Lines.BorderColor = System.Drawing.Color.Black
        Me.GVRetDetail.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVRetDetail.AppearancePrint.Lines.Options.UseBorderColor = True
        Me.GVRetDetail.AppearancePrint.OddRow.BackColor = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.OddRow.BackColor2 = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.OddRow.BorderColor = System.Drawing.Color.Black
        Me.GVRetDetail.AppearancePrint.OddRow.Options.UseBackColor = True
        Me.GVRetDetail.AppearancePrint.OddRow.Options.UseBorderColor = True
        Me.GVRetDetail.AppearancePrint.Preview.BackColor = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.Preview.BackColor2 = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.Preview.BorderColor = System.Drawing.Color.Black
        Me.GVRetDetail.AppearancePrint.Preview.Options.UseBackColor = True
        Me.GVRetDetail.AppearancePrint.Preview.Options.UseBorderColor = True
        Me.GVRetDetail.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.Row.BackColor2 = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVRetDetail.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVRetDetail.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVRetDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnCode, Me.GridColumnIdReq, Me.GridColumnIdSamplePurcDet, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnUOM, Me.GridColumnQtyAll, Me.GridColumnRemark, Me.GridColumnQty})
        Me.GVRetDetail.GridControl = Me.GCRetDetail
        Me.GVRetDetail.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_requisition_det_qty", Me.GridColumnQty, "")})
        Me.GVRetDetail.Name = "GVRetDetail"
        Me.GVRetDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVRetDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVRetDetail.OptionsPrint.UsePrintStyles = True
        Me.GVRetDetail.OptionsView.ShowFooter = True
        Me.GVRetDetail.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 40
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        Me.GridColumnCode.Width = 93
        '
        'GridColumnIdReq
        '
        Me.GridColumnIdReq.Caption = "ID Req"
        Me.GridColumnIdReq.FieldName = "id_sample_requisition_det"
        Me.GridColumnIdReq.Name = "GridColumnIdReq"
        Me.GridColumnIdReq.OptionsColumn.AllowEdit = False
        '
        'GridColumnIdSamplePurcDet
        '
        Me.GridColumnIdSamplePurcDet.Caption = "Id Sample "
        Me.GridColumnIdSamplePurcDet.FieldName = "id_sample"
        Me.GridColumnIdSamplePurcDet.Name = "GridColumnIdSamplePurcDet"
        Me.GridColumnIdSamplePurcDet.OptionsColumn.AllowEdit = False
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Description"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 2
        Me.GridColumnName.Width = 93
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.OptionsColumn.AllowEdit = False
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 3
        Me.GridColumnSize.Width = 46
        '
        'GridColumnUOM
        '
        Me.GridColumnUOM.Caption = "UOM"
        Me.GridColumnUOM.FieldName = "uom"
        Me.GridColumnUOM.Name = "GridColumnUOM"
        Me.GridColumnUOM.OptionsColumn.AllowEdit = False
        Me.GridColumnUOM.Visible = True
        Me.GridColumnUOM.VisibleIndex = 4
        Me.GridColumnUOM.Width = 41
        '
        'GridColumnQtyAll
        '
        Me.GridColumnQtyAll.Caption = "Qty Limit"
        Me.GridColumnQtyAll.FieldName = "qty_all_sample"
        Me.GridColumnQtyAll.Name = "GridColumnQtyAll"
        Me.GridColumnQtyAll.OptionsColumn.AllowEdit = False
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.FieldName = "sample_requisition_det_note"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.Visible = True
        Me.GridColumnRemark.VisibleIndex = 5
        Me.GridColumnRemark.Width = 211
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumnQty.FieldName = "sample_requisition_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 6
        Me.GridColumnQty.Width = 82
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RepositoryItemSpinEdit1.EditValueChangedDelay = 50
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPanel1, Me.LTitle, Me.LabelDate, Me.XrLabel6, Me.LabelNo, Me.XrLabel8, Me.XrLabel11, Me.XrLabel1})
        Me.TopMargin.HeightF = 123.7917!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPanel1
        '
        Me.XrPanel1.BorderColor = System.Drawing.Color.Black
        Me.XrPanel1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrPanel1.CanGrow = False
        Me.XrPanel1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LDivision, Me.XrLabel16, Me.XrLabel17, Me.LabelFromDepartement, Me.XrLabel10, Me.XrLabel7, Me.LabelFromUser, Me.XrLabel5, Me.XrLabel2, Me.LabelDurationDate, Me.XrLabel13, Me.XrLabel12, Me.XrLabel3, Me.XrLabel4, Me.LabelFrom})
        Me.XrPanel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 43.80298!)
        Me.XrPanel1.Name = "XrPanel1"
        Me.XrPanel1.SizeF = New System.Drawing.SizeF(649.9999!, 79.98869!)
        Me.XrPanel1.StylePriority.UseBorderColor = False
        Me.XrPanel1.StylePriority.UseBorders = False
        '
        'LDivision
        '
        Me.LDivision.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LDivision.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LDivision.LocationFloat = New DevExpress.Utils.PointFloat(509.3749!, 29.1667!)
        Me.LDivision.Name = "LDivision"
        Me.LDivision.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LDivision.SizeF = New System.Drawing.SizeF(130.625!, 13.58332!)
        Me.LDivision.StylePriority.UseBorders = False
        Me.LDivision.StylePriority.UseFont = False
        '
        'XrLabel16
        '
        Me.XrLabel16.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(497.9165!, 29.16667!)
        Me.XrLabel16.Name = "XrLabel16"
        Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel16.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel16.StylePriority.UseBorders = False
        Me.XrLabel16.Text = ":"
        '
        'XrLabel17
        '
        Me.XrLabel17.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel17.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(357.1524!, 29.16667!)
        Me.XrLabel17.Name = "XrLabel17"
        Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel17.SizeF = New System.Drawing.SizeF(140.7643!, 13.58334!)
        Me.XrLabel17.StylePriority.UseBorders = False
        Me.XrLabel17.StylePriority.UseFont = False
        Me.XrLabel17.Text = "Division"
        '
        'LabelFromDepartement
        '
        Me.LabelFromDepartement.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelFromDepartement.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFromDepartement.LocationFloat = New DevExpress.Utils.PointFloat(87.55633!, 15.5834!)
        Me.LabelFromDepartement.Name = "LabelFromDepartement"
        Me.LabelFromDepartement.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelFromDepartement.SizeF = New System.Drawing.SizeF(238.5416!, 13.58335!)
        Me.LabelFromDepartement.StylePriority.UseBorders = False
        Me.LabelFromDepartement.StylePriority.UseFont = False
        '
        'XrLabel10
        '
        Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(76.098!, 15.5834!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.Text = ":"
        '
        'XrLabel7
        '
        Me.XrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(2.000014!, 15.58336!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(74.098!, 13.58334!)
        Me.XrLabel7.StylePriority.UseBorders = False
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.Text = "Departement"
        '
        'LabelFromUser
        '
        Me.LabelFromUser.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelFromUser.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFromUser.LocationFloat = New DevExpress.Utils.PointFloat(87.55633!, 2.000046!)
        Me.LabelFromUser.Name = "LabelFromUser"
        Me.LabelFromUser.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelFromUser.SizeF = New System.Drawing.SizeF(238.5416!, 13.58335!)
        Me.LabelFromUser.StylePriority.UseBorders = False
        Me.LabelFromUser.StylePriority.UseFont = False
        '
        'XrLabel5
        '
        Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(76.09801!, 1.999997!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.Text = ":"
        '
        'XrLabel2
        '
        Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(2.000008!, 2.000004!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(74.098!, 13.58334!)
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.Text = "From"
        '
        'LabelDurationDate
        '
        Me.LabelDurationDate.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelDurationDate.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDurationDate.LocationFloat = New DevExpress.Utils.PointFloat(509.375!, 2.000027!)
        Me.LabelDurationDate.Name = "LabelDurationDate"
        Me.LabelDurationDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelDurationDate.SizeF = New System.Drawing.SizeF(130.625!, 13.58332!)
        Me.LabelDurationDate.StylePriority.UseBorders = False
        Me.LabelDurationDate.StylePriority.UseFont = False
        Me.LabelDurationDate.Text = "-"
        '
        'XrLabel13
        '
        Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(497.9167!, 2.000031!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel13.StylePriority.UseBorders = False
        Me.XrLabel13.Text = ":"
        '
        'XrLabel12
        '
        Me.XrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel12.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(357.1524!, 2.000046!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(140.7643!, 13.58334!)
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.Text = "Duration of use (day)"
        '
        'XrLabel3
        '
        Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(2.000014!, 29.16676!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(74.098!, 13.58334!)
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.Text = "Ship To"
        '
        'XrLabel4
        '
        Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(76.098!, 29.1667!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.Text = ":"
        '
        'LabelFrom
        '
        Me.LabelFrom.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelFrom.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFrom.LocationFloat = New DevExpress.Utils.PointFloat(87.55633!, 29.1667!)
        Me.LabelFrom.Name = "LabelFrom"
        Me.LabelFrom.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelFrom.SizeF = New System.Drawing.SizeF(238.5416!, 13.58335!)
        Me.LabelFrom.StylePriority.UseBorders = False
        Me.LabelFrom.StylePriority.UseFont = False
        '
        'LTitle
        '
        Me.LTitle.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTitle.LocationFloat = New DevExpress.Utils.PointFloat(162.5!, 28.71963!)
        Me.LTitle.Name = "LTitle"
        Me.LTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTitle.SizeF = New System.Drawing.SizeF(316.6669!, 15.08334!)
        Me.LTitle.StylePriority.UseFont = False
        Me.LTitle.StylePriority.UseTextAlignment = False
        Me.LTitle.Text = "SAMPLE BORROW REQUISITION"
        Me.LTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'LabelDate
        '
        Me.LabelDate.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDate.LocationFloat = New DevExpress.Utils.PointFloat(564.5001!, 13.58334!)
        Me.LabelDate.Name = "LabelDate"
        Me.LabelDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelDate.SizeF = New System.Drawing.SizeF(85.49988!, 11.49999!)
        Me.LabelDate.StylePriority.UseFont = False
        Me.LabelDate.StylePriority.UseTextAlignment = False
        Me.LabelDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(509.3751!, 13.58337!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(42.62506!, 11.49996!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "DATE"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LabelNo
        '
        Me.LabelNo.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNo.LocationFloat = New DevExpress.Utils.PointFloat(564.5001!, 0.0!)
        Me.LabelNo.Name = "LabelNo"
        Me.LabelNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelNo.SizeF = New System.Drawing.SizeF(85.49994!, 12.49999!)
        Me.LabelNo.StylePriority.UseFont = False
        Me.LabelNo.StylePriority.UseTextAlignment = False
        Me.LabelNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel8
        '
        Me.XrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(552.0001!, 12.5!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(11.45831!, 11.49999!)
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.Text = ":"
        '
        'XrLabel11
        '
        Me.XrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(552.0001!, 0.0!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(11.45837!, 12.49997!)
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.Text = ":"
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(509.3751!, 0.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(42.62506!, 13.58337!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "NO"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 19.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(499.9997!, 0.0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 18.71793!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1, Me.XrPanel2})
        Me.PageFooter.HeightF = 73.51698!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 47.29169!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(649.9996!, 25.0!)
        Me.XrTable1.StylePriority.UseFont = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Font = New System.Drawing.Font("Lucida Console", 8.0!)
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.StylePriority.UseFont = False
        Me.XrTableCell1.Text = "Here Table Mark Goes, Please Ignore This"
        Me.XrTableCell1.Visible = False
        Me.XrTableCell1.Weight = 2.9999998640548888
        '
        'XrPanel2
        '
        Me.XrPanel2.BorderColor = System.Drawing.Color.Black
        Me.XrPanel2.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrPanel2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelNote, Me.XrLabel9, Me.XrLabel14})
        Me.XrPanel2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrPanel2.Name = "XrPanel2"
        Me.XrPanel2.SizeF = New System.Drawing.SizeF(647.9998!, 47.29169!)
        Me.XrPanel2.StylePriority.UseBorderColor = False
        Me.XrPanel2.StylePriority.UseBorders = False
        '
        'LabelNote
        '
        Me.LabelNote.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelNote.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNote.LocationFloat = New DevExpress.Utils.PointFloat(63.598!, 3.833359!)
        Me.LabelNote.Name = "LabelNote"
        Me.LabelNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelNote.SizeF = New System.Drawing.SizeF(576.4018!, 33.45833!)
        Me.LabelNote.StylePriority.UseBorders = False
        Me.LabelNote.StylePriority.UseFont = False
        '
        'XrLabel9
        '
        Me.XrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel9.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(2.000008!, 3.833363!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(50.13963!, 13.58334!)
        Me.XrLabel9.StylePriority.UseBorders = False
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.Text = "Note"
        '
        'XrLabel14
        '
        Me.XrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(52.13963!, 3.833359!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel14.StylePriority.UseBorders = False
        Me.XrLabel14.Text = ":"
        '
        'ReportSampleReq
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter})
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(100, 99, 124, 19)
        Me.PageHeight = 500
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.Version = "11.1"
        CType(Me.GCRetDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRetDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents LabelDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPanel1 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents LabelDurationDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelFrom As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCRetDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRetDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdReq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSamplePurcDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyAll As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrPanel2 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents LabelNote As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelFromUser As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelFromDepartement As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents LDivision As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
End Class
