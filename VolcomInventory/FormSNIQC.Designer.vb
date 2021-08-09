<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSNIQC
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
        Me.XTCInOut = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPOut = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPIn = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.XTCInOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCInOut.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCInOut
        '
        Me.XTCInOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCInOut.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCInOut.Location = New System.Drawing.Point(0, 0)
        Me.XTCInOut.Name = "XTCInOut"
        Me.XTCInOut.SelectedTabPage = Me.XTPOut
        Me.XTCInOut.Size = New System.Drawing.Size(921, 481)
        Me.XTCInOut.TabIndex = 0
        Me.XTCInOut.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPOut, Me.XTPIn})
        '
        'XTPOut
        '
        Me.XTPOut.Name = "XTPOut"
        Me.XTPOut.Size = New System.Drawing.Size(915, 453)
        Me.XTPOut.Text = "SNI Out"
        '
        'XTPIn
        '
        Me.XTPIn.Name = "XTPIn"
        Me.XTPIn.Size = New System.Drawing.Size(294, 272)
        Me.XTPIn.Text = "SNI In"
        '
        'FormSNIQC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(921, 481)
        Me.Controls.Add(Me.XTCInOut)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSNIQC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SNI QC"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.XTCInOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCInOut.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCInOut As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPOut As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPIn As DevExpress.XtraTab.XtraTabPage
End Class
