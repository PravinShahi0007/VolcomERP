<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccessRoleSingle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAccessRoleSingle))
        Me.PictureEditIcon = New DevExpress.XtraEditors.PictureEdit
        Me.TxtRoleName = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.LabelRole = New DevExpress.XtraEditors.LabelControl
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.EPRole = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.PictureEditIcon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRoleName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EPRole, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureEditIcon
        '
        Me.PictureEditIcon.EditValue = CType(resources.GetObject("PictureEditIcon.EditValue"), Object)
        Me.PictureEditIcon.Location = New System.Drawing.Point(12, 12)
        Me.PictureEditIcon.Name = "PictureEditIcon"
        Me.PictureEditIcon.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEditIcon.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEditIcon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEditIcon.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureEditIcon.Size = New System.Drawing.Size(122, 113)
        Me.PictureEditIcon.TabIndex = 37
        '
        'TxtRoleName
        '
        Me.TxtRoleName.Location = New System.Drawing.Point(213, 54)
        Me.TxtRoleName.Name = "TxtRoleName"
        Me.TxtRoleName.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRoleName.Properties.Appearance.Options.UseFont = True
        Me.TxtRoleName.Properties.MaxLength = 30
        Me.TxtRoleName.Size = New System.Drawing.Size(183, 22)
        Me.TxtRoleName.TabIndex = 0
        Me.TxtRoleName.ToolTip = "Example : Admin, Guest, etc. Max : 30 character."
        Me.TxtRoleName.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(140, 61)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(58, 15)
        Me.LabelControl1.TabIndex = 39
        Me.LabelControl1.Text = "Role Name"
        '
        'LabelRole
        '
        Me.LabelRole.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRole.Location = New System.Drawing.Point(140, 12)
        Me.LabelRole.Name = "LabelRole"
        Me.LabelRole.Size = New System.Drawing.Size(79, 26)
        Me.LabelRole.TabIndex = 40
        Me.LabelRole.Text = "Title Role"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(321, 92)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Save"
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(242, 92)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "Cancel"
        '
        'EPRole
        '
        Me.EPRole.ContainerControl = Me
        '
        'FormAccessRoleSingle
        '
        Me.AcceptButton = Me.BtnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(424, 147)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.LabelRole)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.TxtRoleName)
        Me.Controls.Add(Me.PictureEditIcon)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAccessRoleSingle"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Role"
        CType(Me.PictureEditIcon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRoleName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EPRole, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureEditIcon As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents TxtRoleName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelRole As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents EPRole As System.Windows.Forms.ErrorProvider
End Class
