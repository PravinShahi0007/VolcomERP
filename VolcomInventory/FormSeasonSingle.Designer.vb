<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSeasonSingle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSeasonSingle))
        Me.LabelYear = New DevExpress.XtraEditors.LabelControl
        Me.LabelSeason = New DevExpress.XtraEditors.LabelControl
        Me.TxtSeason = New DevExpress.XtraEditors.TextEdit
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.PictureSeason = New DevExpress.XtraEditors.PictureEdit
        Me.ErrorProviderSeason = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TxtSeasonPrintedName = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.DEStart = New DevExpress.XtraEditors.DateEdit
        Me.DEEnd = New DevExpress.XtraEditors.DateEdit
        CType(Me.TxtSeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderSeason, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSeasonPrintedName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEStart.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelYear
        '
        Me.LabelYear.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelYear.Location = New System.Drawing.Point(145, 89)
        Me.LabelYear.Name = "LabelYear"
        Me.LabelYear.Size = New System.Drawing.Size(53, 15)
        Me.LabelYear.TabIndex = 1
        Me.LabelYear.Text = "Start date"
        '
        'LabelSeason
        '
        Me.LabelSeason.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSeason.Location = New System.Drawing.Point(145, 35)
        Me.LabelSeason.Name = "LabelSeason"
        Me.LabelSeason.Size = New System.Drawing.Size(39, 15)
        Me.LabelSeason.TabIndex = 2
        Me.LabelSeason.Text = "Season"
        '
        'TxtSeason
        '
        Me.TxtSeason.Location = New System.Drawing.Point(238, 28)
        Me.TxtSeason.Name = "TxtSeason"
        Me.TxtSeason.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSeason.Properties.Appearance.Options.UseFont = True
        Me.TxtSeason.Properties.MaxLength = 50
        Me.TxtSeason.Size = New System.Drawing.Size(164, 22)
        Me.TxtSeason.TabIndex = 0
        Me.TxtSeason.ToolTip = "Example : Holiday 14.  Max :  50 character."
        Me.TxtSeason.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TxtSeason.ToolTipTitle = "Information"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(327, 13)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 4
        Me.BtnSave.Text = "Save"
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(246, 13)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Cancel"
        '
        'PictureSeason
        '
        Me.PictureSeason.EditValue = CType(resources.GetObject("PictureSeason.EditValue"), Object)
        Me.PictureSeason.Location = New System.Drawing.Point(12, 21)
        Me.PictureSeason.Name = "PictureSeason"
        Me.PictureSeason.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureSeason.Properties.Appearance.Options.UseBackColor = True
        Me.PictureSeason.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureSeason.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureSeason.Size = New System.Drawing.Size(124, 113)
        Me.PictureSeason.TabIndex = 18
        '
        'ErrorProviderSeason
        '
        Me.ErrorProviderSeason.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProviderSeason.ContainerControl = Me
        '
        'TxtSeasonPrintedName
        '
        Me.TxtSeasonPrintedName.Location = New System.Drawing.Point(238, 56)
        Me.TxtSeasonPrintedName.Name = "TxtSeasonPrintedName"
        Me.TxtSeasonPrintedName.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSeasonPrintedName.Properties.Appearance.Options.UseFont = True
        Me.TxtSeasonPrintedName.Size = New System.Drawing.Size(164, 22)
        Me.TxtSeasonPrintedName.TabIndex = 1
        Me.TxtSeasonPrintedName.ToolTip = "Example : SH 14.  Max :  20 character."
        Me.TxtSeasonPrintedName.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TxtSeasonPrintedName.ToolTipTitle = "Information"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(145, 63)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(76, 15)
        Me.LabelControl1.TabIndex = 26
        Me.LabelControl1.Text = "Display Name"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 158)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(427, 53)
        Me.PanelControl1.TabIndex = 5
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(145, 119)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(48, 15)
        Me.LabelControl2.TabIndex = 29
        Me.LabelControl2.Text = "End Date"
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(238, 82)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DEStart.Properties.Appearance.Options.UseFont = True
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.DEStart.Size = New System.Drawing.Size(164, 22)
        Me.DEStart.TabIndex = 2
        '
        'DEEnd
        '
        Me.DEEnd.EditValue = Nothing
        Me.DEEnd.Location = New System.Drawing.Point(238, 112)
        Me.DEEnd.Name = "DEEnd"
        Me.DEEnd.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DEEnd.Properties.Appearance.Options.UseFont = True
        Me.DEEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.DEEnd.Size = New System.Drawing.Size(164, 22)
        Me.DEEnd.TabIndex = 3
        '
        'FormSeasonSingle
        '
        Me.AcceptButton = Me.BtnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(427, 211)
        Me.Controls.Add(Me.DEEnd)
        Me.Controls.Add(Me.DEStart)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.TxtSeasonPrintedName)
        Me.Controls.Add(Me.PictureSeason)
        Me.Controls.Add(Me.TxtSeason)
        Me.Controls.Add(Me.LabelSeason)
        Me.Controls.Add(Me.LabelYear)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSeasonSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Season"
        CType(Me.TxtSeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderSeason, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSeasonPrintedName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.DEStart.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelYear As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelSeason As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtSeason As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PictureSeason As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents ErrorProviderSeason As System.Windows.Forms.ErrorProvider
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtSeasonPrintedName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
End Class
