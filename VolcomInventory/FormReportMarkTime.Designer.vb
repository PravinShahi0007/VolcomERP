<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportMarkTime
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormReportMarkTime))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BSave = New DevExpress.XtraEditors.SimpleButton
        Me.CEGenST = New DevExpress.XtraEditors.CheckEdit
        Me.CEResetST = New DevExpress.XtraEditors.CheckEdit
        Me.PictureSeason = New DevExpress.XtraEditors.PictureEdit
        Me.TESec = New DevExpress.XtraEditors.SpinEdit
        Me.TEMin = New DevExpress.XtraEditors.SpinEdit
        Me.LabelRange = New DevExpress.XtraEditors.LabelControl
        Me.TEHour = New DevExpress.XtraEditors.SpinEdit
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.CEGenST.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEResetST.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TESec.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEMin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEHour.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BCancel)
        Me.PanelControl1.Controls.Add(Me.BSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 137)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(419, 47)
        Me.PanelControl1.TabIndex = 5
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(235, 12)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(75, 23)
        Me.BCancel.TabIndex = 3
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(316, 12)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(75, 23)
        Me.BSave.TabIndex = 2
        Me.BSave.Text = "Save"
        '
        'CEGenST
        '
        Me.CEGenST.EditValue = True
        Me.CEGenST.Location = New System.Drawing.Point(124, 95)
        Me.CEGenST.Name = "CEGenST"
        Me.CEGenST.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.CEGenST.Properties.Appearance.Options.UseFont = True
        Me.CEGenST.Properties.Caption = "Generate Start And Lead Time For Next Assigned"
        Me.CEGenST.Size = New System.Drawing.Size(285, 20)
        Me.CEGenST.TabIndex = 141
        '
        'CEResetST
        '
        Me.CEResetST.EditValue = True
        Me.CEResetST.Location = New System.Drawing.Point(124, 69)
        Me.CEResetST.Name = "CEResetST"
        Me.CEResetST.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.CEResetST.Properties.Appearance.Options.UseFont = True
        Me.CEResetST.Properties.Caption = "Reset Start Time"
        Me.CEResetST.Size = New System.Drawing.Size(269, 20)
        Me.CEResetST.TabIndex = 140
        '
        'PictureSeason
        '
        Me.PictureSeason.EditValue = CType(resources.GetObject("PictureSeason.EditValue"), Object)
        Me.PictureSeason.Location = New System.Drawing.Point(14, 23)
        Me.PictureSeason.Name = "PictureSeason"
        Me.PictureSeason.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureSeason.Properties.Appearance.Options.UseBackColor = True
        Me.PictureSeason.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureSeason.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureSeason.Size = New System.Drawing.Size(96, 88)
        Me.PictureSeason.TabIndex = 139
        '
        'TESec
        '
        Me.TESec.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TESec.Location = New System.Drawing.Point(308, 41)
        Me.TESec.Name = "TESec"
        Me.TESec.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TESec.Properties.Appearance.Options.UseFont = True
        Me.TESec.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.TESec.Properties.IsFloatValue = False
        Me.TESec.Properties.Mask.EditMask = "N00"
        Me.TESec.Properties.MaxValue = New Decimal(New Integer() {59, 0, 0, 0})
        Me.TESec.Size = New System.Drawing.Size(85, 22)
        Me.TESec.TabIndex = 138
        '
        'TEMin
        '
        Me.TEMin.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TEMin.Location = New System.Drawing.Point(217, 41)
        Me.TEMin.Name = "TEMin"
        Me.TEMin.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEMin.Properties.Appearance.Options.UseFont = True
        Me.TEMin.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.TEMin.Properties.IsFloatValue = False
        Me.TEMin.Properties.Mask.EditMask = "N00"
        Me.TEMin.Properties.MaxValue = New Decimal(New Integer() {59, 0, 0, 0})
        Me.TEMin.Size = New System.Drawing.Size(85, 22)
        Me.TEMin.TabIndex = 137
        '
        'LabelRange
        '
        Me.LabelRange.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRange.Location = New System.Drawing.Point(128, 17)
        Me.LabelRange.Name = "LabelRange"
        Me.LabelRange.Size = New System.Drawing.Size(54, 15)
        Me.LabelRange.TabIndex = 136
        Me.LabelRange.Text = "Lead Time"
        '
        'TEHour
        '
        Me.TEHour.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TEHour.Location = New System.Drawing.Point(126, 40)
        Me.TEHour.Name = "TEHour"
        Me.TEHour.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEHour.Properties.Appearance.Options.UseFont = True
        Me.TEHour.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.TEHour.Properties.IsFloatValue = False
        Me.TEHour.Properties.Mask.EditMask = "N00"
        Me.TEHour.Properties.MaxValue = New Decimal(New Integer() {838, 0, 0, 0})
        Me.TEHour.Size = New System.Drawing.Size(85, 22)
        Me.TEHour.TabIndex = 135
        '
        'FormReportMarkTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 184)
        Me.Controls.Add(Me.CEGenST)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.CEResetST)
        Me.Controls.Add(Me.PictureSeason)
        Me.Controls.Add(Me.TEHour)
        Me.Controls.Add(Me.TESec)
        Me.Controls.Add(Me.LabelRange)
        Me.Controls.Add(Me.TEMin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormReportMarkTime"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lead Time"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.CEGenST.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEResetST.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TESec.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEMin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEHour.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CEGenST As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CEResetST As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents PictureSeason As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents TESec As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents TEMin As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelRange As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEHour As DevExpress.XtraEditors.SpinEdit
End Class
