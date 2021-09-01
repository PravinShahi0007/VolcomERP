<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStockTakeStoreEditPromo
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
        Me.TEPrice = New DevExpress.XtraEditors.TextEdit()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TEPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TEPrice
        '
        Me.TEPrice.Location = New System.Drawing.Point(12, 12)
        Me.TEPrice.Name = "TEPrice"
        Me.TEPrice.Properties.DisplayFormat.FormatString = "N0"
        Me.TEPrice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEPrice.Properties.EditFormat.FormatString = "N0"
        Me.TEPrice.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEPrice.Properties.Mask.EditMask = "N0"
        Me.TEPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEPrice.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEPrice.Size = New System.Drawing.Size(200, 20)
        Me.TEPrice.TabIndex = 0
        '
        'SBSave
        '
        Me.SBSave.Location = New System.Drawing.Point(218, 10)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(54, 23)
        Me.SBSave.TabIndex = 1
        Me.SBSave.Text = "Save"
        '
        'FormStockTakeStoreEditPromo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 45)
        Me.Controls.Add(Me.SBSave)
        Me.Controls.Add(Me.TEPrice)
        Me.Name = "FormStockTakeStoreEditPromo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Promo Price"
        CType(Me.TEPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TEPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
End Class
