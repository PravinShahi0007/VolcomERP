<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportSampleReturn
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
        Me.GridColumnIdRet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdWHDrawer = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdWHRack = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdWHLOcator = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdWH = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSample = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSampleReturnDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCompName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnWHLoactor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnWHRack = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnWHDrawer = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand
        Me.XrPanel1 = New DevExpress.XtraReports.UI.XRPanel
        Me.LabelSRSNumber = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel
        Me.LabelTo = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel
        Me.LabelFrom = New DevExpress.XtraReports.UI.XRLabel
        Me.LTitle = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel
        Me.LabelNo = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel
        Me.LabelDate = New DevExpress.XtraReports.UI.XRLabel
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
        Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel
        Me.LDivision = New DevExpress.XtraReports.UI.XRLabel
        CType(Me.GCRetDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRetDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 155.2083!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(798.0!, 155.2083!)
        Me.WinControlContainer1.WinControl = Me.GCRetDetail
        '
        'GCRetDetail
        '
        Me.GCRetDetail.Location = New System.Drawing.Point(22, 44)
        Me.GCRetDetail.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCRetDetail.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCRetDetail.MainView = Me.GVRetDetail
        Me.GCRetDetail.Name = "GCRetDetail"
        Me.GCRetDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCRetDetail.Size = New System.Drawing.Size(766, 149)
        Me.GCRetDetail.TabIndex = 1
        Me.GCRetDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRetDetail, Me.GridView1})
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
        Me.GVRetDetail.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 6.75!)
        Me.GVRetDetail.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVRetDetail.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVRetDetail.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVRetDetail.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.GroupFooter.BackColor2 = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVRetDetail.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVRetDetail.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVRetDetail.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.GroupRow.BackColor2 = System.Drawing.Color.White
        Me.GVRetDetail.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVRetDetail.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 6.75!)
        Me.GVRetDetail.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVRetDetail.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVRetDetail.AppearancePrint.GroupRow.Options.UseFont = True
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
        Me.GVRetDetail.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 6.75!)
        Me.GVRetDetail.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVRetDetail.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVRetDetail.AppearancePrint.Row.Options.UseFont = True
        Me.GVRetDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdRet, Me.GridColumnNo, Me.GridColumnIdWHDrawer, Me.GridColumnIdWHRack, Me.GridColumnIdWHLOcator, Me.GridColumnIdWH, Me.GridColumnIdSample, Me.GridColumnIdSampleReturnDet, Me.GridColumnCode, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnCompName, Me.GridColumnWHLoactor, Me.GridColumnWHRack, Me.GridColumnWHDrawer, Me.GridColumnUOM, Me.GridColumnRemark, Me.GridColumnQty})
        Me.GVRetDetail.GridControl = Me.GCRetDetail
        Me.GVRetDetail.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_return_det_qty", Me.GridColumnQty, "{0:n2}")})
        Me.GVRetDetail.Name = "GVRetDetail"
        Me.GVRetDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVRetDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVRetDetail.OptionsBehavior.Editable = False
        Me.GVRetDetail.OptionsPrint.UsePrintStyles = True
        Me.GVRetDetail.OptionsView.ShowFooter = True
        Me.GVRetDetail.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdRet
        '
        Me.GridColumnIdRet.Caption = "ID Ret"
        Me.GridColumnIdRet.FieldName = "id_sample_return"
        Me.GridColumnIdRet.Name = "GridColumnIdRet"
        Me.GridColumnIdRet.OptionsColumn.AllowEdit = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNo.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 78
        '
        'GridColumnIdWHDrawer
        '
        Me.GridColumnIdWHDrawer.Caption = "Id WH Drawer"
        Me.GridColumnIdWHDrawer.FieldName = "id_wh_drawer"
        Me.GridColumnIdWHDrawer.Name = "GridColumnIdWHDrawer"
        '
        'GridColumnIdWHRack
        '
        Me.GridColumnIdWHRack.Caption = "Id WH Rack"
        Me.GridColumnIdWHRack.FieldName = "id_wh_rack"
        Me.GridColumnIdWHRack.Name = "GridColumnIdWHRack"
        '
        'GridColumnIdWHLOcator
        '
        Me.GridColumnIdWHLOcator.Caption = "Id WH Locator"
        Me.GridColumnIdWHLOcator.FieldName = "id_wh_locator"
        Me.GridColumnIdWHLOcator.Name = "GridColumnIdWHLOcator"
        '
        'GridColumnIdWH
        '
        Me.GridColumnIdWH.Caption = "Id WH"
        Me.GridColumnIdWH.FieldName = "id_comp"
        Me.GridColumnIdWH.Name = "GridColumnIdWH"
        '
        'GridColumnIdSample
        '
        Me.GridColumnIdSample.Caption = "Id Sample"
        Me.GridColumnIdSample.FieldName = "id_sample"
        Me.GridColumnIdSample.Name = "GridColumnIdSample"
        '
        'GridColumnIdSampleReturnDet
        '
        Me.GridColumnIdSampleReturnDet.Caption = "Id Sample Return Det"
        Me.GridColumnIdSampleReturnDet.FieldName = "id_sample_return_det"
        Me.GridColumnIdSampleReturnDet.Name = "GridColumnIdSampleReturnDet"
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        Me.GridColumnCode.Width = 166
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 2
        Me.GridColumnName.Width = 176
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
        Me.GridColumnSize.VisibleIndex = 3
        Me.GridColumnSize.Width = 78
        '
        'GridColumnCompName
        '
        Me.GridColumnCompName.Caption = "WH"
        Me.GridColumnCompName.FieldName = "comp_name"
        Me.GridColumnCompName.Name = "GridColumnCompName"
        Me.GridColumnCompName.Width = 90
        '
        'GridColumnWHLoactor
        '
        Me.GridColumnWHLoactor.Caption = "Locator"
        Me.GridColumnWHLoactor.FieldName = "wh_locator"
        Me.GridColumnWHLoactor.Name = "GridColumnWHLoactor"
        Me.GridColumnWHLoactor.Width = 90
        '
        'GridColumnWHRack
        '
        Me.GridColumnWHRack.Caption = "Rack"
        Me.GridColumnWHRack.FieldName = "wh_rack"
        Me.GridColumnWHRack.Name = "GridColumnWHRack"
        Me.GridColumnWHRack.Width = 90
        '
        'GridColumnWHDrawer
        '
        Me.GridColumnWHDrawer.Caption = "Drawer"
        Me.GridColumnWHDrawer.FieldName = "wh_drawer"
        Me.GridColumnWHDrawer.Name = "GridColumnWHDrawer"
        Me.GridColumnWHDrawer.Width = 90
        '
        'GridColumnUOM
        '
        Me.GridColumnUOM.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.Caption = "UOM"
        Me.GridColumnUOM.FieldName = "uom"
        Me.GridColumnUOM.Name = "GridColumnUOM"
        Me.GridColumnUOM.OptionsColumn.AllowEdit = False
        Me.GridColumnUOM.Visible = True
        Me.GridColumnUOM.VisibleIndex = 4
        Me.GridColumnUOM.Width = 51
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.FieldName = "sample_return_det_note"
        Me.GridColumnRemark.MinWidth = 50
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.Visible = True
        Me.GridColumnRemark.VisibleIndex = 6
        Me.GridColumnRemark.Width = 251
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumnQty.FieldName = "sample_return_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_return_det_qty", "{0:n2}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 5
        Me.GridColumnQty.Width = 62
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GCRetDetail
        Me.GridView1.Name = "GridView1"
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPanel1, Me.LTitle, Me.XrLabel6, Me.LabelNo, Me.XrLabel2, Me.XrLabel11, Me.XrLabel1, Me.LabelDate})
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
        Me.XrPanel1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LDivision, Me.XrLabel7, Me.XrLabel15, Me.LabelSRSNumber, Me.XrLabel13, Me.XrLabel12, Me.LabelTo, Me.XrLabel10, Me.XrLabel3, Me.XrLabel4, Me.XrLabel8, Me.LabelFrom})
        Me.XrPanel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 43.20831!)
        Me.XrPanel1.Name = "XrPanel1"
        Me.XrPanel1.SizeF = New System.Drawing.SizeF(798.0!, 56.70524!)
        Me.XrPanel1.StylePriority.UseBorderColor = False
        Me.XrPanel1.StylePriority.UseBorders = False
        '
        'LabelSRSNumber
        '
        Me.LabelSRSNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelSRSNumber.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSRSNumber.LocationFloat = New DevExpress.Utils.PointFloat(564.5001!, 2.000034!)
        Me.LabelSRSNumber.Name = "LabelSRSNumber"
        Me.LabelSRSNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelSRSNumber.SizeF = New System.Drawing.SizeF(202.6665!, 13.58333!)
        Me.LabelSRSNumber.StylePriority.UseBorders = False
        Me.LabelSRSNumber.StylePriority.UseFont = False
        Me.LabelSRSNumber.Text = "-"
        '
        'XrLabel13
        '
        Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(553.0417!, 2.000046!)
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
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(484.1524!, 2.00005!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(68.88928!, 13.58334!)
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.Text = "PL No."
        '
        'LabelTo
        '
        Me.LabelTo.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelTo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTo.LocationFloat = New DevExpress.Utils.PointFloat(63.59793!, 15.58335!)
        Me.LabelTo.Name = "LabelTo"
        Me.LabelTo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelTo.SizeF = New System.Drawing.SizeF(262.4999!, 13.58335!)
        Me.LabelTo.StylePriority.UseBorders = False
        Me.LabelTo.StylePriority.UseFont = False
        '
        'XrLabel10
        '
        Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(52.13964!, 15.58335!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(11.45831!, 13.58334!)
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.Text = ":"
        '
        'XrLabel3
        '
        Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(2.0!, 2.0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(50.13963!, 13.58334!)
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.Text = "From"
        '
        'XrLabel4
        '
        Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(52.13963!, 2.000001!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.Text = ":"
        '
        'XrLabel8
        '
        Me.XrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel8.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(1.999997!, 15.58335!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(50.13963!, 13.58335!)
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.Text = "To"
        '
        'LabelFrom
        '
        Me.LabelFrom.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelFrom.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFrom.LocationFloat = New DevExpress.Utils.PointFloat(63.59798!, 2.0!)
        Me.LabelFrom.Name = "LabelFrom"
        Me.LabelFrom.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelFrom.SizeF = New System.Drawing.SizeF(262.4999!, 13.58335!)
        Me.LabelFrom.StylePriority.UseBorders = False
        Me.LabelFrom.StylePriority.UseFont = False
        '
        'LTitle
        '
        Me.LTitle.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTitle.LocationFloat = New DevExpress.Utils.PointFloat(247.8331!, 28.12498!)
        Me.LTitle.Name = "LTitle"
        Me.LTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTitle.SizeF = New System.Drawing.SizeF(316.6669!, 15.08334!)
        Me.LTitle.StylePriority.UseFont = False
        Me.LTitle.StylePriority.UseTextAlignment = False
        Me.LTitle.Text = "RETURN SAMPLE BORROW"
        Me.LTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(635.4165!, 12.49998!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(42.62509!, 12.49999!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "DATE"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LabelNo
        '
        Me.LabelNo.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNo.LocationFloat = New DevExpress.Utils.PointFloat(689.5001!, 0.0!)
        Me.LabelNo.Name = "LabelNo"
        Me.LabelNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelNo.SizeF = New System.Drawing.SizeF(98.49994!, 12.49999!)
        Me.LabelNo.StylePriority.UseFont = False
        Me.LabelNo.StylePriority.UseTextAlignment = False
        Me.LabelNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(678.0416!, 12.49998!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(11.45837!, 12.49999!)
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.Text = ":"
        '
        'XrLabel11
        '
        Me.XrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(678.0416!, 0.0!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(11.45837!, 12.49999!)
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.Text = ":"
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(635.4165!, 0.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(42.62509!, 12.49999!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "NO"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LabelDate
        '
        Me.LabelDate.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDate.LocationFloat = New DevExpress.Utils.PointFloat(689.5001!, 12.49998!)
        Me.LabelDate.Name = "LabelDate"
        Me.LabelDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelDate.SizeF = New System.Drawing.SizeF(98.49994!, 12.49999!)
        Me.LabelDate.StylePriority.UseFont = False
        Me.LabelDate.StylePriority.UseTextAlignment = False
        Me.LabelDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 21.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(648.0!, 0.0!)
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
        Me.PageFooter.HeightF = 107.2917!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(2.000014!, 47.29169!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(795.9999!, 25.0!)
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
        Me.XrPanel2.SizeF = New System.Drawing.SizeF(798.0!, 47.29169!)
        Me.XrPanel2.StylePriority.UseBorderColor = False
        Me.XrPanel2.StylePriority.UseBorders = False
        '
        'LabelNote
        '
        Me.LabelNote.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelNote.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNote.LocationFloat = New DevExpress.Utils.PointFloat(63.598!, 3.833358!)
        Me.LabelNote.Name = "LabelNote"
        Me.LabelNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelNote.SizeF = New System.Drawing.SizeF(724.402!, 33.45833!)
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
        'XrLabel15
        '
        Me.XrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel15.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(484.1524!, 15.58336!)
        Me.XrLabel15.Name = "XrLabel15"
        Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel15.SizeF = New System.Drawing.SizeF(68.88928!, 13.58334!)
        Me.XrLabel15.StylePriority.UseBorders = False
        Me.XrLabel15.StylePriority.UseFont = False
        Me.XrLabel15.Text = "Division"
        '
        'XrLabel7
        '
        Me.XrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(553.0417!, 15.5834!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel7.StylePriority.UseBorders = False
        Me.XrLabel7.Text = ":"
        '
        'LDivision
        '
        Me.LDivision.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LDivision.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LDivision.LocationFloat = New DevExpress.Utils.PointFloat(564.5001!, 15.5834!)
        Me.LDivision.Name = "LDivision"
        Me.LDivision.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LDivision.SizeF = New System.Drawing.SizeF(202.6665!, 13.58333!)
        Me.LDivision.StylePriority.UseBorders = False
        Me.LDivision.StylePriority.UseFont = False
        Me.LDivision.Text = "-"
        '
        'ReportSampleReturn
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(26, 26, 100, 21)
        Me.PageHeight = 500
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.Version = "11.1"
        CType(Me.GCRetDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRetDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrPanel2 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents LabelNote As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCRetDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRetDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdRet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdWHDrawer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdWHRack As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdWHLOcator As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdWH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSampleReturnDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWHLoactor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWHRack As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWHDrawer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPanel1 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents LabelSRSNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelTo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelFrom As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents LDivision As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
End Class
