<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterCitySingle
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
        Me.TECity = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.EPCity = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.TECity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EPCity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(161, 69)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(86, 20)
        Me.BCancel.TabIndex = 18
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(253, 69)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(86, 20)
        Me.BSave.TabIndex = 17
        Me.BSave.Text = "Save"
        '
        'TECity
        '
        Me.TECity.Location = New System.Drawing.Point(15, 37)
        Me.TECity.Name = "TECity"
        Me.TECity.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TECity.Properties.Appearance.Options.UseFont = True
        Me.TECity.Size = New System.Drawing.Size(324, 23)
        Me.TECity.TabIndex = 16
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl1.Location = New System.Drawing.Point(15, 13)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(21, 15)
        Me.LabelControl1.TabIndex = 15
        Me.LabelControl1.Text = "City"
        '
        'EPCity
        '
        Me.EPCity.ContainerControl = Me
        '
        'FormMasterCitySingle
        '
        Me.AcceptButton = Me.BSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BCancel
        Me.ClientSize = New System.Drawing.Size(354, 102)
        Me.ControlBox = False
        Me.Controls.Add(Me.BCancel)
        Me.Controls.Add(Me.BSave)
        Me.Controls.Add(Me.TECity)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormMasterCitySingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "City"
        CType(Me.TECity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EPCity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TECity As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents EPCity As System.Windows.Forms.ErrorProvider
End Class
