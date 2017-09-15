<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSUMockMark
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
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TEReportMarkType = New DevExpress.XtraEditors.TextEdit()
        Me.TEIdReport = New DevExpress.XtraEditors.TextEdit()
        Me.BProcess = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TEReportMarkType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEIdReport.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 38)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Id Report"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Report Mark Type"
        '
        'TEReportMarkType
        '
        Me.TEReportMarkType.Location = New System.Drawing.Point(104, 9)
        Me.TEReportMarkType.Name = "TEReportMarkType"
        Me.TEReportMarkType.Size = New System.Drawing.Size(173, 20)
        Me.TEReportMarkType.TabIndex = 2
        '
        'TEIdReport
        '
        Me.TEIdReport.Location = New System.Drawing.Point(104, 35)
        Me.TEIdReport.Name = "TEIdReport"
        Me.TEIdReport.Size = New System.Drawing.Size(173, 20)
        Me.TEIdReport.TabIndex = 3
        '
        'BProcess
        '
        Me.BProcess.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BProcess.Location = New System.Drawing.Point(0, 69)
        Me.BProcess.Name = "BProcess"
        Me.BProcess.Size = New System.Drawing.Size(289, 23)
        Me.BProcess.TabIndex = 4
        Me.BProcess.Text = "Go"
        '
        'FormSUMockMark
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 92)
        Me.Controls.Add(Me.BProcess)
        Me.Controls.Add(Me.TEIdReport)
        Me.Controls.Add(Me.TEReportMarkType)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSUMockMark"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mock Mark"
        CType(Me.TEReportMarkType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEIdReport.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEReportMarkType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEIdReport As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BProcess As DevExpress.XtraEditors.SimpleButton
End Class
