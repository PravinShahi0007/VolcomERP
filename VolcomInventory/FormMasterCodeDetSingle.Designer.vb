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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.PCAction = New DevExpress.XtraEditors.PanelControl()
        Me.PCValue = New DevExpress.XtraEditors.PanelControl()
        CType(Me.TECode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPrintedCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECodeDet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderCodeDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.PCAction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCAction.SuspendLayout()
        CType(Me.PCValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCValue.SuspendLayout()
        Me.SuspendLayout()
        '
        'TECode
        '
        Me.TECode.Location = New System.Drawing.Point(165, 12)
        Me.TECode.Name = "TECode"
        Me.TECode.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TECode.Properties.Appearance.Options.UseFont = True
        Me.TECode.Size = New System.Drawing.Size(230, 22)
        Me.TECode.TabIndex = 35
        Me.TECode.ToolTip = "Example : 01"
        Me.TECode.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TECode.ToolTipTitle = "Information"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(11, 14)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(11, 15)
        Me.LabelControl2.TabIndex = 41
        Me.LabelControl2.Text = "Id"
        '
        'TEPrintedCode
        '
        Me.TEPrintedCode.Location = New System.Drawing.Point(165, 4)
        Me.TEPrintedCode.Name = "TEPrintedCode"
        Me.TEPrintedCode.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEPrintedCode.Properties.Appearance.Options.UseFont = True
        Me.TEPrintedCode.Size = New System.Drawing.Size(230, 22)
        Me.TEPrintedCode.TabIndex = 34
        Me.TEPrintedCode.ToolTip = "Example : BLK."
        Me.TEPrintedCode.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TEPrintedCode.ToolTipTitle = "Information"
        '
        'PictureSeason
        '
        Me.PictureSeason.EditValue = CType(resources.GetObject("PictureSeason.EditValue"), Object)
        Me.PictureSeason.Location = New System.Drawing.Point(12, 12)
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
        Me.BtnCancel.Location = New System.Drawing.Point(241, 5)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 37
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(322, 5)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 36
        Me.BtnSave.Text = "Save"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(11, 5)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(102, 15)
        Me.LabelControl1.TabIndex = 39
        Me.LabelControl1.Text = "Printed in Barcode"
        '
        'TECodeDet
        '
        Me.TECodeDet.Location = New System.Drawing.Point(165, 4)
        Me.TECodeDet.Name = "TECodeDet"
        Me.TECodeDet.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TECodeDet.Properties.Appearance.Options.UseFont = True
        Me.TECodeDet.Size = New System.Drawing.Size(230, 22)
        Me.TECodeDet.TabIndex = 33
        Me.TECodeDet.ToolTip = "Example : Black"
        Me.TECodeDet.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TECodeDet.ToolTipTitle = "Information"
        '
        'LabelSeason
        '
        Me.LabelSeason.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSeason.Location = New System.Drawing.Point(11, 5)
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
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.PictureSeason)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(132, 141)
        Me.PanelControl1.TabIndex = 42
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.TECode)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(417, 40)
        Me.PanelControl2.TabIndex = 43
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.TEPrintedCode)
        Me.PanelControl3.Controls.Add(Me.LabelControl1)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(2, 42)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(417, 30)
        Me.PanelControl3.TabIndex = 44
        '
        'PanelControl4
        '
        Me.PanelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl4.Controls.Add(Me.TECodeDet)
        Me.PanelControl4.Controls.Add(Me.LabelSeason)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl4.Location = New System.Drawing.Point(2, 72)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(417, 30)
        Me.PanelControl4.TabIndex = 45
        '
        'PCAction
        '
        Me.PCAction.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCAction.Controls.Add(Me.BtnSave)
        Me.PCAction.Controls.Add(Me.BtnCancel)
        Me.PCAction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PCAction.Location = New System.Drawing.Point(132, 105)
        Me.PCAction.Name = "PCAction"
        Me.PCAction.Size = New System.Drawing.Size(421, 36)
        Me.PCAction.TabIndex = 46
        '
        'PCValue
        '
        Me.PCValue.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCValue.Controls.Add(Me.PanelControl4)
        Me.PCValue.Controls.Add(Me.PanelControl3)
        Me.PCValue.Controls.Add(Me.PanelControl2)
        Me.PCValue.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCValue.Location = New System.Drawing.Point(132, 0)
        Me.PCValue.Name = "PCValue"
        Me.PCValue.Size = New System.Drawing.Size(421, 105)
        Me.PCValue.TabIndex = 47
        '
        'FormMasterCodeDetSingle
        '
        Me.AcceptButton = Me.BtnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(553, 141)
        Me.Controls.Add(Me.PCAction)
        Me.Controls.Add(Me.PCValue)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterCodeDetSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Code"
        CType(Me.TECode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPrintedCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECodeDet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderCodeDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.PanelControl4.PerformLayout()
        CType(Me.PCAction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCAction.ResumeLayout(False)
        CType(Me.PCValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCValue.ResumeLayout(False)
        Me.ResumeLayout(False)

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
    Friend WithEvents PCAction As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PCValue As DevExpress.XtraEditors.PanelControl
End Class
