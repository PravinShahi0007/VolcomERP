<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportProdCOP
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
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel
        Me.WinControlContainer2 = New DevExpress.XtraReports.UI.WinControlContainer
        Me.GCCost = New DevExpress.XtraGrid.GridControl
        Me.GVCost = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel
        Me.LStatus = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel
        Me.Lkurs = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel
        Me.LTitle = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel
        Me.LDesignName = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel
        Me.LCodeDesign = New DevExpress.XtraReports.UI.XRLabel
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand
        Me.GCListProd = New DevExpress.XtraGrid.GridControl
        Me.GVListProd = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdRecDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdPurcDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnEANCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColQtyOrder = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Me.GridColumnQtyCreated = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyRemaining = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColNote = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn43 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel
        Me.LTotal = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel
        Me.Lqty = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel
        Me.LUnitCost = New DevExpress.XtraReports.UI.XRLabel
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand
        Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel
        Me.LUser = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel
        Me.LCityDate = New DevExpress.XtraReports.UI.XRLabel
        CType(Me.GCCost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCListProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel9, Me.WinControlContainer2})
        Me.Detail.HeightF = 169.7916!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel9
        '
        Me.XrLabel9.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel9.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(625.9999!, 14.99999!)
        Me.XrLabel9.StylePriority.UseBorders = False
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.StylePriority.UseTextAlignment = False
        Me.XrLabel9.Text = "COST"
        Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'WinControlContainer2
        '
        Me.WinControlContainer2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 14.99999!)
        Me.WinControlContainer2.Name = "WinControlContainer2"
        Me.WinControlContainer2.SizeF = New System.Drawing.SizeF(625.9999!, 154.7916!)
        Me.WinControlContainer2.WinControl = Me.GCCost
        '
        'GCCost
        '
        Me.GCCost.Location = New System.Drawing.Point(0, 0)
        Me.GCCost.MainView = Me.GVCost
        Me.GCCost.Name = "GCCost"
        Me.GCCost.Size = New System.Drawing.Size(601, 149)
        Me.GCCost.TabIndex = 4
        Me.GCCost.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCost})
        '
        'GVCost
        '
        Me.GVCost.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVCost.AppearancePrint.FooterPanel.BackColor2 = System.Drawing.Color.White
        Me.GVCost.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Transparent
        Me.GVCost.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVCost.AppearancePrint.FooterPanel.ForeColor = System.Drawing.Color.Black
        Me.GVCost.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVCost.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVCost.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVCost.AppearancePrint.FooterPanel.Options.UseForeColor = True
        Me.GVCost.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVCost.AppearancePrint.GroupFooter.BackColor2 = System.Drawing.Color.White
        Me.GVCost.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Transparent
        Me.GVCost.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVCost.AppearancePrint.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.GVCost.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVCost.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVCost.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVCost.AppearancePrint.GroupFooter.Options.UseForeColor = True
        Me.GVCost.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVCost.AppearancePrint.GroupRow.BackColor2 = System.Drawing.Color.White
        Me.GVCost.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Transparent
        Me.GVCost.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GVCost.AppearancePrint.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.GVCost.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVCost.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVCost.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVCost.AppearancePrint.GroupRow.Options.UseForeColor = True
        Me.GVCost.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.Transparent
        Me.GVCost.AppearancePrint.HeaderPanel.BackColor2 = System.Drawing.Color.Transparent
        Me.GVCost.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVCost.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GVCost.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVCost.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVCost.AppearancePrint.HeaderPanel.Options.UseForeColor = True
        Me.GVCost.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.GVCost.AppearancePrint.Row.Options.UseFont = True
        Me.GVCost.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.GVCost.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn11, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25})
        Me.GVCost.GridControl = Me.GCCost
        Me.GVCost.GroupCount = 1
        Me.GVCost.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_price", Me.GridColumn21, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "price", Me.GridColumn20, "Sub Total{0}")})
        Me.GVCost.Name = "GVCost"
        Me.GVCost.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVCost.OptionsBehavior.Editable = False
        Me.GVCost.OptionsPrint.PrintVertLines = False
        Me.GVCost.OptionsPrint.UsePrintStyles = True
        Me.GVCost.OptionsView.ShowFooter = True
        Me.GVCost.OptionsView.ShowGroupPanel = False
        Me.GVCost.OptionsView.ShowIndicator = False
        Me.GVCost.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn22, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn11
        '
        Me.GridColumn11.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridColumn11.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridColumn11.Caption = "Code"
        Me.GridColumn11.FieldName = "code"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 1
        Me.GridColumn11.Width = 137
        '
        'GridColumn17
        '
        Me.GridColumn17.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridColumn17.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridColumn17.Caption = "Description"
        Me.GridColumn17.FieldName = "description"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 2
        Me.GridColumn17.Width = 267
        '
        'GridColumn18
        '
        Me.GridColumn18.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn18.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn18.Caption = "Size"
        Me.GridColumn18.FieldName = "size"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 3
        Me.GridColumn18.Width = 69
        '
        'GridColumn19
        '
        Me.GridColumn19.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn19.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn19.Caption = "Qty"
        Me.GridColumn19.DisplayFormat.FormatString = "N2"
        Me.GridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn19.FieldName = "qty"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 4
        Me.GridColumn19.Width = 69
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "ID Currency"
        Me.GridColumn26.FieldName = "id_currency"
        Me.GridColumn26.Name = "GridColumn26"
        '
        'GridColumn27
        '
        Me.GridColumn27.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn27.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn27.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn27.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn27.Caption = "Currency"
        Me.GridColumn27.FieldName = "currency"
        Me.GridColumn27.Name = "GridColumn27"
        '
        'GridColumn28
        '
        Me.GridColumn28.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn28.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn28.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn28.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn28.Caption = "Original Price"
        Me.GridColumn28.DisplayFormat.FormatString = "N2"
        Me.GridColumn28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn28.FieldName = "actual_price"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.Width = 122
        '
        'GridColumn20
        '
        Me.GridColumn20.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn20.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn20.Caption = "Price"
        Me.GridColumn20.DisplayFormat.FormatString = "N2"
        Me.GridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn20.FieldName = "price"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "price", "Total")})
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 6
        Me.GridColumn20.Width = 146
        '
        'GridColumn21
        '
        Me.GridColumn21.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn21.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn21.Caption = "Amount"
        Me.GridColumn21.DisplayFormat.FormatString = "N2"
        Me.GridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn21.FieldName = "total_price"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_price", "{0:N2}")})
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 7
        Me.GridColumn21.Width = 185
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Category"
        Me.GridColumn22.FieldName = "category"
        Me.GridColumn22.FieldNameSortGroup = "id_category"
        Me.GridColumn22.Name = "GridColumn22"
        '
        'GridColumn23
        '
        Me.GridColumn23.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn23.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn23.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn23.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn23.Caption = "UOM"
        Me.GridColumn23.FieldName = "uom"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 5
        Me.GridColumn23.Width = 63
        '
        'GridColumn24
        '
        Me.GridColumn24.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn24.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn24.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn24.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn24.Caption = "No"
        Me.GridColumn24.FieldName = "no"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 0
        Me.GridColumn24.Width = 63
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Category"
        Me.GridColumn25.FieldName = "id_category"
        Me.GridColumn25.Name = "GridColumn25"
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel7, Me.XrLabel6, Me.LStatus, Me.XrLabel14, Me.XrLabel12, Me.Lkurs, Me.XrLabel2, Me.LTitle, Me.XrLabel4, Me.XrLabel1, Me.LDesignName, Me.XrLabel5, Me.LCodeDesign})
        Me.TopMargin.HeightF = 75.29163!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel7
        '
        Me.XrLabel7.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(349.0435!, 44.37497!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(90.75354!, 15.0!)
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.Text = "Status"
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(439.7971!, 44.37497!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(13.54172!, 15.0!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.Text = ":"
        '
        'LStatus
        '
        Me.LStatus.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LStatus.LocationFloat = New DevExpress.Utils.PointFloat(453.3389!, 44.37497!)
        Me.LStatus.Name = "LStatus"
        Me.LStatus.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LStatus.SizeF = New System.Drawing.SizeF(172.6609!, 15.0!)
        Me.LStatus.StylePriority.UseFont = False
        Me.LStatus.Text = "BOM"
        '
        'XrLabel14
        '
        Me.XrLabel14.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(63.67019!, 44.37497!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(13.54167!, 15.0!)
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.Text = ":"
        '
        'XrLabel12
        '
        Me.XrLabel12.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(0.00006357829!, 44.37497!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(63.6702!, 15.0!)
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.Text = "Kurs"
        '
        'Lkurs
        '
        Me.Lkurs.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.Lkurs.LocationFloat = New DevExpress.Utils.PointFloat(77.21185!, 44.37497!)
        Me.Lkurs.Name = "Lkurs"
        Me.Lkurs.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Lkurs.SizeF = New System.Drawing.SizeF(223.7446!, 15.0!)
        Me.Lkurs.StylePriority.UseFont = False
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(349.0435!, 22.08335!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(90.75354!, 15.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.Text = "Design Code"
        '
        'LTitle
        '
        Me.LTitle.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.LTitle.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LTitle.LocationFloat = New DevExpress.Utils.PointFloat(0.00006357829!, 0.0!)
        Me.LTitle.Name = "LTitle"
        Me.LTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTitle.SizeF = New System.Drawing.SizeF(625.9999!, 15.08334!)
        Me.LTitle.StylePriority.UseBorders = False
        Me.LTitle.StylePriority.UseFont = False
        Me.LTitle.StylePriority.UseTextAlignment = False
        Me.LTitle.Text = "COST OF PRODUCTION"
        Me.LTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(63.67019!, 22.08335!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(13.54167!, 15.0!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.Text = ":"
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 22.08335!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(63.6702!, 15.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.Text = "Design"
        '
        'LDesignName
        '
        Me.LDesignName.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LDesignName.LocationFloat = New DevExpress.Utils.PointFloat(77.21185!, 22.08335!)
        Me.LDesignName.Name = "LDesignName"
        Me.LDesignName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LDesignName.SizeF = New System.Drawing.SizeF(223.7446!, 15.0!)
        Me.LDesignName.StylePriority.UseFont = False
        Me.LDesignName.Text = "BOM"
        '
        'XrLabel5
        '
        Me.XrLabel5.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(439.7971!, 22.08335!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(13.54172!, 15.0!)
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.Text = ":"
        '
        'LCodeDesign
        '
        Me.LCodeDesign.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LCodeDesign.LocationFloat = New DevExpress.Utils.PointFloat(453.3389!, 22.08335!)
        Me.LCodeDesign.Name = "LCodeDesign"
        Me.LCodeDesign.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LCodeDesign.SizeF = New System.Drawing.SizeF(172.6609!, 15.0!)
        Me.LCodeDesign.StylePriority.UseFont = False
        Me.LCodeDesign.Text = "BOM"
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 27.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'GCListProd
        '
        Me.GCListProd.Location = New System.Drawing.Point(0, 0)
        Me.GCListProd.MainView = Me.GVListProd
        Me.GCListProd.Name = "GCListProd"
        Me.GCListProd.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemSpinEdit1})
        Me.GCListProd.Size = New System.Drawing.Size(601, 96)
        Me.GCListProd.TabIndex = 3
        Me.GCListProd.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListProd, Me.GridView1})
        '
        'GVListProd
        '
        Me.GVListProd.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.Transparent
        Me.GVListProd.AppearancePrint.FooterPanel.ForeColor = System.Drawing.Color.Black
        Me.GVListProd.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVListProd.AppearancePrint.FooterPanel.Options.UseForeColor = True
        Me.GVListProd.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.Transparent
        Me.GVListProd.AppearancePrint.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.GVListProd.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVListProd.AppearancePrint.GroupFooter.Options.UseForeColor = True
        Me.GVListProd.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.Transparent
        Me.GVListProd.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GVListProd.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVListProd.AppearancePrint.HeaderPanel.Options.UseForeColor = True
        Me.GVListProd.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.GVListProd.AppearancePrint.Row.Options.UseFont = True
        Me.GVListProd.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdRecDet, Me.ColIdPurcDet, Me.ColNo, Me.ColCode, Me.GridColumnEANCode, Me.ColName, Me.ColSize, Me.ColQty, Me.ColQtyOrder, Me.GridColumnQtyCreated, Me.GridColumnQtyRemaining, Me.ColNote, Me.GridColumn42, Me.GridColumn43})
        Me.GVListProd.GridControl = Me.GCListProd
        Me.GVListProd.GroupCount = 1
        Me.GVListProd.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "receive_created_qty", Me.GridColumnQtyCreated, "{0:N}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_order_qty", Me.ColQtyOrder, "{0:N}")})
        Me.GVListProd.Name = "GVListProd"
        Me.GVListProd.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVListProd.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVListProd.OptionsBehavior.Editable = False
        Me.GVListProd.OptionsPrint.UsePrintStyles = True
        Me.GVListProd.OptionsView.ShowGroupPanel = False
        Me.GVListProd.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn43, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColIdRecDet
        '
        Me.ColIdRecDet.Caption = "ID Rec Det"
        Me.ColIdRecDet.FieldName = "id_prod_order_rec_det"
        Me.ColIdRecDet.Name = "ColIdRecDet"
        '
        'ColIdPurcDet
        '
        Me.ColIdPurcDet.Caption = "ID Det Order"
        Me.ColIdPurcDet.FieldName = "id_prod_order_det"
        Me.ColIdPurcDet.Name = "ColIdPurcDet"
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.AppearanceHeader.Options.UseTextOptions = True
        Me.ColNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.Caption = "No."
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.OptionsColumn.AllowEdit = False
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 0
        Me.ColNo.Width = 41
        '
        'ColCode
        '
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.OptionsColumn.AllowEdit = False
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 1
        Me.ColCode.Width = 86
        '
        'GridColumnEANCode
        '
        Me.GridColumnEANCode.Caption = "EAN Code"
        Me.GridColumnEANCode.FieldName = "ean_code"
        Me.GridColumnEANCode.Name = "GridColumnEANCode"
        '
        'ColName
        '
        Me.ColName.Caption = "Name"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.OptionsColumn.AllowEdit = False
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 2
        Me.ColName.Width = 217
        '
        'ColSize
        '
        Me.ColSize.AppearanceCell.Options.UseTextOptions = True
        Me.ColSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.Caption = "Size"
        Me.ColSize.FieldName = "size"
        Me.ColSize.Name = "ColSize"
        Me.ColSize.OptionsColumn.AllowEdit = False
        Me.ColSize.Visible = True
        Me.ColSize.VisibleIndex = 3
        Me.ColSize.Width = 59
        '
        'ColQty
        '
        Me.ColQty.AppearanceCell.Options.UseTextOptions = True
        Me.ColQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.Caption = "Qty Limit"
        Me.ColQty.FieldName = "qty"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.OptionsColumn.AllowEdit = False
        Me.ColQty.Width = 121
        '
        'ColQtyOrder
        '
        Me.ColQtyOrder.AppearanceCell.Options.UseTextOptions = True
        Me.ColQtyOrder.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQtyOrder.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQtyOrder.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQtyOrder.Caption = "Qty Order"
        Me.ColQtyOrder.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.ColQtyOrder.DisplayFormat.FormatString = "f0"
        Me.ColQtyOrder.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColQtyOrder.FieldName = "prod_order_qty"
        Me.ColQtyOrder.Name = "ColQtyOrder"
        Me.ColQtyOrder.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_order_qty", "{0:f2}")})
        Me.ColQtyOrder.Visible = True
        Me.ColQtyOrder.VisibleIndex = 4
        Me.ColQtyOrder.Width = 80
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RepositoryItemSpinEdit1.EditValueChangedDelay = 50
        Me.RepositoryItemSpinEdit1.IsFloatValue = False
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f2"
        Me.RepositoryItemSpinEdit1.Mask.SaveLiteral = False
        Me.RepositoryItemSpinEdit1.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-469762049, -590869294, 5421010, 131072})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridColumnQtyCreated
        '
        Me.GridColumnQtyCreated.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyCreated.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyCreated.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyCreated.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyCreated.Caption = "Qty Received"
        Me.GridColumnQtyCreated.DisplayFormat.FormatString = "f0"
        Me.GridColumnQtyCreated.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyCreated.FieldName = "receive_created_qty"
        Me.GridColumnQtyCreated.Name = "GridColumnQtyCreated"
        Me.GridColumnQtyCreated.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "receive_created_qty", "{0:f2}")})
        Me.GridColumnQtyCreated.Visible = True
        Me.GridColumnQtyCreated.VisibleIndex = 5
        Me.GridColumnQtyCreated.Width = 92
        '
        'GridColumnQtyRemaining
        '
        Me.GridColumnQtyRemaining.Caption = "Qty Remaining"
        Me.GridColumnQtyRemaining.DisplayFormat.FormatString = "f2"
        Me.GridColumnQtyRemaining.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyRemaining.FieldName = "receive_created_remaining_qty"
        Me.GridColumnQtyRemaining.Name = "GridColumnQtyRemaining"
        Me.GridColumnQtyRemaining.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "receive_created_remaining_qty", "{0:f2}")})
        Me.GridColumnQtyRemaining.Width = 82
        '
        'ColNote
        '
        Me.ColNote.Caption = "Note"
        Me.ColNote.FieldName = "prod_order_det_note"
        Me.ColNote.Name = "ColNote"
        Me.ColNote.Width = 136
        '
        'GridColumn42
        '
        Me.GridColumn42.Caption = "Id Production Order"
        Me.GridColumn42.FieldName = "id_prod_order"
        Me.GridColumn42.Name = "GridColumn42"
        '
        'GridColumn43
        '
        Me.GridColumn43.Caption = "Production Order"
        Me.GridColumn43.FieldName = "prod_order_number"
        Me.GridColumn43.FieldNameSortGroup = "id_prod_order"
        Me.GridColumn43.Name = "GridColumn43"
        Me.GridColumn43.Visible = True
        Me.GridColumn43.VisibleIndex = 1
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GCListProd
        Me.GridView1.Name = "GridView1"
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 14.99999!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(626.0!, 100.0!)
        Me.WinControlContainer1.WinControl = Me.GCListProd
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel11, Me.WinControlContainer1})
        Me.ReportHeader.HeightF = 115.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XrLabel11
        '
        Me.XrLabel11.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel11.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(626.0!, 14.99999!)
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.StylePriority.UseTextAlignment = False
        Me.XrLabel11.Text = "RECEIVED"
        Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel17
        '
        Me.XrLabel17.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel17.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel17.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel17.Name = "XrLabel17"
        Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel17.SizeF = New System.Drawing.SizeF(500.0001!, 20.00001!)
        Me.XrLabel17.StylePriority.UseBorderColor = False
        Me.XrLabel17.StylePriority.UseBorders = False
        Me.XrLabel17.StylePriority.UseFont = False
        Me.XrLabel17.StylePriority.UseTextAlignment = False
        Me.XrLabel17.Text = "TOTAL COST : "
        Me.XrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'LTotal
        '
        Me.LTotal.BorderColor = System.Drawing.Color.DimGray
        Me.LTotal.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.LTotal.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTotal.LocationFloat = New DevExpress.Utils.PointFloat(500.0001!, 0.0!)
        Me.LTotal.Name = "LTotal"
        Me.LTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTotal.SizeF = New System.Drawing.SizeF(125.9998!, 20.00001!)
        Me.LTotal.StylePriority.UseBorderColor = False
        Me.LTotal.StylePriority.UseBorders = False
        Me.LTotal.StylePriority.UseFont = False
        Me.LTotal.StylePriority.UseTextAlignment = False
        Me.LTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel8
        '
        Me.XrLabel8.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel8.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel8.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 20.00001!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(500.0001!, 20.00001!)
        Me.XrLabel8.StylePriority.UseBorderColor = False
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "RECEIVE QUANTITY : "
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'Lqty
        '
        Me.Lqty.BorderColor = System.Drawing.Color.DimGray
        Me.Lqty.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.Lqty.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lqty.LocationFloat = New DevExpress.Utils.PointFloat(500.0001!, 20.00002!)
        Me.Lqty.Name = "Lqty"
        Me.Lqty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Lqty.SizeF = New System.Drawing.SizeF(125.9998!, 20.00001!)
        Me.Lqty.StylePriority.UseBorderColor = False
        Me.Lqty.StylePriority.UseBorders = False
        Me.Lqty.StylePriority.UseFont = False
        Me.Lqty.StylePriority.UseTextAlignment = False
        Me.Lqty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel10
        '
        Me.XrLabel10.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel10.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel10.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(0.00006357829!, 40.00003!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(500.0001!, 20.00001!)
        Me.XrLabel10.StylePriority.UseBorderColor = False
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.Text = "UNIT COST : "
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'LUnitCost
        '
        Me.LUnitCost.BorderColor = System.Drawing.Color.DimGray
        Me.LUnitCost.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.LUnitCost.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LUnitCost.LocationFloat = New DevExpress.Utils.PointFloat(500.0001!, 40.00003!)
        Me.LUnitCost.Name = "LUnitCost"
        Me.LUnitCost.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LUnitCost.SizeF = New System.Drawing.SizeF(125.9998!, 20.00001!)
        Me.LUnitCost.StylePriority.UseBorderColor = False
        Me.LUnitCost.StylePriority.UseBorders = False
        Me.LUnitCost.StylePriority.UseFont = False
        Me.LUnitCost.StylePriority.UseTextAlignment = False
        Me.LUnitCost.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel15, Me.LUser, Me.XrLabel13, Me.LCityDate, Me.XrLabel8, Me.LTotal, Me.XrLabel17, Me.LUnitCost, Me.XrLabel10, Me.Lqty})
        Me.ReportFooter.HeightF = 162.9167!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrLabel15
        '
        Me.XrLabel15.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel15.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(428.1251!, 81.04172!)
        Me.XrLabel15.Name = "XrLabel15"
        Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel15.SizeF = New System.Drawing.SizeF(197.8748!, 21.04167!)
        Me.XrLabel15.StylePriority.UseBorderColor = False
        Me.XrLabel15.StylePriority.UseBorders = False
        Me.XrLabel15.StylePriority.UseFont = False
        Me.XrLabel15.StylePriority.UseTextAlignment = False
        Me.XrLabel15.Text = "Prepared by :"
        Me.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'LUser
        '
        Me.LUser.BorderColor = System.Drawing.Color.DimGray
        Me.LUser.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LUser.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LUser.LocationFloat = New DevExpress.Utils.PointFloat(428.1252!, 141.8751!)
        Me.LUser.Name = "LUser"
        Me.LUser.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LUser.SizeF = New System.Drawing.SizeF(197.8748!, 21.04167!)
        Me.LUser.StylePriority.UseBorderColor = False
        Me.LUser.StylePriority.UseBorders = False
        Me.LUser.StylePriority.UseFont = False
        Me.LUser.StylePriority.UseTextAlignment = False
        Me.LUser.Text = "User"
        Me.LUser.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel13
        '
        Me.XrLabel13.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel13.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(428.1251!, 102.0834!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(197.8748!, 39.79168!)
        Me.XrLabel13.StylePriority.UseBorderColor = False
        Me.XrLabel13.StylePriority.UseBorders = False
        Me.XrLabel13.StylePriority.UseFont = False
        Me.XrLabel13.StylePriority.UseTextAlignment = False
        Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'LCityDate
        '
        Me.LCityDate.BorderColor = System.Drawing.Color.DimGray
        Me.LCityDate.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LCityDate.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCityDate.LocationFloat = New DevExpress.Utils.PointFloat(428.1251!, 60.00004!)
        Me.LCityDate.Name = "LCityDate"
        Me.LCityDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LCityDate.SizeF = New System.Drawing.SizeF(197.8748!, 21.04167!)
        Me.LCityDate.StylePriority.UseBorderColor = False
        Me.LCityDate.StylePriority.UseBorders = False
        Me.LCityDate.StylePriority.UseFont = False
        Me.LCityDate.StylePriority.UseTextAlignment = False
        Me.LCityDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'ReportProdCOP
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter})
        Me.Margins = New System.Drawing.Printing.Margins(100, 100, 75, 27)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.Version = "11.1"
        CType(Me.GCCost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCListProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LDesignName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LCodeDesign As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents GCListProd As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListProd As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdRecDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdPurcDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEANCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnQtyCreated As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyRemaining As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents WinControlContainer2 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCCost As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCost As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Lqty As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTotal As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LUnitCost As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents LUser As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LCityDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Lkurs As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LStatus As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ColQtyOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn43 As DevExpress.XtraGrid.Columns.GridColumn
End Class
