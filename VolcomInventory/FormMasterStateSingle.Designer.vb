<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterStateSingle
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
        Me.components = New System.ComponentModel.Container
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BSave = New DevExpress.XtraEditors.SimpleButton
        Me.TEState = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.EPState = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.TEState.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EPState, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(161, 69)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(86, 20)
        Me.BCancel.TabIndex = 14
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(253, 69)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(86, 20)
        Me.BSave.TabIndex = 13
        Me.BSave.Text = "Save"
        '
        'TEState
        '
        Me.TEState.Location = New System.Drawing.Point(15, 37)
        Me.TEState.Name = "TEState"
        Me.TEState.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TEState.Properties.Appearance.Options.UseFont = True
        Me.TEState.Size = New System.Drawing.Size(324, 23)
        Me.TEState.TabIndex = 12
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl1.Location = New System.Drawing.Point(15, 13)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(27, 15)
        Me.LabelControl1.TabIndex = 11
        Me.LabelControl1.Text = "State"
        '
        'EPState
        '
        Me.EPState.ContainerControl = Me
        '
        'FormMasterStateSingle
        '
        Me.AcceptButton = Me.BSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BCancel
        Me.ClientSize = New System.Drawing.Size(354, 102)
        Me.ControlBox = False
        Me.Controls.Add(Me.BCancel)
        Me.Controls.Add(Me.BSave)
        Me.Controls.Add(Me.TEState)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormMasterStateSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "State"
        CType(Me.TEState.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EPState, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEState As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents EPState As System.Windows.Forms.ErrorProvider
End Class
