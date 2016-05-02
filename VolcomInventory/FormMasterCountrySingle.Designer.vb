<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterCountrySingle
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
        Me.TECountry = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.EPCountry = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.TECountryDisplay = New DevExpress.XtraEditors.TextEdit
        CType(Me.TECountry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EPCountry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECountryDisplay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(161, 126)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(86, 20)
        Me.BCancel.TabIndex = 10
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(253, 126)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(86, 20)
        Me.BSave.TabIndex = 9
        Me.BSave.Text = "Save"
        '
        'TECountry
        '
        Me.TECountry.Location = New System.Drawing.Point(15, 37)
        Me.TECountry.Name = "TECountry"
        Me.TECountry.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TECountry.Properties.Appearance.Options.UseFont = True
        Me.TECountry.Size = New System.Drawing.Size(324, 23)
        Me.TECountry.TabIndex = 8
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl1.Location = New System.Drawing.Point(15, 13)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(43, 15)
        Me.LabelControl1.TabIndex = 7
        Me.LabelControl1.Text = "Country"
        '
        'EPCountry
        '
        Me.EPCountry.ContainerControl = Me
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl2.Location = New System.Drawing.Point(15, 66)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(75, 15)
        Me.LabelControl2.TabIndex = 11
        Me.LabelControl2.Text = "Display name"
        '
        'TECountryDisplay
        '
        Me.TECountryDisplay.Location = New System.Drawing.Point(15, 87)
        Me.TECountryDisplay.Name = "TECountryDisplay"
        Me.TECountryDisplay.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TECountryDisplay.Properties.Appearance.Options.UseFont = True
        Me.TECountryDisplay.Properties.MaxLength = 10
        Me.TECountryDisplay.Size = New System.Drawing.Size(324, 23)
        Me.TECountryDisplay.TabIndex = 12
        '
        'FormMasterCountrySingle
        '
        Me.AcceptButton = Me.BSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BCancel
        Me.ClientSize = New System.Drawing.Size(354, 158)
        Me.ControlBox = False
        Me.Controls.Add(Me.TECountryDisplay)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.BCancel)
        Me.Controls.Add(Me.BSave)
        Me.Controls.Add(Me.TECountry)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormMasterCountrySingle"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Country"
        CType(Me.TECountry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EPCountry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECountryDisplay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TECountry As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents EPCountry As System.Windows.Forms.ErrorProvider
    Friend WithEvents TECountryDisplay As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
End Class
