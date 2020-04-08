<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterEmployeeNomorSurat
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
        Me.TENumber = New DevExpress.XtraEditors.TextEdit()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TENumber
        '
        Me.TENumber.Location = New System.Drawing.Point(12, 12)
        Me.TENumber.Name = "TENumber"
        Me.TENumber.Size = New System.Drawing.Size(227, 20)
        Me.TENumber.TabIndex = 0
        '
        'BPrint
        '
        Me.BPrint.Location = New System.Drawing.Point(245, 10)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(114, 23)
        Me.BPrint.TabIndex = 1
        Me.BPrint.Text = "Print"
        '
        'FormMasterEmployeeNomorSurat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 41)
        Me.Controls.Add(Me.BPrint)
        Me.Controls.Add(Me.TENumber)
        Me.Name = "FormMasterEmployeeNomorSurat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nomor Surat"
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TENumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
End Class
