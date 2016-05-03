<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterCompanyCategorySingle
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
        Me.MECompanyCategoryDescription = New DevExpress.XtraEditors.MemoEdit
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.TECompanyCategory = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.EPCompanyCategory = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.MECompanyCategoryDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECompanyCategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EPCompanyCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(159, 220)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(86, 20)
        Me.BCancel.TabIndex = 10
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(251, 220)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(86, 20)
        Me.BSave.TabIndex = 9
        Me.BSave.Text = "Save"
        '
        'MECompanyCategoryDescription
        '
        Me.MECompanyCategoryDescription.Location = New System.Drawing.Point(13, 99)
        Me.MECompanyCategoryDescription.Name = "MECompanyCategoryDescription"
        Me.MECompanyCategoryDescription.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.MECompanyCategoryDescription.Properties.Appearance.Options.UseFont = True
        Me.MECompanyCategoryDescription.Size = New System.Drawing.Size(324, 104)
        Me.MECompanyCategoryDescription.TabIndex = 8
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl2.Location = New System.Drawing.Point(13, 75)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(124, 15)
        Me.LabelControl2.TabIndex = 7
        Me.LabelControl2.Text = "Description (Optional)"
        '
        'TECompanyCategory
        '
        Me.TECompanyCategory.Location = New System.Drawing.Point(13, 37)
        Me.TECompanyCategory.Name = "TECompanyCategory"
        Me.TECompanyCategory.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TECompanyCategory.Properties.Appearance.Options.UseFont = True
        Me.TECompanyCategory.Size = New System.Drawing.Size(324, 23)
        Me.TECompanyCategory.TabIndex = 6
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl1.Location = New System.Drawing.Point(13, 13)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(102, 15)
        Me.LabelControl1.TabIndex = 5
        Me.LabelControl1.Text = "Company Category"
        '
        'EPCompanyCategory
        '
        Me.EPCompanyCategory.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EPCompanyCategory.ContainerControl = Me
        '
        'FormMasterCompanyCategorySingle
        '
        Me.AcceptButton = Me.BSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BCancel
        Me.ClientSize = New System.Drawing.Size(350, 253)
        Me.Controls.Add(Me.BCancel)
        Me.Controls.Add(Me.BSave)
        Me.Controls.Add(Me.MECompanyCategoryDescription)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TECompanyCategory)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterCompanyCategorySingle"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Company Category"
        CType(Me.MECompanyCategoryDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECompanyCategory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EPCompanyCategory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents MECompanyCategoryDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TECompanyCategory As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents EPCompanyCategory As System.Windows.Forms.ErrorProvider
End Class
