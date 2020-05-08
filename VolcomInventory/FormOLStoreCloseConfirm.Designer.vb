<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOLStoreCloseConfirm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOLStoreCloseConfirm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MemoEditReason = New DevExpress.XtraEditors.MemoEdit()
        Me.SBConfirm = New DevExpress.XtraEditors.SimpleButton()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.MemoEditReason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Reason"
        '
        'MemoEditReason
        '
        Me.MemoEditReason.Location = New System.Drawing.Point(12, 34)
        Me.MemoEditReason.Name = "MemoEditReason"
        Me.MemoEditReason.Size = New System.Drawing.Size(260, 181)
        Me.MemoEditReason.TabIndex = 1
        '
        'SBConfirm
        '
        Me.SBConfirm.Image = CType(resources.GetObject("SBConfirm.Image"), System.Drawing.Image)
        Me.SBConfirm.Location = New System.Drawing.Point(197, 221)
        Me.SBConfirm.Name = "SBConfirm"
        Me.SBConfirm.Size = New System.Drawing.Size(75, 23)
        Me.SBConfirm.TabIndex = 2
        Me.SBConfirm.Text = "Confirm"
        '
        'SBClose
        '
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(116, 221)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(75, 23)
        Me.SBClose.TabIndex = 3
        Me.SBClose.Text = "Close"
        '
        'FormOLStoreCloseConfirm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 255)
        Me.Controls.Add(Me.SBClose)
        Me.Controls.Add(Me.SBConfirm)
        Me.Controls.Add(Me.MemoEditReason)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormOLStoreCloseConfirm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Confirm"
        CType(Me.MemoEditReason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents MemoEditReason As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents SBConfirm As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
End Class
