<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterItemSizeSingle
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
        Me.TxtCodeSize = New DevExpress.XtraEditors.TextEdit
        Me.LabelCodeItemSize = New DevExpress.XtraEditors.LabelControl
        Me.btnCancelItemSize = New DevExpress.XtraEditors.SimpleButton
        Me.btnSaveItemSize = New DevExpress.XtraEditors.SimpleButton
        Me.MemoDescription = New DevExpress.XtraEditors.MemoEdit
        Me.LabelDescriptionItemSize = New DevExpress.XtraEditors.LabelControl
        Me.TxtItemSize = New DevExpress.XtraEditors.TextEdit
        Me.LabelItemSize = New DevExpress.XtraEditors.LabelControl
        Me.ErrorProviderItemSize = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.TxtCodeSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtItemSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderItemSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtCodeSize
        '
        Me.TxtCodeSize.Location = New System.Drawing.Point(18, 40)
        Me.TxtCodeSize.Name = "TxtCodeSize"
        Me.TxtCodeSize.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodeSize.Properties.Appearance.Options.UseFont = True
        Me.TxtCodeSize.Size = New System.Drawing.Size(314, 22)
        Me.TxtCodeSize.TabIndex = 7
        Me.TxtCodeSize.ToolTip = "Max : 10 character"
        Me.TxtCodeSize.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TxtCodeSize.ToolTipTitle = "Information"
        '
        'LabelCodeItemSize
        '
        Me.LabelCodeItemSize.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCodeItemSize.Location = New System.Drawing.Point(18, 19)
        Me.LabelCodeItemSize.Name = "LabelCodeItemSize"
        Me.LabelCodeItemSize.Size = New System.Drawing.Size(51, 15)
        Me.LabelCodeItemSize.TabIndex = 13
        Me.LabelCodeItemSize.Text = "Code Size"
        '
        'btnCancelItemSize
        '
        Me.btnCancelItemSize.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelItemSize.Appearance.Options.UseFont = True
        Me.btnCancelItemSize.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelItemSize.Location = New System.Drawing.Point(152, 268)
        Me.btnCancelItemSize.Name = "btnCancelItemSize"
        Me.btnCancelItemSize.Size = New System.Drawing.Size(87, 27)
        Me.btnCancelItemSize.TabIndex = 12
        Me.btnCancelItemSize.Text = "Cancel"
        '
        'btnSaveItemSize
        '
        Me.btnSaveItemSize.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveItemSize.Appearance.Options.UseFont = True
        Me.btnSaveItemSize.Location = New System.Drawing.Point(245, 268)
        Me.btnSaveItemSize.Name = "btnSaveItemSize"
        Me.btnSaveItemSize.Size = New System.Drawing.Size(87, 27)
        Me.btnSaveItemSize.TabIndex = 11
        Me.btnSaveItemSize.Text = "Save"
        '
        'MemoDescription
        '
        Me.MemoDescription.Location = New System.Drawing.Point(18, 153)
        Me.MemoDescription.Name = "MemoDescription"
        Me.MemoDescription.Size = New System.Drawing.Size(314, 83)
        Me.MemoDescription.TabIndex = 10
        Me.MemoDescription.ToolTip = "Max : 100 character"
        Me.MemoDescription.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.MemoDescription.ToolTipTitle = "Information"
        '
        'LabelDescriptionItemSize
        '
        Me.LabelDescriptionItemSize.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDescriptionItemSize.Location = New System.Drawing.Point(18, 132)
        Me.LabelDescriptionItemSize.Name = "LabelDescriptionItemSize"
        Me.LabelDescriptionItemSize.Size = New System.Drawing.Size(124, 15)
        Me.LabelDescriptionItemSize.TabIndex = 8
        Me.LabelDescriptionItemSize.Text = "Description (Optional)"
        '
        'TxtItemSize
        '
        Me.TxtItemSize.Location = New System.Drawing.Point(18, 93)
        Me.TxtItemSize.Name = "TxtItemSize"
        Me.TxtItemSize.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtItemSize.Properties.Appearance.Options.UseFont = True
        Me.TxtItemSize.Size = New System.Drawing.Size(314, 22)
        Me.TxtItemSize.TabIndex = 9
        Me.TxtItemSize.ToolTip = "Max : 50 character"
        Me.TxtItemSize.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TxtItemSize.ToolTipTitle = "Information"
        '
        'LabelItemSize
        '
        Me.LabelItemSize.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelItemSize.Location = New System.Drawing.Point(18, 69)
        Me.LabelItemSize.Name = "LabelItemSize"
        Me.LabelItemSize.Size = New System.Drawing.Size(48, 15)
        Me.LabelItemSize.TabIndex = 6
        Me.LabelItemSize.Text = "Item Size"
        '
        'ErrorProviderItemSize
        '
        Me.ErrorProviderItemSize.ContainerControl = Me
        '
        'FormMasterItemSizeSingle
        '
        Me.AcceptButton = Me.btnSaveItemSize
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelItemSize
        Me.ClientSize = New System.Drawing.Size(363, 320)
        Me.Controls.Add(Me.TxtCodeSize)
        Me.Controls.Add(Me.LabelCodeItemSize)
        Me.Controls.Add(Me.btnCancelItemSize)
        Me.Controls.Add(Me.btnSaveItemSize)
        Me.Controls.Add(Me.MemoDescription)
        Me.Controls.Add(Me.LabelDescriptionItemSize)
        Me.Controls.Add(Me.TxtItemSize)
        Me.Controls.Add(Me.LabelItemSize)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterItemSizeSingle"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Item Size"
        CType(Me.TxtCodeSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtItemSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderItemSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtCodeSize As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelCodeItemSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCancelItemSize As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSaveItemSize As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents MemoDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelDescriptionItemSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtItemSize As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelItemSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ErrorProviderItemSize As System.Windows.Forms.ErrorProvider
End Class
