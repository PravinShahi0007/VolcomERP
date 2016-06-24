<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSendMessage
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
        Me.BSendMessage = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.TEEmailTo = New DevExpress.XtraEditors.TextEdit()
        Me.TESubject = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.MEBody = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.TEEmailTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TESubject.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEBody.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BSendMessage
        '
        Me.BSendMessage.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BSendMessage.Location = New System.Drawing.Point(0, 270)
        Me.BSendMessage.Name = "BSendMessage"
        Me.BSendMessage.Size = New System.Drawing.Size(593, 23)
        Me.BSendMessage.TabIndex = 16
        Me.BSendMessage.Text = "Send Message"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.TESubject)
        Me.PanelControl1.Controls.Add(Me.TEEmailTo)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(593, 70)
        Me.PanelControl1.TabIndex = 17
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.MEBody)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl3.Location = New System.Drawing.Point(0, 70)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(593, 200)
        Me.PanelControl3.TabIndex = 19
        '
        'TEEmailTo
        '
        Me.TEEmailTo.Location = New System.Drawing.Point(57, 12)
        Me.TEEmailTo.Name = "TEEmailTo"
        Me.TEEmailTo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.TEEmailTo.Properties.Appearance.Options.UseFont = True
        Me.TEEmailTo.Size = New System.Drawing.Size(524, 22)
        Me.TEEmailTo.TabIndex = 2
        '
        'TESubject
        '
        Me.TESubject.Location = New System.Drawing.Point(57, 40)
        Me.TESubject.Name = "TESubject"
        Me.TESubject.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.TESubject.Properties.Appearance.Options.UseFont = True
        Me.TESubject.Size = New System.Drawing.Size(524, 22)
        Me.TESubject.TabIndex = 3
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "Send To"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 45)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl2.TabIndex = 5
        Me.LabelControl2.Text = "Subject"
        '
        'MEBody
        '
        Me.MEBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MEBody.Location = New System.Drawing.Point(2, 2)
        Me.MEBody.Name = "MEBody"
        Me.MEBody.Size = New System.Drawing.Size(589, 196)
        Me.MEBody.TabIndex = 0
        '
        'FormSendMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 293)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.BSendMessage)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSendMessage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Send Message"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.TEEmailTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TESubject.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEBody.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BSendMessage As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TESubject As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEEmailTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents MEBody As DevExpress.XtraEditors.MemoEdit
End Class
