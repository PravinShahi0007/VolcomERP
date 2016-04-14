<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportSamplePlan
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
        Me.GCListPurchase = New DevExpress.XtraGrid.GridControl
        Me.GVListPurchase = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdSamplePlanDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdSample = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSampleCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSampleName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSampleSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSamplePlanQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.SEQty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Me.ColSamplePlanDetNote = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand
        Me.XrPanel1 = New DevExpress.XtraReports.UI.XRPanel
        Me.LSeason = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel20 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel
        Me.LToName = New DevExpress.XtraReports.UI.XRLabel
        Me.LToAttn = New DevExpress.XtraReports.UI.XRLabel
        Me.LToAddress = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel
        Me.LRecNumber = New DevExpress.XtraReports.UI.XRLabel
        Me.LRecDate = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel
        Me.LTitle = New DevExpress.XtraReports.UI.XRLabel
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand
        Me.LNote = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SEQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 145.8333!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(627.0!, 145.8333!)
        Me.WinControlContainer1.WinControl = Me.GCListPurchase
        '
        'GCListPurchase
        '
        Me.GCListPurchase.Location = New System.Drawing.Point(0, 0)
        Me.GCListPurchase.MainView = Me.GVListPurchase
        Me.GCListPurchase.Name = "GCListPurchase"
        Me.GCListPurchase.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.SEQty})
        Me.GCListPurchase.Size = New System.Drawing.Size(602, 140)
        Me.GCListPurchase.TabIndex = 0
        Me.GCListPurchase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListPurchase})
        '
        'GVListPurchase
        '
        Me.GVListPurchase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColNo, Me.ColIdSamplePlanDet, Me.ColIdSample, Me.ColSampleCode, Me.ColSampleName, Me.GridColumn1, Me.ColSampleSize, Me.ColSamplePlanQty, Me.ColSamplePlanDetNote})
        Me.GVListPurchase.GridControl = Me.GCListPurchase
        Me.GVListPurchase.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GVListPurchase.Name = "GVListPurchase"
        Me.GVListPurchase.OptionsView.ShowGroupPanel = False
        '
        'ColNo
        '
        Me.ColNo.Caption = "No."
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.OptionsColumn.AllowEdit = False
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 0
        Me.ColNo.Width = 49
        '
        'ColIdSamplePlanDet
        '
        Me.ColIdSamplePlanDet.Caption = "Id Sample Plan Det"
        Me.ColIdSamplePlanDet.FieldName = "id_sample_plan_det"
        Me.ColIdSamplePlanDet.Name = "ColIdSamplePlanDet"
        Me.ColIdSamplePlanDet.OptionsColumn.AllowEdit = False
        '
        'ColIdSample
        '
        Me.ColIdSample.Caption = "Id Sample"
        Me.ColIdSample.FieldName = "id_sample"
        Me.ColIdSample.Name = "ColIdSample"
        Me.ColIdSample.OptionsColumn.AllowEdit = False
        '
        'ColSampleCode
        '
        Me.ColSampleCode.Caption = "Code"
        Me.ColSampleCode.FieldName = "code"
        Me.ColSampleCode.Name = "ColSampleCode"
        Me.ColSampleCode.OptionsColumn.AllowEdit = False
        Me.ColSampleCode.Visible = True
        Me.ColSampleCode.VisibleIndex = 1
        Me.ColSampleCode.Width = 148
        '
        'ColSampleName
        '
        Me.ColSampleName.Caption = "Description"
        Me.ColSampleName.FieldName = "name"
        Me.ColSampleName.Name = "ColSampleName"
        Me.ColSampleName.OptionsColumn.AllowEdit = False
        Me.ColSampleName.Visible = True
        Me.ColSampleName.VisibleIndex = 2
        Me.ColSampleName.Width = 190
        '
        'ColSampleSize
        '
        Me.ColSampleSize.AppearanceCell.Options.UseTextOptions = True
        Me.ColSampleSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSampleSize.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSampleSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSampleSize.Caption = "Size"
        Me.ColSampleSize.FieldName = "size"
        Me.ColSampleSize.Name = "ColSampleSize"
        Me.ColSampleSize.OptionsColumn.AllowEdit = False
        Me.ColSampleSize.Visible = True
        Me.ColSampleSize.VisibleIndex = 4
        Me.ColSampleSize.Width = 93
        '
        'ColSamplePlanQty
        '
        Me.ColSamplePlanQty.AppearanceCell.Options.UseTextOptions = True
        Me.ColSamplePlanQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSamplePlanQty.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSamplePlanQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSamplePlanQty.Caption = "Qty"
        Me.ColSamplePlanQty.ColumnEdit = Me.SEQty
        Me.ColSamplePlanQty.FieldName = "qty"
        Me.ColSamplePlanQty.Name = "ColSamplePlanQty"
        Me.ColSamplePlanQty.Visible = True
        Me.ColSamplePlanQty.VisibleIndex = 5
        Me.ColSamplePlanQty.Width = 93
        '
        'SEQty
        '
        Me.SEQty.AutoHeight = False
        Me.SEQty.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.SEQty.Mask.EditMask = "f0"
        Me.SEQty.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.SEQty.Name = "SEQty"
        '
        'ColSamplePlanDetNote
        '
        Me.ColSamplePlanDetNote.Caption = "Note"
        Me.ColSamplePlanDetNote.FieldName = "sample_plan_det_note"
        Me.ColSamplePlanDetNote.Name = "ColSamplePlanDetNote"
        Me.ColSamplePlanDetNote.Visible = True
        Me.ColSamplePlanDetNote.VisibleIndex = 6
        Me.ColSamplePlanDetNote.Width = 193
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPanel1, Me.LRecNumber, Me.LRecDate, Me.XrLabel1, Me.XrLabel12, Me.LTitle})
        Me.TopMargin.HeightF = 92.29164!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPanel1
        '
        Me.XrPanel1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrPanel1.CanGrow = False
        Me.XrPanel1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LSeason, Me.XrLabel20, Me.XrLabel17, Me.XrLabel11, Me.XrLabel10, Me.XrLabel9, Me.LToName, Me.LToAttn, Me.LToAddress, Me.XrLabel4, Me.XrLabel2, Me.XrLabel3})
        Me.XrPanel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 25.08334!)
        Me.XrPanel1.Name = "XrPanel1"
        Me.XrPanel1.SizeF = New System.Drawing.SizeF(627.0!, 67.20831!)
        Me.XrPanel1.StylePriority.UseBorders = False
        '
        'LSeason
        '
        Me.LSeason.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LSeason.LocationFloat = New DevExpress.Utils.PointFloat(435.0834!, 2.000025!)
        Me.LSeason.Name = "LSeason"
        Me.LSeason.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LSeason.SizeF = New System.Drawing.SizeF(181.9165!, 13.58336!)
        Me.LSeason.StylePriority.UseBorders = False
        '
        'XrLabel20
        '
        Me.XrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(423.6251!, 2.000046!)
        Me.XrLabel20.Name = "XrLabel20"
        Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel20.SizeF = New System.Drawing.SizeF(11.45834!, 13.58335!)
        Me.XrLabel20.StylePriority.UseBorders = False
        Me.XrLabel20.Text = ":"
        '
        'XrLabel17
        '
        Me.XrLabel17.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(333.0001!, 2.00001!)
        Me.XrLabel17.Name = "XrLabel17"
        Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel17.SizeF = New System.Drawing.SizeF(90.62494!, 13.58335!)
        Me.XrLabel17.StylePriority.UseBorders = False
        Me.XrLabel17.Text = "Season Orign"
        '
        'XrLabel11
        '
        Me.XrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(53.04168!, 2.000017!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.Text = ":"
        '
        'XrLabel10
        '
        Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(53.04169!, 15.58337!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(11.45834!, 13.58335!)
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.Text = ":"
        '
        'XrLabel9
        '
        Me.XrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(53.04169!, 29.1667!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(11.45834!, 13.58335!)
        Me.XrLabel9.StylePriority.UseBorders = False
        Me.XrLabel9.Text = ":"
        '
        'LToName
        '
        Me.LToName.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LToName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LToName.LocationFloat = New DevExpress.Utils.PointFloat(64.50011!, 2.00003!)
        Me.LToName.Name = "LToName"
        Me.LToName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LToName.SizeF = New System.Drawing.SizeF(262.4999!, 13.58335!)
        Me.LToName.StylePriority.UseBorders = False
        Me.LToName.StylePriority.UseFont = False
        '
        'LToAttn
        '
        Me.LToAttn.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LToAttn.LocationFloat = New DevExpress.Utils.PointFloat(64.50003!, 15.58337!)
        Me.LToAttn.Name = "LToAttn"
        Me.LToAttn.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LToAttn.SizeF = New System.Drawing.SizeF(262.4999!, 13.58335!)
        Me.LToAttn.StylePriority.UseBorders = False
        '
        'LToAddress
        '
        Me.LToAddress.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LToAddress.LocationFloat = New DevExpress.Utils.PointFloat(64.50003!, 29.16672!)
        Me.LToAddress.Name = "LToAddress"
        Me.LToAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LToAddress.SizeF = New System.Drawing.SizeF(262.5!, 27.0!)
        Me.LToAddress.StylePriority.UseBorders = False
        '
        'XrLabel4
        '
        Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(2.000044!, 29.16671!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(51.04166!, 13.58335!)
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.Text = "Address"
        '
        'XrLabel2
        '
        Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(2.000034!, 15.58337!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(51.04166!, 13.58335!)
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.Text = "Attn."
        '
        'XrLabel3
        '
        Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(2.000014!, 2.000014!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(51.04168!, 13.58335!)
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.Text = "To"
        '
        'LRecNumber
        '
        Me.LRecNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LRecNumber.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LRecNumber.LocationFloat = New DevExpress.Utils.PointFloat(79.08341!, 0.0!)
        Me.LRecNumber.Name = "LRecNumber"
        Me.LRecNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LRecNumber.SizeF = New System.Drawing.SizeF(120.9165!, 25.08334!)
        Me.LRecNumber.StylePriority.UseBorders = False
        Me.LRecNumber.StylePriority.UseFont = False
        Me.LRecNumber.StylePriority.UseTextAlignment = False
        Me.LRecNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LRecDate
        '
        Me.LRecDate.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LRecDate.LocationFloat = New DevExpress.Utils.PointFloat(446.9583!, 0.0!)
        Me.LRecDate.Name = "LRecDate"
        Me.LRecDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LRecDate.SizeF = New System.Drawing.SizeF(180.0417!, 25.08334!)
        Me.LRecDate.StylePriority.UseFont = False
        Me.LRecDate.StylePriority.UseTextAlignment = False
        Me.LRecDate.Text = "DATE"
        Me.LRecDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(67.62505!, 25.08334!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "NO"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel12
        '
        Me.XrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel12.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(67.62505!, 0.0!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(11.45835!, 25.08334!)
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = ":"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LTitle
        '
        Me.LTitle.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LTitle.LocationFloat = New DevExpress.Utils.PointFloat(199.9999!, 0.0!)
        Me.LTitle.Name = "LTitle"
        Me.LTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTitle.SizeF = New System.Drawing.SizeF(246.9584!, 25.08334!)
        Me.LTitle.StylePriority.UseFont = False
        Me.LTitle.StylePriority.UseTextAlignment = False
        Me.LTitle.Text = "SAMPLE PLANNING"
        Me.LTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 25.0!
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
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(127.0003!, 18.71792!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LNote, Me.XrLabel5, Me.XrTable1})
        Me.PageFooter.HeightF = 61.45833!
        Me.PageFooter.Name = "PageFooter"
        '
        'LNote
        '
        Me.LNote.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.LNote.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LNote.LocationFloat = New DevExpress.Utils.PointFloat(53.04171!, 0.0!)
        Me.LNote.Name = "LNote"
        Me.LNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LNote.SizeF = New System.Drawing.SizeF(573.9583!, 36.04167!)
        Me.LNote.StylePriority.UseBorders = False
        Me.LNote.StylePriority.UseFont = False
        Me.LNote.StylePriority.UseTextAlignment = False
        Me.LNote.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel5
        '
        Me.XrLabel5.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel5.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(53.04171!, 36.04167!)
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "NOTE :"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 36.45833!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(627.0!, 25.0!)
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
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.Caption = "Color"
        Me.GridColumn1.FieldName = "color"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 3
        Me.GridColumn1.Width = 96
        '
        'ReportSamplePlan
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(100, 100, 92, 25)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.Version = "11.1"
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SEQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents LRecNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LRecDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPanel1 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents LSeason As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LToName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LToAttn As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LToAddress As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCListPurchase As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListPurchase As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdSamplePlanDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSamplePlanQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SEQty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents ColSamplePlanDetNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LNote As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
