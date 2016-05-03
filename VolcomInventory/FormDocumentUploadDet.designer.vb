<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDocumentUploadDet
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
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BUpload = New DevExpress.XtraEditors.SimpleButton
        Me.BUploadFile = New DevExpress.XtraEditors.ButtonEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.TEFileName = New DevExpress.XtraEditors.TextEdit
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.BUploadFile.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEFileName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BCancel)
        Me.PanelControl2.Controls.Add(Me.BUpload)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 82)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(558, 32)
        Me.PanelControl2.TabIndex = 2
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.Location = New System.Drawing.Point(406, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(75, 28)
        Me.BCancel.TabIndex = 4
        Me.BCancel.Text = "Cancel"
        '
        'BUpload
        '
        Me.BUpload.Dock = System.Windows.Forms.DockStyle.Right
        Me.BUpload.Location = New System.Drawing.Point(481, 2)
        Me.BUpload.Name = "BUpload"
        Me.BUpload.Size = New System.Drawing.Size(75, 28)
        Me.BUpload.TabIndex = 3
        Me.BUpload.Text = "Upload"
        '
        'BUploadFile
        '
        Me.BUploadFile.Location = New System.Drawing.Point(101, 19)
        Me.BUploadFile.Name = "BUploadFile"
        Me.BUploadFile.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.BUploadFile.Properties.ReadOnly = True
        Me.BUploadFile.Size = New System.Drawing.Size(445, 20)
        Me.BUploadFile.TabIndex = 3
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 22)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "File "
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 48)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(72, 13)
        Me.LabelControl2.TabIndex = 5
        Me.LabelControl2.Text = "File Description"
        '
        'TEFileName
        '
        Me.TEFileName.Location = New System.Drawing.Point(101, 45)
        Me.TEFileName.Name = "TEFileName"
        Me.TEFileName.Size = New System.Drawing.Size(445, 20)
        Me.TEFileName.TabIndex = 6
        '
        'FormDocumentUploadDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 114)
        Me.Controls.Add(Me.TEFileName)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.BUploadFile)
        Me.Controls.Add(Me.PanelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormDocumentUploadDet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Upload File"
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.BUploadFile.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEFileName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BUpload As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BUploadFile As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEFileName As DevExpress.XtraEditors.TextEdit
End Class
