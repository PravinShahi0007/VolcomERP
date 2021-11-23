<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportVerificationMasterPrice
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
        Me.GCVerification = New DevExpress.XtraGrid.GridControl()
        Me.GVVerification = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XLFilename = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        CType(Me.GCVerification, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVVerification, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 104.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(756.0!, 104.0!)
        Me.WinControlContainer1.WinControl = Me.GCVerification
        '
        'GCVerification
        '
        Me.GCVerification.Location = New System.Drawing.Point(0, 38)
        Me.GCVerification.MainView = Me.GVVerification
        Me.GCVerification.Name = "GCVerification"
        Me.GCVerification.Size = New System.Drawing.Size(726, 100)
        Me.GCVerification.TabIndex = 1
        Me.GCVerification.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVVerification})
        '
        'GVVerification
        '
        Me.GVVerification.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVVerification.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVVerification.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVVerification.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVVerification.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVVerification.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVVerification.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVVerification.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVVerification.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVVerification.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVVerification.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVVerification.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVVerification.GridControl = Me.GCVerification
        Me.GVVerification.Name = "GVVerification"
        Me.GVVerification.OptionsBehavior.ReadOnly = True
        Me.GVVerification.OptionsView.ShowGroupPanel = False
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 50.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 50.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(606.0!, 0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 18.71793!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XLFilename
        '
        Me.XLFilename.Font = New System.Drawing.Font("Times New Roman", 12.75!, System.Drawing.FontStyle.Bold)
        Me.XLFilename.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XLFilename.Name = "XLFilename"
        Me.XLFilename.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLFilename.SizeF = New System.Drawing.SizeF(756.0!, 23.0!)
        Me.XLFilename.StylePriority.UseFont = False
        Me.XLFilename.StylePriority.UseTextAlignment = False
        Me.XLFilename.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XLFilename})
        Me.ReportHeader.HeightF = 55.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'ReportVerificationMasterPrice
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader})
        Me.Margins = New System.Drawing.Printing.Margins(25, 69, 50, 50)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCVerification, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVVerification, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XLFilename As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCVerification As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVVerification As DevExpress.XtraGrid.Views.Grid.GridView
End Class
