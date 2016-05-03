<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterRawMatSingle
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
        Me.LabelRawMat = New DevExpress.XtraEditors.LabelControl
        Me.TxtRawMaterial = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.LEUOM = New DevExpress.XtraEditors.LookUpEdit
        Me.LECategory = New DevExpress.XtraEditors.LookUpEdit
        Me.LECategorySub = New DevExpress.XtraEditors.LookUpEdit
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.LabelCategory = New DevExpress.XtraEditors.LabelControl
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.ErrorProviderRawMat = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.TxtRawMaterial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEUOM.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECategorySub.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderRawMat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelRawMat
        '
        Me.LabelRawMat.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRawMat.Location = New System.Drawing.Point(12, 21)
        Me.LabelRawMat.Name = "LabelRawMat"
        Me.LabelRawMat.Size = New System.Drawing.Size(74, 15)
        Me.LabelRawMat.TabIndex = 0
        Me.LabelRawMat.Text = "Raw Material"
        '
        'TxtRawMaterial
        '
        Me.TxtRawMaterial.Location = New System.Drawing.Point(108, 14)
        Me.TxtRawMaterial.Name = "TxtRawMaterial"
        Me.TxtRawMaterial.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRawMaterial.Properties.Appearance.Options.UseFont = True
        Me.TxtRawMaterial.Properties.MaxLength = 100
        Me.TxtRawMaterial.Size = New System.Drawing.Size(300, 22)
        Me.TxtRawMaterial.TabIndex = 1
        Me.TxtRawMaterial.ToolTip = "Max : 100 characters."
        Me.TxtRawMaterial.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(12, 52)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(28, 15)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "UOM"
        '
        'LEUOM
        '
        Me.LEUOM.Location = New System.Drawing.Point(108, 47)
        Me.LEUOM.Name = "LEUOM"
        Me.LEUOM.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LEUOM.Properties.Appearance.Options.UseFont = True
        Me.LEUOM.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEUOM.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_uom", "Id UOM", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("uom", "uom")})
        Me.LEUOM.Size = New System.Drawing.Size(300, 22)
        Me.LEUOM.TabIndex = 2
        '
        'LECategory
        '
        Me.LECategory.Location = New System.Drawing.Point(108, 84)
        Me.LECategory.Name = "LECategory"
        Me.LECategory.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LECategory.Properties.Appearance.Options.UseFont = True
        Me.LECategory.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECategory.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_item_category", "Id Item Category", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code_item_category", "Code Category"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("item_category", "Item Category")})
        Me.LECategory.Size = New System.Drawing.Size(300, 22)
        Me.LECategory.TabIndex = 3
        '
        'LECategorySub
        '
        Me.LECategorySub.Location = New System.Drawing.Point(108, 124)
        Me.LECategorySub.Name = "LECategorySub"
        Me.LECategorySub.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LECategorySub.Properties.Appearance.Options.UseFont = True
        Me.LECategorySub.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECategorySub.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_item_category_sub", "Id Item Category Sub", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code_item_category_sub", "Code Sub Category"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("item_category_sub", "Sub Category")})
        Me.LECategorySub.Size = New System.Drawing.Size(300, 22)
        Me.LECategorySub.TabIndex = 4
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(12, 131)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(71, 15)
        Me.LabelControl2.TabIndex = 6
        Me.LabelControl2.Text = "Sub Category"
        '
        'LabelCategory
        '
        Me.LabelCategory.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCategory.Location = New System.Drawing.Point(12, 91)
        Me.LabelCategory.Name = "LabelCategory"
        Me.LabelCategory.Size = New System.Drawing.Size(48, 15)
        Me.LabelCategory.TabIndex = 7
        Me.LabelCategory.Text = "Category"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(333, 170)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 5
        Me.BtnSave.Text = "Save"
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(252, 170)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 6
        Me.BtnCancel.Text = "Cancel"
        '
        'ErrorProviderRawMat
        '
        Me.ErrorProviderRawMat.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProviderRawMat.ContainerControl = Me
        '
        'FormMasterRawMatSingle
        '
        Me.AcceptButton = Me.BtnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(433, 218)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.LabelCategory)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LECategorySub)
        Me.Controls.Add(Me.LECategory)
        Me.Controls.Add(Me.LEUOM)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.TxtRawMaterial)
        Me.Controls.Add(Me.LabelRawMat)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterRawMatSingle"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Raw Material"
        CType(Me.TxtRawMaterial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEUOM.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECategory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECategorySub.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderRawMat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelRawMat As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtRawMaterial As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEUOM As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LECategory As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LECategorySub As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelCategory As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProviderRawMat As System.Windows.Forms.ErrorProvider
End Class
