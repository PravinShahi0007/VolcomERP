<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterCodeDetSingle
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterCodeDetSingle))
        Me.TECode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TEPrintedCode = New DevExpress.XtraEditors.TextEdit()
        Me.PictureSeason = New DevExpress.XtraEditors.PictureEdit()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TECodeDet = New DevExpress.XtraEditors.TextEdit()
        Me.LabelSeason = New DevExpress.XtraEditors.LabelControl()
        Me.ErrorProviderCodeDet = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.TECode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPrintedCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECodeDet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderCodeDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TECode
        '
        Me.TECode.Location = New System.Drawing.Point(234, 76)
        Me.TECode.Name = "TECode"
        Me.TECode.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TECode.Properties.Appearance.Options.UseFont = True
        Me.TECode.Size = New System.Drawing.Size(229, 22)
        Me.TECode.TabIndex = 35
        Me.TECode.ToolTip = "Example : 01"
        Me.TECode.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TECode.ToolTipTitle = "Information"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(155, 79)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(27, 15)
        Me.LabelControl2.TabIndex = 41
        Me.LabelControl2.Text = "Code"
        '
        'TEPrintedCode
        '
        Me.TEPrintedCode.Location = New System.Drawing.Point(234, 48)
        Me.TEPrintedCode.Name = "TEPrintedCode"
        Me.TEPrintedCode.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEPrintedCode.Properties.Appearance.Options.UseFont = True
        Me.TEPrintedCode.Size = New System.Drawing.Size(229, 22)
        Me.TEPrintedCode.TabIndex = 34
        Me.TEPrintedCode.ToolTip = "Example : BLK."
        Me.TEPrintedCode.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TEPrintedCode.ToolTipTitle = "Information"
        '
        'PictureSeason
        '
        Me.PictureSeason.EditValue = CType(resources.GetObject("PictureSeason.EditValue"), Object)
        Me.PictureSeason.Location = New System.Drawing.Point(24, 14)
        Me.PictureSeason.Name = "PictureSeason"
        Me.PictureSeason.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureSeason.Properties.Appearance.Options.UseBackColor = True
        Me.PictureSeason.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureSeason.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureSeason.Size = New System.Drawing.Size(104, 113)
        Me.PictureSeason.TabIndex = 40
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(307, 104)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 37
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(388, 104)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 36
        Me.BtnSave.Text = "Save"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(155, 51)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(73, 15)
        Me.LabelControl1.TabIndex = 39
        Me.LabelControl1.Text = "Printed name"
        '
        'TECodeDet
        '
        Me.TECodeDet.Location = New System.Drawing.Point(234, 20)
        Me.TECodeDet.Name = "TECodeDet"
        Me.TECodeDet.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TECodeDet.Properties.Appearance.Options.UseFont = True
        Me.TECodeDet.Size = New System.Drawing.Size(229, 22)
        Me.TECodeDet.TabIndex = 33
        Me.TECodeDet.ToolTip = "Example : Black"
        Me.TECodeDet.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TECodeDet.ToolTipTitle = "Information"
        '
        'LabelSeason
        '
        Me.LabelSeason.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSeason.Location = New System.Drawing.Point(155, 23)
        Me.LabelSeason.Name = "LabelSeason"
        Me.LabelSeason.Size = New System.Drawing.Size(64, 15)
        Me.LabelSeason.TabIndex = 38
        Me.LabelSeason.Text = "Description"
        '
        'ErrorProviderCodeDet
        '
        Me.ErrorProviderCodeDet.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProviderCodeDet.ContainerControl = Me
        '
        'FormMasterCodeDetSingle
        '
        Me.AcceptButton = Me.BtnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(487, 141)
        Me.Controls.Add(Me.TECode)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TEPrintedCode)
        Me.Controls.Add(Me.PictureSeason)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.TECodeDet)
        Me.Controls.Add(Me.LabelSeason)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterCodeDetSingle"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Code"
        CType(Me.TECode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPrintedCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECodeDet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderCodeDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TECode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPrintedCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PictureSeason As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TECodeDet As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelSeason As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ErrorProviderCodeDet As System.Windows.Forms.ErrorProvider
End Class
