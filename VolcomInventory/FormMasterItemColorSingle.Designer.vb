<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterItemColorSingle
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
        Me.TxtCodeItemColor = New DevExpress.XtraEditors.TextEdit
        Me.LabelCodeItemColor = New DevExpress.XtraEditors.LabelControl
        Me.btnCancelItemColor = New DevExpress.XtraEditors.SimpleButton
        Me.btnSaveItemColor = New DevExpress.XtraEditors.SimpleButton
        Me.MemoDescription = New DevExpress.XtraEditors.MemoEdit
        Me.LabelDescriptionItemColor = New DevExpress.XtraEditors.LabelControl
        Me.TxtItemColor = New DevExpress.XtraEditors.TextEdit
        Me.LabelItemColor = New DevExpress.XtraEditors.LabelControl
        Me.ErrorProviderColor = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.TxtCodeItemColor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtItemColor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtCodeItemColor
        '
        Me.TxtCodeItemColor.Location = New System.Drawing.Point(18, 34)
        Me.TxtCodeItemColor.Name = "TxtCodeItemColor"
        Me.TxtCodeItemColor.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodeItemColor.Properties.Appearance.Options.UseFont = True
        Me.TxtCodeItemColor.Size = New System.Drawing.Size(314, 22)
        Me.TxtCodeItemColor.TabIndex = 15
        Me.TxtCodeItemColor.ToolTip = "Max : 10 character"
        Me.TxtCodeItemColor.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TxtCodeItemColor.ToolTipTitle = "Information"
        '
        'LabelCodeItemColor
        '
        Me.LabelCodeItemColor.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCodeItemColor.Location = New System.Drawing.Point(18, 13)
        Me.LabelCodeItemColor.Name = "LabelCodeItemColor"
        Me.LabelCodeItemColor.Size = New System.Drawing.Size(60, 15)
        Me.LabelCodeItemColor.TabIndex = 21
        Me.LabelCodeItemColor.Text = "Code Color"
        '
        'btnCancelItemColor
        '
        Me.btnCancelItemColor.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelItemColor.Appearance.Options.UseFont = True
        Me.btnCancelItemColor.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelItemColor.Location = New System.Drawing.Point(152, 262)
        Me.btnCancelItemColor.Name = "btnCancelItemColor"
        Me.btnCancelItemColor.Size = New System.Drawing.Size(87, 27)
        Me.btnCancelItemColor.TabIndex = 20
        Me.btnCancelItemColor.Text = "Cancel"
        '
        'btnSaveItemColor
        '
        Me.btnSaveItemColor.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveItemColor.Appearance.Options.UseFont = True
        Me.btnSaveItemColor.Location = New System.Drawing.Point(245, 262)
        Me.btnSaveItemColor.Name = "btnSaveItemColor"
        Me.btnSaveItemColor.Size = New System.Drawing.Size(87, 27)
        Me.btnSaveItemColor.TabIndex = 19
        Me.btnSaveItemColor.Text = "Save"
        '
        'MemoDescription
        '
        Me.MemoDescription.Location = New System.Drawing.Point(18, 147)
        Me.MemoDescription.Name = "MemoDescription"
        Me.MemoDescription.Size = New System.Drawing.Size(314, 83)
        Me.MemoDescription.TabIndex = 18
        Me.MemoDescription.ToolTip = "Max : 100 character"
        Me.MemoDescription.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.MemoDescription.ToolTipTitle = "Information"
        '
        'LabelDescriptionItemColor
        '
        Me.LabelDescriptionItemColor.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDescriptionItemColor.Location = New System.Drawing.Point(18, 126)
        Me.LabelDescriptionItemColor.Name = "LabelDescriptionItemColor"
        Me.LabelDescriptionItemColor.Size = New System.Drawing.Size(124, 15)
        Me.LabelDescriptionItemColor.TabIndex = 16
        Me.LabelDescriptionItemColor.Text = "Description (Optional)"
        '
        'TxtItemColor
        '
        Me.TxtItemColor.Location = New System.Drawing.Point(18, 87)
        Me.TxtItemColor.Name = "TxtItemColor"
        Me.TxtItemColor.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtItemColor.Properties.Appearance.Options.UseFont = True
        Me.TxtItemColor.Size = New System.Drawing.Size(314, 22)
        Me.TxtItemColor.TabIndex = 17
        Me.TxtItemColor.ToolTip = "Max : 50 character"
        Me.TxtItemColor.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TxtItemColor.ToolTipTitle = "Information"
        '
        'LabelItemColor
        '
        Me.LabelItemColor.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelItemColor.Location = New System.Drawing.Point(18, 63)
        Me.LabelItemColor.Name = "LabelItemColor"
        Me.LabelItemColor.Size = New System.Drawing.Size(57, 15)
        Me.LabelItemColor.TabIndex = 14
        Me.LabelItemColor.Text = "Item Color"
        '
        'ErrorProviderColor
        '
        Me.ErrorProviderColor.ContainerControl = Me
        '
        'FormMasterItemColorSingle
        '
        Me.AcceptButton = Me.btnSaveItemColor
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelItemColor
        Me.ClientSize = New System.Drawing.Size(366, 308)
        Me.Controls.Add(Me.TxtCodeItemColor)
        Me.Controls.Add(Me.LabelCodeItemColor)
        Me.Controls.Add(Me.btnCancelItemColor)
        Me.Controls.Add(Me.btnSaveItemColor)
        Me.Controls.Add(Me.MemoDescription)
        Me.Controls.Add(Me.LabelDescriptionItemColor)
        Me.Controls.Add(Me.TxtItemColor)
        Me.Controls.Add(Me.LabelItemColor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterItemColorSingle"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormMasterItemColorSingle"
        CType(Me.TxtCodeItemColor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtItemColor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtCodeItemColor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelCodeItemColor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCancelItemColor As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSaveItemColor As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents MemoDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelDescriptionItemColor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtItemColor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelItemColor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ErrorProviderColor As System.Windows.Forms.ErrorProvider
End Class
