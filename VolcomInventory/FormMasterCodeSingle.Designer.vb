<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterCodeSingle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterCodeSingle))
        Me.CEIncludeCode = New DevExpress.XtraEditors.CheckEdit
        Me.CEIsInclude = New DevExpress.XtraEditors.CheckEdit
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.MEDescription = New DevExpress.XtraEditors.MemoEdit
        Me.TECode = New DevExpress.XtraEditors.TextEdit
        Me.LabelSeason = New DevExpress.XtraEditors.LabelControl
        Me.PictureSeason = New DevExpress.XtraEditors.PictureEdit
        Me.ErrorProviderCode = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.CEIncludeCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEIsInclude.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CEIncludeCode
        '
        Me.CEIncludeCode.EditValue = True
        Me.CEIncludeCode.Location = New System.Drawing.Point(234, 124)
        Me.CEIncludeCode.Name = "CEIncludeCode"
        Me.CEIncludeCode.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.CEIncludeCode.Properties.Appearance.Options.UseFont = True
        Me.CEIncludeCode.Properties.Caption = "Include Code In Generate code"
        Me.CEIncludeCode.Size = New System.Drawing.Size(276, 20)
        Me.CEIncludeCode.TabIndex = 119
        '
        'CEIsInclude
        '
        Me.CEIsInclude.Location = New System.Drawing.Point(234, 150)
        Me.CEIsInclude.Name = "CEIsInclude"
        Me.CEIsInclude.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.CEIsInclude.Properties.Appearance.Options.UseFont = True
        Me.CEIsInclude.Properties.Caption = "Include Code Display Name In Generate name"
        Me.CEIsInclude.Size = New System.Drawing.Size(276, 20)
        Me.CEIsInclude.TabIndex = 118
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(354, 180)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 114
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(435, 180)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 113
        Me.BtnSave.Text = "Save"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(166, 56)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(64, 15)
        Me.LabelControl1.TabIndex = 117
        Me.LabelControl1.Text = "Description"
        '
        'MEDescription
        '
        Me.MEDescription.Location = New System.Drawing.Point(236, 53)
        Me.MEDescription.Name = "MEDescription"
        Me.MEDescription.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MEDescription.Properties.Appearance.Options.UseFont = True
        Me.MEDescription.Size = New System.Drawing.Size(274, 65)
        Me.MEDescription.TabIndex = 112
        '
        'TECode
        '
        Me.TECode.Location = New System.Drawing.Point(236, 25)
        Me.TECode.Name = "TECode"
        Me.TECode.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TECode.Properties.Appearance.Options.UseFont = True
        Me.TECode.Size = New System.Drawing.Size(274, 22)
        Me.TECode.TabIndex = 111
        Me.TECode.ToolTip = "Example : Size.  Max :  30 character."
        Me.TECode.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TECode.ToolTipTitle = "Information"
        '
        'LabelSeason
        '
        Me.LabelSeason.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSeason.Location = New System.Drawing.Point(166, 28)
        Me.LabelSeason.Name = "LabelSeason"
        Me.LabelSeason.Size = New System.Drawing.Size(31, 15)
        Me.LabelSeason.TabIndex = 116
        Me.LabelSeason.Text = "Name"
        '
        'PictureSeason
        '
        Me.PictureSeason.EditValue = CType(resources.GetObject("PictureSeason.EditValue"), Object)
        Me.PictureSeason.Location = New System.Drawing.Point(20, 14)
        Me.PictureSeason.Name = "PictureSeason"
        Me.PictureSeason.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureSeason.Properties.Appearance.Options.UseBackColor = True
        Me.PictureSeason.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureSeason.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureSeason.Size = New System.Drawing.Size(124, 113)
        Me.PictureSeason.TabIndex = 115
        '
        'ErrorProviderCode
        '
        Me.ErrorProviderCode.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProviderCode.ContainerControl = Me
        '
        'FormMasterCodeSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 217)
        Me.Controls.Add(Me.CEIncludeCode)
        Me.Controls.Add(Me.CEIsInclude)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.MEDescription)
        Me.Controls.Add(Me.TECode)
        Me.Controls.Add(Me.LabelSeason)
        Me.Controls.Add(Me.PictureSeason)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterCodeSingle"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Code"
        CType(Me.CEIncludeCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEIsInclude.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CEIncludeCode As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CEIsInclude As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TECode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelSeason As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureSeason As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents ErrorProviderCode As System.Windows.Forms.ErrorProvider
End Class
