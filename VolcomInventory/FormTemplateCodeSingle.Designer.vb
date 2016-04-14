<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTemplateCodeSingle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTemplateCodeSingle))
        Me.EPTemplateCode = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PictureSeason = New DevExpress.XtraEditors.PictureEdit
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton
        Me.TETemplateCode = New DevExpress.XtraEditors.TextEdit
        Me.LabelSeason = New DevExpress.XtraEditors.LabelControl
        CType(Me.EPTemplateCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TETemplateCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EPTemplateCode
        '
        Me.EPTemplateCode.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EPTemplateCode.ContainerControl = Me
        '
        'PictureSeason
        '
        Me.PictureSeason.EditValue = CType(resources.GetObject("PictureSeason.EditValue"), Object)
        Me.PictureSeason.Location = New System.Drawing.Point(12, 2)
        Me.PictureSeason.Name = "PictureSeason"
        Me.PictureSeason.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureSeason.Properties.Appearance.Options.UseBackColor = True
        Me.PictureSeason.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureSeason.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureSeason.Size = New System.Drawing.Size(141, 91)
        Me.PictureSeason.TabIndex = 36
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(295, 54)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 34
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(376, 54)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 33
        Me.BtnSave.Text = "Save"
        '
        'TETemplateCode
        '
        Me.TETemplateCode.Location = New System.Drawing.Point(222, 22)
        Me.TETemplateCode.Name = "TETemplateCode"
        Me.TETemplateCode.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TETemplateCode.Properties.Appearance.Options.UseFont = True
        Me.TETemplateCode.Size = New System.Drawing.Size(229, 22)
        Me.TETemplateCode.TabIndex = 32
        Me.TETemplateCode.ToolTip = "Example : Code Sample Spring 14.  Max :  30 character."
        Me.TETemplateCode.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TETemplateCode.ToolTipTitle = "Information"
        '
        'LabelSeason
        '
        Me.LabelSeason.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSeason.Location = New System.Drawing.Point(152, 25)
        Me.LabelSeason.Name = "LabelSeason"
        Me.LabelSeason.Size = New System.Drawing.Size(31, 15)
        Me.LabelSeason.TabIndex = 35
        Me.LabelSeason.Text = "Name"
        '
        'FormTemplateCodeSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 105)
        Me.Controls.Add(Me.PictureSeason)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.TETemplateCode)
        Me.Controls.Add(Me.LabelSeason)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormTemplateCodeSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Template Code"
        CType(Me.EPTemplateCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TETemplateCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EPTemplateCode As System.Windows.Forms.ErrorProvider
    Friend WithEvents PictureSeason As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TETemplateCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelSeason As DevExpress.XtraEditors.LabelControl
End Class
