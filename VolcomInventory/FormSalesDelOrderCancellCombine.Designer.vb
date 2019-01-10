<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesDelOrderCancellCombine
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelCombineNumber = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnConfirm = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelCombineNumber)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(801, 43)
        Me.PanelControl1.TabIndex = 0
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BtnDiscard)
        Me.PanelControl2.Controls.Add(Me.BtnConfirm)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 386)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(801, 51)
        Me.PanelControl2.TabIndex = 2
        '
        'LabelCombineNumber
        '
        Me.LabelCombineNumber.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCombineNumber.Location = New System.Drawing.Point(14, 12)
        Me.LabelCombineNumber.Name = "LabelCombineNumber"
        Me.LabelCombineNumber.Size = New System.Drawing.Size(167, 19)
        Me.LabelCombineNumber.TabIndex = 3
        Me.LabelCombineNumber.Text = "[COMBINE NUMBER]"
        '
        'PanelControl3
        '
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 286)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(801, 100)
        Me.PanelControl3.TabIndex = 3
        '
        'BtnConfirm
        '
        Me.BtnConfirm.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnConfirm.Location = New System.Drawing.Point(724, 2)
        Me.BtnConfirm.Name = "BtnConfirm"
        Me.BtnConfirm.Size = New System.Drawing.Size(75, 47)
        Me.BtnConfirm.TabIndex = 0
        Me.BtnConfirm.Text = "SimpleButton1"
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDiscard.Location = New System.Drawing.Point(649, 2)
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(75, 47)
        Me.BtnDiscard.TabIndex = 1
        Me.BtnDiscard.Text = "Discard"
        '
        'FormSalesDelOrderCancellCombine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 437)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormSalesDelOrderCancellCombine"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancell Combine"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelCombineNumber As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnConfirm As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
End Class
