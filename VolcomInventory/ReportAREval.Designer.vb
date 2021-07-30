<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ReportAREval
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportAREval))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCInvoiceDetail = New DevExpress.XtraGrid.GridControl()
        Me.GVInvoiceDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepoBtnBBM = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepoLinkInvoice = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.RepoLinkMemo = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.LabelTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.LabelNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        CType(Me.GCInvoiceDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVInvoiceDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoBtnBBM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoLinkInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoLinkMemo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 227.0833!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(1049.0!, 212.5833!)
        Me.WinControlContainer1.WinControl = Me.GCInvoiceDetail
        '
        'GCInvoiceDetail
        '
        Me.GCInvoiceDetail.Location = New System.Drawing.Point(0, 0)
        Me.GCInvoiceDetail.MainView = Me.GVInvoiceDetail
        Me.GCInvoiceDetail.Name = "GCInvoiceDetail"
        Me.GCInvoiceDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepoBtnBBM, Me.RepoLinkInvoice, Me.RepoLinkMemo})
        Me.GCInvoiceDetail.Size = New System.Drawing.Size(1007, 204)
        Me.GCInvoiceDetail.TabIndex = 0
        Me.GCInvoiceDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVInvoiceDetail})
        '
        'GVInvoiceDetail
        '
        Me.GVInvoiceDetail.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GVInvoiceDetail.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GVInvoiceDetail.ColumnPanelRowHeight = 50
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        FormatConditionRuleValue1.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Expression
        FormatConditionRuleValue1.Expression = "Iif([jum_hold] > 1, True, False)"
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.GVInvoiceDetail.FormatRules.Add(GridFormatRule1)
        Me.GVInvoiceDetail.GridControl = Me.GCInvoiceDetail
        Me.GVInvoiceDetail.LevelIndent = 0
        Me.GVInvoiceDetail.Name = "GVInvoiceDetail"
        Me.GVInvoiceDetail.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVInvoiceDetail.OptionsView.ColumnAutoWidth = False
        Me.GVInvoiceDetail.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVInvoiceDetail.OptionsView.ShowFooter = True
        Me.GVInvoiceDetail.OptionsView.ShowGroupedColumns = True
        Me.GVInvoiceDetail.OptionsView.ShowGroupPanel = False
        '
        'RepoBtnBBM
        '
        Me.RepoBtnBBM.AutoHeight = False
        SerializableAppearanceObject1.BackColor = System.Drawing.Color.Teal
        SerializableAppearanceObject1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject1.ForeColor = System.Drawing.Color.White
        SerializableAppearanceObject1.Options.UseBackColor = True
        SerializableAppearanceObject1.Options.UseFont = True
        SerializableAppearanceObject1.Options.UseForeColor = True
        Me.RepoBtnBBM.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "View BBM", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.RepoBtnBBM.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.RepoBtnBBM.Name = "RepoBtnBBM"
        Me.RepoBtnBBM.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'RepoLinkInvoice
        '
        Me.RepoLinkInvoice.AutoHeight = False
        Me.RepoLinkInvoice.Name = "RepoLinkInvoice"
        '
        'RepoLinkMemo
        '
        Me.RepoLinkMemo.AutoHeight = False
        Me.RepoLinkMemo.Name = "RepoLinkMemo"
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelTitle, Me.XrPictureBox1, Me.LabelNumber})
        Me.TopMargin.HeightF = 76.04166!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'LabelTitle
        '
        Me.LabelTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.LocationFloat = New DevExpress.Utils.PointFloat(576.9521!, 26.45833!)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelTitle.SizeF = New System.Drawing.SizeF(472.0478!, 25.08334!)
        Me.LabelTitle.StylePriority.UseFont = False
        Me.LabelTitle.StylePriority.UseTextAlignment = False
        Me.LabelTitle.Text = "AR EVALUATION REPORT"
        Me.LabelTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 26.45833!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(210.4167!, 39.58334!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'LabelNumber
        '
        Me.LabelNumber.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumber.LocationFloat = New DevExpress.Utils.PointFloat(732.5479!, 51.54166!)
        Me.LabelNumber.Name = "LabelNumber"
        Me.LabelNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelNumber.SizeF = New System.Drawing.SizeF(316.4521!, 14.5!)
        Me.LabelNumber.StylePriority.UseFont = False
        Me.LabelNumber.StylePriority.UseTextAlignment = False
        Me.LabelNumber.Text = "EVALUATION DATE : [eval_date]"
        Me.LabelNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel8, Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 48.95833!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel8
        '
        Me.XrLabel8.Font = New System.Drawing.Font("Lucida Sans", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.ForeColor = System.Drawing.Color.Gray
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(548.8425!, 16.04167!)
        Me.XrLabel8.StylePriority.UseBorderColor = False
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseForeColor = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "Printed from Volcom ERP ([printed_date])"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(899.0!, 0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 18.71793!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'ReportAREval
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(52, 68, 76, 49)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCInvoiceDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVInvoiceDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoBtnBBM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoLinkInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoLinkMemo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents LabelTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCInvoiceDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVInvoiceDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepoBtnBBM As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepoLinkInvoice As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents RepoLinkMemo As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
End Class
