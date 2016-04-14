<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSOHSum
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
        Me.GroupControlMonthlySales = New DevExpress.XtraEditors.GroupControl
        Me.GCSumSOH = New DevExpress.XtraGrid.GridControl
        Me.BGVSalesPOSMonthly = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl
        Me.LEUntilYear = New DevExpress.XtraEditors.LookUpEdit
        Me.LEUntilMonth = New DevExpress.XtraEditors.LookUpEdit
        Me.LEFromYear = New DevExpress.XtraEditors.LookUpEdit
        Me.LEFromMonth = New DevExpress.XtraEditors.LookUpEdit
        Me.BtnViewMonthlySales = New DevExpress.XtraEditors.SimpleButton
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        CType(Me.GroupControlMonthlySales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlMonthlySales.SuspendLayout()
        CType(Me.GCSumSOH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BGVSalesPOSMonthly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.LEUntilYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEUntilMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEFromYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEFromMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControlMonthlySales
        '
        Me.GroupControlMonthlySales.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlMonthlySales.Controls.Add(Me.GCSumSOH)
        Me.GroupControlMonthlySales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlMonthlySales.Enabled = False
        Me.GroupControlMonthlySales.Location = New System.Drawing.Point(0, 50)
        Me.GroupControlMonthlySales.Name = "GroupControlMonthlySales"
        Me.GroupControlMonthlySales.Size = New System.Drawing.Size(984, 277)
        Me.GroupControlMonthlySales.TabIndex = 6
        '
        'GCSumSOH
        '
        Me.GCSumSOH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSumSOH.Location = New System.Drawing.Point(22, 2)
        Me.GCSumSOH.MainView = Me.BGVSalesPOSMonthly
        Me.GCSumSOH.Name = "GCSumSOH"
        Me.GCSumSOH.Size = New System.Drawing.Size(960, 273)
        Me.GCSumSOH.TabIndex = 4
        Me.GCSumSOH.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BGVSalesPOSMonthly})
        '
        'BGVSalesPOSMonthly
        '
        Me.BGVSalesPOSMonthly.GridControl = Me.GCSumSOH
        Me.BGVSalesPOSMonthly.Name = "BGVSalesPOSMonthly"
        Me.BGVSalesPOSMonthly.OptionsBehavior.ReadOnly = True
        Me.BGVSalesPOSMonthly.OptionsView.ShowFooter = True
        Me.BGVSalesPOSMonthly.OptionsView.ShowGroupPanel = False
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.LEUntilYear)
        Me.GroupControl2.Controls.Add(Me.LEUntilMonth)
        Me.GroupControl2.Controls.Add(Me.LEFromYear)
        Me.GroupControl2.Controls.Add(Me.LEFromMonth)
        Me.GroupControl2.Controls.Add(Me.BtnViewMonthlySales)
        Me.GroupControl2.Controls.Add(Me.LabelControl12)
        Me.GroupControl2.Controls.Add(Me.LabelControl13)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(984, 50)
        Me.GroupControl2.TabIndex = 5
        '
        'LEUntilYear
        '
        Me.LEUntilYear.Location = New System.Drawing.Point(530, 14)
        Me.LEUntilYear.Name = "LEUntilYear"
        Me.LEUntilYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEUntilYear.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code_year", "Code", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("label_year", "Year"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_year", "Id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.LEUntilYear.Size = New System.Drawing.Size(110, 20)
        Me.LEUntilYear.TabIndex = 8900
        '
        'LEUntilMonth
        '
        Me.LEUntilMonth.Location = New System.Drawing.Point(372, 14)
        Me.LEUntilMonth.Name = "LEUntilMonth"
        Me.LEUntilMonth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEUntilMonth.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code_month", "Code", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("label_month", "Month")})
        Me.LEUntilMonth.Size = New System.Drawing.Size(152, 20)
        Me.LEUntilMonth.TabIndex = 8899
        '
        'LEFromYear
        '
        Me.LEFromYear.Location = New System.Drawing.Point(219, 14)
        Me.LEFromYear.Name = "LEFromYear"
        Me.LEFromYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEFromYear.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code_year", "Code", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("label_year", "Year"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_year", "Id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.LEFromYear.Size = New System.Drawing.Size(110, 20)
        Me.LEFromYear.TabIndex = 8898
        '
        'LEFromMonth
        '
        Me.LEFromMonth.Location = New System.Drawing.Point(61, 14)
        Me.LEFromMonth.Name = "LEFromMonth"
        Me.LEFromMonth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEFromMonth.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code_month", "Code", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("label_month", "Month")})
        Me.LEFromMonth.Size = New System.Drawing.Size(152, 20)
        Me.LEFromMonth.TabIndex = 8897
        '
        'BtnViewMonthlySales
        '
        Me.BtnViewMonthlySales.Location = New System.Drawing.Point(646, 14)
        Me.BtnViewMonthlySales.LookAndFeel.SkinName = "Blue"
        Me.BtnViewMonthlySales.Name = "BtnViewMonthlySales"
        Me.BtnViewMonthlySales.Size = New System.Drawing.Size(75, 20)
        Me.BtnViewMonthlySales.TabIndex = 8896
        Me.BtnViewMonthlySales.Text = "View"
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(345, 17)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl12.TabIndex = 8893
        Me.LabelControl12.Text = "Until"
        '
        'LabelControl13
        '
        Me.LabelControl13.Location = New System.Drawing.Point(31, 17)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl13.TabIndex = 8892
        Me.LabelControl13.Text = "From"
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "GridBand1"
        Me.GridBand1.Name = "GridBand1"
        '
        'FormSOHSum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 327)
        Me.Controls.Add(Me.GroupControlMonthlySales)
        Me.Controls.Add(Me.GroupControl2)
        Me.MinimizeBox = False
        Me.Name = "FormSOHSum"
        Me.Text = "SOH Summary"
        CType(Me.GroupControlMonthlySales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlMonthlySales.ResumeLayout(False)
        CType(Me.GCSumSOH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BGVSalesPOSMonthly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.LEUntilYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEUntilMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEFromYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEFromMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControlMonthlySales As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCSumSOH As DevExpress.XtraGrid.GridControl
    Friend WithEvents BGVSalesPOSMonthly As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LEUntilYear As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LEUntilMonth As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LEFromYear As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LEFromMonth As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents BtnViewMonthlySales As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
