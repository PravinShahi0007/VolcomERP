<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmployeePpsProgress
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
        Me.ProgressBarControl = New DevExpress.XtraEditors.ProgressBarControl()
        Me.LabelControl = New DevExpress.XtraEditors.LabelControl()
        CType(Me.ProgressBarControl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProgressBarControl
        '
        Me.ProgressBarControl.Location = New System.Drawing.Point(12, 12)
        Me.ProgressBarControl.Name = "ProgressBarControl"
        Me.ProgressBarControl.Properties.Step = 1
        Me.ProgressBarControl.Size = New System.Drawing.Size(424, 30)
        Me.ProgressBarControl.TabIndex = 0
        '
        'LabelControl
        '
        Me.LabelControl.Location = New System.Drawing.Point(12, 48)
        Me.LabelControl.Name = "LabelControl"
        Me.LabelControl.Size = New System.Drawing.Size(140, 13)
        Me.LabelControl.TabIndex = 1
        Me.LabelControl.Text = "Updating master employee..."
        '
        'FormEmployeePpsProgress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 69)
        Me.Controls.Add(Me.LabelControl)
        Me.Controls.Add(Me.ProgressBarControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmployeePpsProgress"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormEmployeePpsProgress"
        CType(Me.ProgressBarControl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProgressBarControl As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents LabelControl As DevExpress.XtraEditors.LabelControl
End Class
