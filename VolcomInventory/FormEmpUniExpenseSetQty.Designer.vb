<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpUniExpenseSetQty
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
        Me.BtnSetQty = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtQty = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.TxtQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnSetQty
        '
        Me.BtnSetQty.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnSetQty.Location = New System.Drawing.Point(0, 54)
        Me.BtnSetQty.Name = "BtnSetQty"
        Me.BtnSetQty.Size = New System.Drawing.Size(284, 23)
        Me.BtnSetQty.TabIndex = 0
        Me.BtnSetQty.Text = "Set Qty"
        '
        'TxtQty
        '
        Me.TxtQty.Location = New System.Drawing.Point(55, 12)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Properties.Mask.EditMask = "N0"
        Me.TxtQty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtQty.Size = New System.Drawing.Size(203, 20)
        Me.TxtQty.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(22, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Qty"
        '
        'FormEmpUniExpenseSetQty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 77)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.TxtQty)
        Me.Controls.Add(Me.BtnSetQty)
        Me.Name = "FormEmpUniExpenseSetQty"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Set Qty"
        CType(Me.TxtQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnSetQty As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtQty As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
