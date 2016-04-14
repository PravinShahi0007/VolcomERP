<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportMatStockOpnameSum
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
        Me.GCMatList = New DevExpress.XtraGrid.GridControl
        Me.GVMatList = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIDMatDetPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnNox = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCategory = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnLot = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyReal = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel
        Me.LTitle = New DevExpress.XtraReports.UI.XRLabel
        Me.LabelNo = New DevExpress.XtraReports.UI.XRLabel
        Me.LabelDate = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrPanel1 = New DevExpress.XtraReports.UI.XRPanel
        Me.LSourceAddress = New DevExpress.XtraReports.UI.XRLabel
        Me.LLastUpd = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel20 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel18 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel
        Me.LSource = New DevExpress.XtraReports.UI.XRLabel
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell
        CType(Me.GCMatList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMatList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 133.3333!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(749.0!, 133.3333!)
        Me.WinControlContainer1.WinControl = Me.GCMatList
        '
        'GCMatList
        '
        Me.GCMatList.Location = New System.Drawing.Point(200, 35)
        Me.GCMatList.MainView = Me.GVMatList
        Me.GCMatList.Name = "GCMatList"
        Me.GCMatList.Size = New System.Drawing.Size(719, 128)
        Me.GCMatList.TabIndex = 4
        Me.GCMatList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMatList})
        '
        'GVMatList
        '
        Me.GVMatList.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.Transparent
        Me.GVMatList.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 6.0!)
        Me.GVMatList.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GVMatList.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVMatList.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVMatList.AppearancePrint.HeaderPanel.Options.UseForeColor = True
        Me.GVMatList.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 6.0!)
        Me.GVMatList.AppearancePrint.Row.Options.UseFont = True
        Me.GVMatList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIDMatDetPrice, Me.GridColumnNox, Me.GridColumnCategory, Me.GridColumnName, Me.GridColumnCode, Me.GridColumnColor, Me.GridColumnSize, Me.GridColumn2, Me.GridColumnUOM, Me.GridColumnLot, Me.GridColumnQtyReal, Me.GridColumn1})
        Me.GVMatList.GridControl = Me.GCMatList
        Me.GVMatList.Name = "GVMatList"
        Me.GVMatList.OptionsBehavior.Editable = False
        Me.GVMatList.OptionsFind.AlwaysVisible = True
        Me.GVMatList.OptionsPrint.UsePrintStyles = True
        Me.GVMatList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIDMatDetPrice
        '
        Me.GridColumnIDMatDetPrice.Caption = "Id Mat Det Price"
        Me.GridColumnIDMatDetPrice.FieldName = "id_mat_det"
        Me.GridColumnIDMatDetPrice.Name = "GridColumnIDMatDetPrice"
        '
        'GridColumnNox
        '
        Me.GridColumnNox.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnNox.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNox.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnNox.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNox.Caption = "No"
        Me.GridColumnNox.FieldName = "no"
        Me.GridColumnNox.Name = "GridColumnNox"
        Me.GridColumnNox.Visible = True
        Me.GridColumnNox.VisibleIndex = 0
        Me.GridColumnNox.Width = 33
        '
        'GridColumnCategory
        '
        Me.GridColumnCategory.Caption = "Category"
        Me.GridColumnCategory.FieldName = "mat_cat"
        Me.GridColumnCategory.Name = "GridColumnCategory"
        Me.GridColumnCategory.Visible = True
        Me.GridColumnCategory.VisibleIndex = 1
        Me.GridColumnCategory.Width = 56
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Description"
        Me.GridColumnName.FieldName = "mat_det_name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 3
        Me.GridColumnName.Width = 145
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "mat_det_code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 2
        Me.GridColumnCode.Width = 63
        '
        'GridColumnColor
        '
        Me.GridColumnColor.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 4
        Me.GridColumnColor.Width = 35
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
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 5
        Me.GridColumnSize.Width = 35
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.Caption = "Qty SO"
        Me.GridColumn2.DisplayFormat.FormatString = "N2"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "mat_so_sum_qty"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 9
        Me.GridColumn2.Width = 56
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
        Me.GridColumnUOM.Visible = True
        Me.GridColumnUOM.VisibleIndex = 7
        Me.GridColumnUOM.Width = 35
        '
        'GridColumnLot
        '
        Me.GridColumnLot.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnLot.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnLot.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnLot.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnLot.Caption = "Lot"
        Me.GridColumnLot.FieldName = "lot"
        Me.GridColumnLot.Name = "GridColumnLot"
        Me.GridColumnLot.Visible = True
        Me.GridColumnLot.VisibleIndex = 6
        Me.GridColumnLot.Width = 35
        '
        'GridColumnQtyReal
        '
        Me.GridColumnQtyReal.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyReal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyReal.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyReal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyReal.Caption = "Qty"
        Me.GridColumnQtyReal.DisplayFormat.FormatString = "N2"
        Me.GridColumnQtyReal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyReal.FieldName = "mat_qty"
        Me.GridColumnQtyReal.Name = "GridColumnQtyReal"
        Me.GridColumnQtyReal.Visible = True
        Me.GridColumnQtyReal.VisibleIndex = 8
        Me.GridColumnQtyReal.Width = 51
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn1.Caption = "+/-"
        Me.GridColumn1.DisplayFormat.FormatString = "N2"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn1.FieldName = "mat_so_sum_dif"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 10
        Me.GridColumn1.Width = 59
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel11, Me.LTitle, Me.LabelNo, Me.LabelDate, Me.XrLabel1, Me.XrLabel6, Me.XrLabel8, Me.XrPanel1})
        Me.TopMargin.HeightF = 94.53523!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel11
        '
        Me.XrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(42.62508!, 0.0!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(11.45837!, 23.87497!)
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.StylePriority.UseTextAlignment = False
        Me.XrLabel11.Text = ":"
        Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'LTitle
        '
        Me.LTitle.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTitle.LocationFloat = New DevExpress.Utils.PointFloat(151.0416!, 0.0!)
        Me.LTitle.Name = "LTitle"
        Me.LTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTitle.SizeF = New System.Drawing.SizeF(447.875!, 23.87497!)
        Me.LTitle.StylePriority.UseFont = False
        Me.LTitle.StylePriority.UseTextAlignment = False
        Me.LTitle.Text = "STOCK OPNAME SUMMARY"
        Me.LTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'LabelNo
        '
        Me.LabelNo.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNo.LocationFloat = New DevExpress.Utils.PointFloat(54.08345!, 0.0!)
        Me.LabelNo.Name = "LabelNo"
        Me.LabelNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelNo.SizeF = New System.Drawing.SizeF(96.9582!, 23.87497!)
        Me.LabelNo.StylePriority.UseFont = False
        Me.LabelNo.StylePriority.UseTextAlignment = False
        Me.LabelNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LabelDate
        '
        Me.LabelDate.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDate.LocationFloat = New DevExpress.Utils.PointFloat(653.0001!, 0.0!)
        Me.LabelDate.Name = "LabelDate"
        Me.LabelDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelDate.SizeF = New System.Drawing.SizeF(95.99994!, 23.87497!)
        Me.LabelDate.StylePriority.UseFont = False
        Me.LabelDate.StylePriority.UseTextAlignment = False
        Me.LabelDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(42.62506!, 23.87497!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "NO"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(598.9167!, 0.0!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(42.62506!, 23.87497!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "DATE"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel8
        '
        Me.XrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(641.5417!, 0.0!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(11.45831!, 23.87497!)
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = ":"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrPanel1
        '
        Me.XrPanel1.BorderColor = System.Drawing.Color.Black
        Me.XrPanel1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrPanel1.CanGrow = False
        Me.XrPanel1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LSourceAddress, Me.LLastUpd, Me.XrLabel20, Me.XrLabel18, Me.XrLabel3, Me.XrLabel4, Me.LSource})
        Me.XrPanel1.LocationFloat = New DevExpress.Utils.PointFloat(0.00006357829!, 23.87497!)
        Me.XrPanel1.Name = "XrPanel1"
        Me.XrPanel1.SizeF = New System.Drawing.SizeF(748.9999!, 70.66026!)
        Me.XrPanel1.StylePriority.UseBorderColor = False
        Me.XrPanel1.StylePriority.UseBorders = False
        '
        'LSourceAddress
        '
        Me.LSourceAddress.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LSourceAddress.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSourceAddress.LocationFloat = New DevExpress.Utils.PointFloat(108.3896!, 15.58329!)
        Me.LSourceAddress.Name = "LSourceAddress"
        Me.LSourceAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LSourceAddress.SizeF = New System.Drawing.SizeF(222.9166!, 34.41658!)
        Me.LSourceAddress.StylePriority.UseBorders = False
        Me.LSourceAddress.StylePriority.UseFont = False
        '
        'LLastUpd
        '
        Me.LLastUpd.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LLastUpd.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LLastUpd.LocationFloat = New DevExpress.Utils.PointFloat(563.7377!, 2.000093!)
        Me.LLastUpd.Name = "LLastUpd"
        Me.LLastUpd.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LLastUpd.SizeF = New System.Drawing.SizeF(179.304!, 13.58331!)
        Me.LLastUpd.StylePriority.UseBorders = False
        Me.LLastUpd.StylePriority.UseFont = False
        '
        'XrLabel20
        '
        Me.XrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(552.2792!, 2.000062!)
        Me.XrLabel20.Name = "XrLabel20"
        Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel20.SizeF = New System.Drawing.SizeF(11.4584!, 13.58335!)
        Me.XrLabel20.StylePriority.UseBorders = False
        Me.XrLabel20.Text = ":"
        '
        'XrLabel18
        '
        Me.XrLabel18.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel18.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(457.3479!, 1.999998!)
        Me.XrLabel18.Name = "XrLabel18"
        Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel18.SizeF = New System.Drawing.SizeF(94.93129!, 13.58331!)
        Me.XrLabel18.StylePriority.UseBorders = False
        Me.XrLabel18.StylePriority.UseFont = False
        Me.XrLabel18.Text = "Last Update"
        '
        'XrLabel3
        '
        Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(2.000014!, 2.0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(94.9313!, 13.58334!)
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.Text = "Source"
        '
        'XrLabel4
        '
        Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(96.9313!, 2.00003!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.Text = ":"
        '
        'LSource
        '
        Me.LSource.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LSource.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSource.LocationFloat = New DevExpress.Utils.PointFloat(108.3896!, 2.000031!)
        Me.LSource.Name = "LSource"
        Me.LSource.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LSource.SizeF = New System.Drawing.SizeF(222.9166!, 13.58335!)
        Me.LSource.StylePriority.UseBorders = False
        Me.LSource.StylePriority.UseFont = False
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
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(599.0!, 0.0!)
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
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.PageFooter.HeightF = 25.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(749.0!, 25.0!)
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
        'ReportMatStockOpnameSum
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(50, 26, 95, 19)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.Version = "11.1"
        CType(Me.GCMatList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMatList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPanel1 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents LSourceAddress As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LLastUpd As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LSource As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCMatList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMatList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIDMatDetPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNox As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLot As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyReal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
End Class
