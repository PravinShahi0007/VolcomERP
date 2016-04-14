<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pivot
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
        Me.PGC = New DevExpress.XtraPivotGrid.PivotGridControl
        CType(Me.PGC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PGC
        '
        Me.PGC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PGC.Location = New System.Drawing.Point(0, 0)
        Me.PGC.Name = "PGC"
        Me.PGC.Size = New System.Drawing.Size(762, 354)
        Me.PGC.TabIndex = 0
        '
        'Pivot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(762, 354)
        Me.Controls.Add(Me.PGC)
        Me.Name = "Pivot"
        Me.Text = "Pivot"
        CType(Me.PGC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PGC As DevExpress.XtraPivotGrid.PivotGridControl
End Class
