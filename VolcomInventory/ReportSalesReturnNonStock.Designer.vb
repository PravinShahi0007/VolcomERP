<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportSalesReturnNonStock
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
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCBarcodeProb = New DevExpress.XtraGrid.GridControl()
        Me.GVBarcodeProb = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRemarkProb = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesignCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemSpinEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.LTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LRecNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.LRecDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPanel1 = New DevExpress.XtraReports.UI.XRPanel()
        Me.LabelReturnStore = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelFrom = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelAddressFrom = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        CType(Me.GCBarcodeProb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBarcodeProb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 184.6354!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(774.0!, 184.6354!)
        Me.WinControlContainer1.WinControl = Me.GCBarcodeProb
        '
        'GCBarcodeProb
        '
        Me.GCBarcodeProb.Location = New System.Drawing.Point(20, 38)
        Me.GCBarcodeProb.MainView = Me.GVBarcodeProb
        Me.GCBarcodeProb.Name = "GCBarcodeProb"
        Me.GCBarcodeProb.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemSpinEdit3})
        Me.GCBarcodeProb.Size = New System.Drawing.Size(743, 177)
        Me.GCBarcodeProb.TabIndex = 6
        Me.GCBarcodeProb.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBarcodeProb})
        '
        'GVBarcodeProb
        '
        Me.GVBarcodeProb.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn3, Me.GridColumn4, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumnRemarkProb, Me.GridColumnDesignCode})
        Me.GVBarcodeProb.GridControl = Me.GCBarcodeProb
        Me.GVBarcodeProb.Name = "GVBarcodeProb"
        Me.GVBarcodeProb.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVBarcodeProb.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVBarcodeProb.OptionsBehavior.Editable = False
        Me.GVBarcodeProb.OptionsCustomization.AllowColumnMoving = False
        Me.GVBarcodeProb.OptionsCustomization.AllowGroup = False
        Me.GVBarcodeProb.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVBarcodeProb.OptionsCustomization.AllowSort = False
        Me.GVBarcodeProb.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "No"
        Me.GridColumn1.FieldName = "no"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn1.OptionsColumn.AllowMove = False
        Me.GridColumn1.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 54
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Scanned Code"
        Me.GridColumn3.FieldName = "code"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 303
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Counting Code"
        Me.GridColumn4.FieldName = "counting_code"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Id PL Counting"
        Me.GridColumn6.FieldName = "id_sales_return_det_counting"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Is Fix"
        Me.GridColumn7.FieldName = "is_fix"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn7.OptionsColumn.AllowMove = False
        Me.GridColumn7.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Id Unique Receiving"
        Me.GridColumn8.FieldName = "id_pl_prod_order_rec_det_unique"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn8.OptionsColumn.AllowMove = False
        Me.GridColumn8.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Id Product"
        Me.GridColumn9.FieldName = "id_product"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Unit Cost"
        Me.GridColumn10.FieldName = "bom_unit_price"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Width = 132
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Id Design Price"
        Me.GridColumn11.FieldName = "id_design_price"
        Me.GridColumn11.Name = "GridColumn11"
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Design Price"
        Me.GridColumn12.FieldName = "design_price"
        Me.GridColumn12.Name = "GridColumn12"
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Description"
        Me.GridColumn13.FieldName = "name"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 2
        Me.GridColumn13.Width = 348
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Size"
        Me.GridColumn14.FieldName = "size"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 3
        Me.GridColumn14.Width = 81
        '
        'GridColumnRemarkProb
        '
        Me.GridColumnRemarkProb.Caption = "Remark"
        Me.GridColumnRemarkProb.FieldName = "remark"
        Me.GridColumnRemarkProb.Name = "GridColumnRemarkProb"
        Me.GridColumnRemarkProb.OptionsColumn.AllowEdit = False
        Me.GridColumnRemarkProb.Visible = True
        Me.GridColumnRemarkProb.VisibleIndex = 4
        Me.GridColumnRemarkProb.Width = 292
        '
        'GridColumnDesignCode
        '
        Me.GridColumnDesignCode.Caption = "Code"
        Me.GridColumnDesignCode.FieldName = "design_code"
        Me.GridColumnDesignCode.Name = "GridColumnDesignCode"
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'RepositoryItemSpinEdit3
        '
        Me.RepositoryItemSpinEdit3.AutoHeight = False
        Me.RepositoryItemSpinEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit3.EditValueChangedDelay = 50
        Me.RepositoryItemSpinEdit3.Mask.EditMask = "n2"
        Me.RepositoryItemSpinEdit3.Mask.SaveLiteral = False
        Me.RepositoryItemSpinEdit3.MaxValue = New Decimal(New Integer() {99999999, 0, 0, 131072})
        Me.RepositoryItemSpinEdit3.Name = "RepositoryItemSpinEdit3"
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LTitle, Me.XrLabel1, Me.XrLabel12, Me.LRecNumber, Me.LRecDate, Me.XrPanel1})
        Me.TopMargin.HeightF = 166.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'LTitle
        '
        Me.LTitle.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTitle.LocationFloat = New DevExpress.Utils.PointFloat(242.6301!, 33.05556!)
        Me.LTitle.Name = "LTitle"
        Me.LTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTitle.SizeF = New System.Drawing.SizeF(276.7966!, 25.08334!)
        Me.LTitle.StylePriority.UseFont = False
        Me.LTitle.StylePriority.UseTextAlignment = False
        Me.LTitle.Text = "NON INVENTORY STOCK"
        Me.LTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 33.05556!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(38.41883!, 25.08334!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "NO"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel12
        '
        Me.XrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel12.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(39.57629!, 33.05556!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(13.7208!, 25.08334!)
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = ":"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LRecNumber
        '
        Me.LRecNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LRecNumber.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LRecNumber.LocationFloat = New DevExpress.Utils.PointFloat(53.29707!, 33.05556!)
        Me.LRecNumber.Name = "LRecNumber"
        Me.LRecNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LRecNumber.SizeF = New System.Drawing.SizeF(189.333!, 25.08334!)
        Me.LRecNumber.StylePriority.UseBorders = False
        Me.LRecNumber.StylePriority.UseFont = False
        Me.LRecNumber.StylePriority.UseTextAlignment = False
        Me.LRecNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LRecDate
        '
        Me.LRecDate.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LRecDate.LocationFloat = New DevExpress.Utils.PointFloat(519.4267!, 33.05558!)
        Me.LRecDate.Name = "LRecDate"
        Me.LRecDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LRecDate.SizeF = New System.Drawing.SizeF(254.5733!, 25.08334!)
        Me.LRecDate.StylePriority.UseFont = False
        Me.LRecDate.StylePriority.UseTextAlignment = False
        Me.LRecDate.Text = "DATE"
        Me.LRecDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
        '
        'XrPanel1
        '
        Me.XrPanel1.BorderColor = System.Drawing.Color.DimGray
        Me.XrPanel1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrPanel1.CanGrow = False
        Me.XrPanel1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelReturnStore, Me.XrLabel7, Me.XrLabel6, Me.XrLabel11, Me.XrLabel10, Me.LabelFrom, Me.LabelAddressFrom, Me.XrLabel2, Me.XrLabel3})
        Me.XrPanel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 58.1389!)
        Me.XrPanel1.Name = "XrPanel1"
        Me.XrPanel1.SizeF = New System.Drawing.SizeF(774.0!, 107.8611!)
        Me.XrPanel1.StylePriority.UseBorderColor = False
        Me.XrPanel1.StylePriority.UseBorders = False
        '
        'LabelReturnStore
        '
        Me.LabelReturnStore.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelReturnStore.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelReturnStore.LocationFloat = New DevExpress.Utils.PointFloat(591.0833!, 10.0!)
        Me.LabelReturnStore.Name = "LabelReturnStore"
        Me.LabelReturnStore.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelReturnStore.SizeF = New System.Drawing.SizeF(180.0834!, 13.58335!)
        Me.LabelReturnStore.StylePriority.UseBorders = False
        Me.LabelReturnStore.StylePriority.UseFont = False
        '
        'XrLabel7
        '
        Me.XrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(579.6249!, 10.00001!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel7.StylePriority.UseBorders = False
        Me.XrLabel7.Text = ":"
        '
        'XrLabel6
        '
        Me.XrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(474.4167!, 10.00001!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(105.2082!, 13.58335!)
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.Text = "Store Return No."
        '
        'XrLabel11
        '
        Me.XrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(107.2082!, 10.00002!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.Text = ":"
        '
        'XrLabel10
        '
        Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(107.2082!, 23.58338!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(11.45834!, 13.58335!)
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.Text = ":"
        '
        'LabelFrom
        '
        Me.LabelFrom.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelFrom.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFrom.LocationFloat = New DevExpress.Utils.PointFloat(118.6665!, 10.00002!)
        Me.LabelFrom.Name = "LabelFrom"
        Me.LabelFrom.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelFrom.SizeF = New System.Drawing.SizeF(295.8334!, 13.58335!)
        Me.LabelFrom.StylePriority.UseBorders = False
        Me.LabelFrom.StylePriority.UseFont = False
        '
        'LabelAddressFrom
        '
        Me.LabelAddressFrom.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelAddressFrom.LocationFloat = New DevExpress.Utils.PointFloat(118.6665!, 23.58338!)
        Me.LabelAddressFrom.Name = "LabelAddressFrom"
        Me.LabelAddressFrom.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelAddressFrom.SizeF = New System.Drawing.SizeF(295.8334!, 45.16662!)
        Me.LabelAddressFrom.StylePriority.UseBorders = False
        '
        'XrLabel2
        '
        Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(1.999982!, 23.58338!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(105.2082!, 13.58335!)
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.Text = "Address"
        '
        'XrLabel3
        '
        Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(2.000023!, 10.00002!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(105.2082!, 13.58335!)
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.Text = "Store"
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 36.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(624.0!, 0!)
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
        Me.PageFooter.HeightF = 100.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'ReportSalesReturnNonStock
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(25, 51, 166, 36)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCBarcodeProb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBarcodeProb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrPanel1 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents LabelReturnStore As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelFrom As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelAddressFrom As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LRecNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LRecDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCBarcodeProb As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBarcodeProb As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemarkProb As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesignCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemSpinEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
End Class
