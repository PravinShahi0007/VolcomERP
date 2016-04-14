<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSeasonorignSingle
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSeasonorignSingle))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.TxtSeasonPrintedName = New DevExpress.XtraEditors.TextEdit
        Me.PictureSeason = New DevExpress.XtraEditors.PictureEdit
        Me.TxtSeason = New DevExpress.XtraEditors.TextEdit
        Me.LabelSeason = New DevExpress.XtraEditors.LabelControl
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton
        Me.EPSeason = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.LECountry = New DevExpress.XtraEditors.LookUpEdit
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.ComboBoxEditYear = New DevExpress.XtraEditors.ComboBoxEdit
        CType(Me.TxtSeasonPrintedName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.EPSeason, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECountry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEditYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(136, 63)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(76, 15)
        Me.LabelControl1.TabIndex = 31
        Me.LabelControl1.Text = "Display Name"
        '
        'TxtSeasonPrintedName
        '
        Me.TxtSeasonPrintedName.Location = New System.Drawing.Point(229, 56)
        Me.TxtSeasonPrintedName.Name = "TxtSeasonPrintedName"
        Me.TxtSeasonPrintedName.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSeasonPrintedName.Properties.Appearance.Options.UseFont = True
        Me.TxtSeasonPrintedName.Size = New System.Drawing.Size(164, 22)
        Me.TxtSeasonPrintedName.TabIndex = 1
        Me.TxtSeasonPrintedName.ToolTip = "Example : SUM US14.  Max :  20 character."
        Me.TxtSeasonPrintedName.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TxtSeasonPrintedName.ToolTipTitle = "Information"
        '
        'PictureSeason
        '
        Me.PictureSeason.EditValue = CType(resources.GetObject("PictureSeason.EditValue"), Object)
        Me.PictureSeason.Location = New System.Drawing.Point(10, 27)
        Me.PictureSeason.Name = "PictureSeason"
        Me.PictureSeason.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureSeason.Properties.Appearance.Options.UseBackColor = True
        Me.PictureSeason.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureSeason.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureSeason.Size = New System.Drawing.Size(124, 113)
        Me.PictureSeason.TabIndex = 29
        '
        'TxtSeason
        '
        Me.TxtSeason.Location = New System.Drawing.Point(229, 28)
        Me.TxtSeason.Name = "TxtSeason"
        Me.TxtSeason.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSeason.Properties.Appearance.Options.UseFont = True
        Me.TxtSeason.Properties.MaxLength = 50
        Me.TxtSeason.Size = New System.Drawing.Size(164, 22)
        Me.TxtSeason.TabIndex = 0
        Me.TxtSeason.ToolTip = "Example : Summer 15 US. Max  : 50 character."
        Me.TxtSeason.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TxtSeason.ToolTipTitle = "Information"
        '
        'LabelSeason
        '
        Me.LabelSeason.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSeason.Location = New System.Drawing.Point(136, 35)
        Me.LabelSeason.Name = "LabelSeason"
        Me.LabelSeason.Size = New System.Drawing.Size(77, 15)
        Me.LabelSeason.TabIndex = 28
        Me.LabelSeason.Text = "Season Origin"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 158)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(418, 51)
        Me.PanelControl1.TabIndex = 5
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(237, 13)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(318, 13)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 3
        Me.BtnSave.Text = "Save"
        '
        'EPSeason
        '
        Me.EPSeason.ContainerControl = Me
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(136, 115)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(43, 15)
        Me.LabelControl2.TabIndex = 34
        Me.LabelControl2.Text = "Country"
        '
        'LECountry
        '
        Me.LECountry.Location = New System.Drawing.Point(229, 112)
        Me.LECountry.Name = "LECountry"
        Me.LECountry.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECountry.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_country", "Id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("country", "Country")})
        Me.LECountry.Size = New System.Drawing.Size(164, 20)
        Me.LECountry.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(136, 91)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 15)
        Me.LabelControl3.TabIndex = 36
        Me.LabelControl3.Text = "Year"
        '
        'ComboBoxEditYear
        '
        Me.ComboBoxEditYear.Location = New System.Drawing.Point(229, 84)
        Me.ComboBoxEditYear.Name = "ComboBoxEditYear"
        Me.ComboBoxEditYear.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxEditYear.Properties.Appearance.Options.UseFont = True
        Me.ComboBoxEditYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEditYear.Size = New System.Drawing.Size(164, 22)
        Me.ComboBoxEditYear.TabIndex = 37
        '
        'FormSeasonorignSingle
        '
        Me.AcceptButton = Me.BtnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(418, 209)
        Me.Controls.Add(Me.ComboBoxEditYear)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TxtSeasonPrintedName)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LECountry)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PictureSeason)
        Me.Controls.Add(Me.TxtSeason)
        Me.Controls.Add(Me.LabelSeason)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSeasonorignSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Season Origin"
        CType(Me.TxtSeasonPrintedName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.EPSeason, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECountry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEditYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtSeasonPrintedName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PictureSeason As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents TxtSeason As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelSeason As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents EPSeason As System.Windows.Forms.ErrorProvider
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LECountry As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ComboBoxEditYear As DevExpress.XtraEditors.ComboBoxEdit
End Class
