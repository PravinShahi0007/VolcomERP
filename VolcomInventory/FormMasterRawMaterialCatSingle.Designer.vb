<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterRawMaterialCatSingle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterRawMaterialCatSingle))
        Me.LabelControlItemCategory = New DevExpress.XtraEditors.LabelControl
        Me.TextEditItemCategory = New DevExpress.XtraEditors.TextEdit
        Me.SimpleButtonItemCategoryDescription = New DevExpress.XtraEditors.SimpleButton
        Me.ErrorProviderMasterItemCategory = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.SimpleButtonMasterItemCategoryCancel = New DevExpress.XtraEditors.SimpleButton
        CType(Me.TextEditItemCategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderMasterItemCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControlItemCategory
        '
        Me.LabelControlItemCategory.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControlItemCategory.Location = New System.Drawing.Point(14, 13)
        Me.LabelControlItemCategory.Name = "LabelControlItemCategory"
        Me.LabelControlItemCategory.Size = New System.Drawing.Size(99, 15)
        Me.LabelControlItemCategory.TabIndex = 0
        Me.LabelControlItemCategory.Text = "Material Category"
        '
        'TextEditItemCategory
        '
        Me.TextEditItemCategory.Location = New System.Drawing.Point(14, 37)
        Me.TextEditItemCategory.Name = "TextEditItemCategory"
        Me.TextEditItemCategory.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEditItemCategory.Properties.Appearance.Options.UseFont = True
        Me.TextEditItemCategory.Size = New System.Drawing.Size(314, 22)
        Me.TextEditItemCategory.TabIndex = 0
        '
        'SimpleButtonItemCategoryDescription
        '
        Me.SimpleButtonItemCategoryDescription.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButtonItemCategoryDescription.Appearance.Options.UseFont = True
        Me.SimpleButtonItemCategoryDescription.Location = New System.Drawing.Point(241, 74)
        Me.SimpleButtonItemCategoryDescription.Name = "SimpleButtonItemCategoryDescription"
        Me.SimpleButtonItemCategoryDescription.Size = New System.Drawing.Size(87, 27)
        Me.SimpleButtonItemCategoryDescription.TabIndex = 1
        Me.SimpleButtonItemCategoryDescription.Text = "Save"
        '
        'ErrorProviderMasterItemCategory
        '
        Me.ErrorProviderMasterItemCategory.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProviderMasterItemCategory.ContainerControl = Me
        '
        'SimpleButtonMasterItemCategoryCancel
        '
        Me.SimpleButtonMasterItemCategoryCancel.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButtonMasterItemCategoryCancel.Appearance.Options.UseFont = True
        Me.SimpleButtonMasterItemCategoryCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButtonMasterItemCategoryCancel.Location = New System.Drawing.Point(148, 74)
        Me.SimpleButtonMasterItemCategoryCancel.Name = "SimpleButtonMasterItemCategoryCancel"
        Me.SimpleButtonMasterItemCategoryCancel.Size = New System.Drawing.Size(87, 27)
        Me.SimpleButtonMasterItemCategoryCancel.TabIndex = 2
        Me.SimpleButtonMasterItemCategoryCancel.Text = "Cancel"
        '
        'FormMasterRawMaterialCatSingle
        '
        Me.AcceptButton = Me.SimpleButtonItemCategoryDescription
        Me.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.SimpleButtonMasterItemCategoryCancel
        Me.ClientSize = New System.Drawing.Size(354, 121)
        Me.Controls.Add(Me.SimpleButtonMasterItemCategoryCancel)
        Me.Controls.Add(Me.SimpleButtonItemCategoryDescription)
        Me.Controls.Add(Me.TextEditItemCategory)
        Me.Controls.Add(Me.LabelControlItemCategory)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterRawMaterialCatSingle"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Item Category"
        CType(Me.TextEditItemCategory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderMasterItemCategory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControlItemCategory As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEditItemCategory As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SimpleButtonItemCategoryDescription As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProviderMasterItemCategory As System.Windows.Forms.ErrorProvider
    Friend WithEvents SimpleButtonMasterItemCategoryCancel As DevExpress.XtraEditors.SimpleButton
End Class
