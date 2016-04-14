<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterCompGroupDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterCompGroupDet))
        Me.TECompanyGroup = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BSave = New DevExpress.XtraEditors.SimpleButton
        Me.PictureSeason = New DevExpress.XtraEditors.PictureEdit
        CType(Me.TECompanyGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TECompanyGroup
        '
        Me.TECompanyGroup.Location = New System.Drawing.Point(224, 12)
        Me.TECompanyGroup.Name = "TECompanyGroup"
        Me.TECompanyGroup.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TECompanyGroup.Properties.Appearance.Options.UseFont = True
        Me.TECompanyGroup.Size = New System.Drawing.Size(223, 22)
        Me.TECompanyGroup.TabIndex = 5
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(113, 15)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(88, 15)
        Me.LabelControl4.TabIndex = 4
        Me.LabelControl4.Text = "Company Group"
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(302, 45)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(69, 23)
        Me.BCancel.TabIndex = 12
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(377, 45)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(70, 23)
        Me.BSave.TabIndex = 11
        Me.BSave.Text = "Save"
        '
        'PictureSeason
        '
        Me.PictureSeason.EditValue = CType(resources.GetObject("PictureSeason.EditValue"), Object)
        Me.PictureSeason.Location = New System.Drawing.Point(21, -2)
        Me.PictureSeason.Name = "PictureSeason"
        Me.PictureSeason.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureSeason.Properties.Appearance.Options.UseBackColor = True
        Me.PictureSeason.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureSeason.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureSeason.Size = New System.Drawing.Size(76, 85)
        Me.PictureSeason.TabIndex = 20
        '
        'FormMasterCompGroupDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(459, 80)
        Me.Controls.Add(Me.PictureSeason)
        Me.Controls.Add(Me.BCancel)
        Me.Controls.Add(Me.BSave)
        Me.Controls.Add(Me.TECompanyGroup)
        Me.Controls.Add(Me.LabelControl4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterCompGroupDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Group Company"
        CType(Me.TECompanyGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TECompanyGroup As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PictureSeason As DevExpress.XtraEditors.PictureEdit
End Class
