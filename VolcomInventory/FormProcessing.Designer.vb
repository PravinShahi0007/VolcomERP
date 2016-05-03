<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProcessing
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
        Me.LabelStatus = New DevExpress.XtraEditors.LabelControl
        Me.BtnStart = New DevExpress.XtraEditors.SimpleButton
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.PBProcess = New System.Windows.Forms.ProgressBar
        Me.LabelControlPrecentage = New DevExpress.XtraEditors.LabelControl
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelStatus
        '
        Me.LabelStatus.Location = New System.Drawing.Point(12, 12)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(77, 13)
        Me.LabelStatus.TabIndex = 1
        Me.LabelStatus.Text = "Processing Data"
        '
        'BtnStart
        '
        Me.BtnStart.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnStart.Location = New System.Drawing.Point(284, 2)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(75, 25)
        Me.BtnStart.TabIndex = 2
        Me.BtnStart.Text = "Start"
        Me.BtnStart.Visible = False
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(98, 50)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 3
        Me.BtnCancel.Text = "Close"
        Me.BtnCancel.Visible = False
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        '
        'PBProcess
        '
        Me.PBProcess.Location = New System.Drawing.Point(12, 29)
        Me.PBProcess.Name = "PBProcess"
        Me.PBProcess.Size = New System.Drawing.Size(333, 23)
        Me.PBProcess.TabIndex = 4
        '
        'LabelControlPrecentage
        '
        Me.LabelControlPrecentage.Location = New System.Drawing.Point(95, 12)
        Me.LabelControlPrecentage.Name = "LabelControlPrecentage"
        Me.LabelControlPrecentage.Size = New System.Drawing.Size(25, 13)
        Me.LabelControlPrecentage.TabIndex = 5
        Me.LabelControlPrecentage.Text = "(0%)"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnStart)
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 64)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(361, 29)
        Me.PanelControl1.TabIndex = 6
        '
        'FormProcessing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 93)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.LabelControlPrecentage)
        Me.Controls.Add(Me.PBProcess)
        Me.Controls.Add(Me.LabelStatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormProcessing"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Please Wait"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelStatus As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnStart As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents PBProcess As System.Windows.Forms.ProgressBar
    Friend WithEvents LabelControlPrecentage As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
End Class
