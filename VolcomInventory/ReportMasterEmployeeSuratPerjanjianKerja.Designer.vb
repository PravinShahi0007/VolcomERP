<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ReportMasterEmployeeSuratPerjanjianKerja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportMasterEmployeeSuratPerjanjianKerja))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrRichText = New DevExpress.XtraReports.UI.XRRichText()
        Me.XLabelDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.L_hrd_employee_position2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.L_hrd_employee_name2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.L_employee_name = New DevExpress.XtraReports.UI.XRLabel()
        Me.L_employee_position = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrRichText1 = New DevExpress.XtraReports.UI.XRRichText()
        Me.XrRichText2 = New DevExpress.XtraReports.UI.XRRichText()
        CType(Me.XrRichText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrRichText1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrRichText2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrRichText2, Me.XrRichText1, Me.L_employee_name, Me.L_employee_position, Me.XrLabel7, Me.XrLabel3, Me.XrLabel2, Me.XLabelDate, Me.L_hrd_employee_position2, Me.L_hrd_employee_name2, Me.XrRichText, Me.XrLabel1, Me.XLNumber})
        Me.Detail.HeightF = 731.8665!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 215.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 100.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 15.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(700.0!, 35.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "PERJANJIAN KERJA WAKTU TERTENTU"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XLNumber
        '
        Me.XLNumber.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.XLNumber.LocationFloat = New DevExpress.Utils.PointFloat(0!, 35.00001!)
        Me.XLNumber.Multiline = True
        Me.XLNumber.Name = "XLNumber"
        Me.XLNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLNumber.SizeF = New System.Drawing.SizeF(700.0!, 25.0!)
        Me.XLNumber.StylePriority.UseFont = False
        Me.XLNumber.StylePriority.UseTextAlignment = False
        Me.XLNumber.Text = "NO. : [number]"
        Me.XLNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrRichText
        '
        Me.XrRichText.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrRichText.KeepTogether = True
        Me.XrRichText.LocationFloat = New DevExpress.Utils.PointFloat(0!, 106.0!)
        Me.XrRichText.Name = "XrRichText"
        Me.XrRichText.SerializableRtfString = resources.GetString("XrRichText.SerializableRtfString")
        Me.XrRichText.SizeF = New System.Drawing.SizeF(700.0!, 22.99999!)
        '
        'XLabelDate
        '
        Me.XLabelDate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XLabelDate.LocationFloat = New DevExpress.Utils.PointFloat(0.00001589457!, 313.0!)
        Me.XLabelDate.Multiline = True
        Me.XLabelDate.Name = "XLabelDate"
        Me.XLabelDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLabelDate.SizeF = New System.Drawing.SizeF(231.25!, 23.0!)
        Me.XLabelDate.StylePriority.UseFont = False
        '
        'L_hrd_employee_position2
        '
        Me.L_hrd_employee_position2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_hrd_employee_position2.LocationFloat = New DevExpress.Utils.PointFloat(0.00001589457!, 515.2831!)
        Me.L_hrd_employee_position2.Multiline = True
        Me.L_hrd_employee_position2.Name = "L_hrd_employee_position2"
        Me.L_hrd_employee_position2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.L_hrd_employee_position2.SizeF = New System.Drawing.SizeF(231.25!, 23.0!)
        Me.L_hrd_employee_position2.StylePriority.UseFont = False
        '
        'L_hrd_employee_name2
        '
        Me.L_hrd_employee_name2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_hrd_employee_name2.LocationFloat = New DevExpress.Utils.PointFloat(0.00001589457!, 492.2832!)
        Me.L_hrd_employee_name2.Multiline = True
        Me.L_hrd_employee_name2.Name = "L_hrd_employee_name2"
        Me.L_hrd_employee_name2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.L_hrd_employee_name2.SizeF = New System.Drawing.SizeF(231.25!, 23.0!)
        Me.L_hrd_employee_name2.StylePriority.UseFont = False
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.00001589457!, 336.0001!)
        Me.XrLabel2.Multiline = True
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(231.25!, 23.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.Text = "Perusahaan,"
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(0.00001589457!, 359.0001!)
        Me.XrLabel3.Multiline = True
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(231.25!, 23.0!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.Text = "PT. Volcom Indonesia"
        '
        'L_employee_name
        '
        Me.L_employee_name.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_employee_name.LocationFloat = New DevExpress.Utils.PointFloat(468.7499!, 492.2832!)
        Me.L_employee_name.Multiline = True
        Me.L_employee_name.Name = "L_employee_name"
        Me.L_employee_name.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.L_employee_name.SizeF = New System.Drawing.SizeF(231.25!, 23.0!)
        Me.L_employee_name.StylePriority.UseFont = False
        '
        'L_employee_position
        '
        Me.L_employee_position.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_employee_position.LocationFloat = New DevExpress.Utils.PointFloat(468.7499!, 515.2831!)
        Me.L_employee_position.Multiline = True
        Me.L_employee_position.Name = "L_employee_position"
        Me.L_employee_position.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.L_employee_position.SizeF = New System.Drawing.SizeF(231.25!, 23.0!)
        Me.L_employee_position.StylePriority.UseFont = False
        '
        'XrLabel7
        '
        Me.XrLabel7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(468.7499!, 336.0001!)
        Me.XrLabel7.Multiline = True
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(231.25!, 23.0!)
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.Text = "Karyawan,"
        '
        'XrRichText1
        '
        Me.XrRichText1.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrRichText1.KeepTogether = True
        Me.XrRichText1.LocationFloat = New DevExpress.Utils.PointFloat(0.00001589457!, 221.0!)
        Me.XrRichText1.Name = "XrRichText1"
        Me.XrRichText1.SerializableRtfString = resources.GetString("XrRichText1.SerializableRtfString")
        Me.XrRichText1.SizeF = New System.Drawing.SizeF(700.0!, 23.0!)
        '
        'XrRichText2
        '
        Me.XrRichText2.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrRichText2.KeepTogether = True
        Me.XrRichText2.LocationFloat = New DevExpress.Utils.PointFloat(0.00001589457!, 244.0!)
        Me.XrRichText2.Name = "XrRichText2"
        Me.XrRichText2.SerializableRtfString = resources.GetString("XrRichText2.SerializableRtfString")
        Me.XrRichText2.SizeF = New System.Drawing.SizeF(700.0!, 23.0!)
        '
        'ReportMasterEmployeeSuratPerjanjianKerja
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.Margins = New System.Drawing.Printing.Margins(75, 75, 215, 100)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.XrRichText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrRichText1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrRichText2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrRichText As DevExpress.XtraReports.UI.XRRichText
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLabelDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents L_hrd_employee_position2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents L_hrd_employee_name2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents L_employee_name As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents L_employee_position As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrRichText2 As DevExpress.XtraReports.UI.XRRichText
    Friend WithEvents XrRichText1 As DevExpress.XtraReports.UI.XRRichText
End Class
