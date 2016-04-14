<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccount
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAccount))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.TERepeatPassword = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TEPassword = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TEUsername = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.EPUser = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PictureEditIcon = New DevExpress.XtraEditors.PictureEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TERepeatPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EPUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEditIcon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 169)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(433, 55)
        Me.PanelControl1.TabIndex = 5
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(252, 17)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(333, 17)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 3
        Me.BtnSave.Text = "Save"
        '
        'TERepeatPassword
        '
        Me.TERepeatPassword.Location = New System.Drawing.Point(142, 121)
        Me.TERepeatPassword.Name = "TERepeatPassword"
        Me.TERepeatPassword.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TERepeatPassword.Properties.Appearance.Options.UseFont = True
        Me.TERepeatPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TERepeatPassword.Size = New System.Drawing.Size(266, 22)
        Me.TERepeatPassword.TabIndex = 2
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(142, 104)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(101, 15)
        Me.LabelControl4.TabIndex = 44
        Me.LabelControl4.Text = "Confirm Password"
        '
        'TEPassword
        '
        Me.TEPassword.Location = New System.Drawing.Point(142, 76)
        Me.TEPassword.Name = "TEPassword"
        Me.TEPassword.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEPassword.Properties.Appearance.Options.UseFont = True
        Me.TEPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TEPassword.Size = New System.Drawing.Size(266, 22)
        Me.TEPassword.TabIndex = 1
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(142, 58)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(54, 15)
        Me.LabelControl3.TabIndex = 43
        Me.LabelControl3.Text = "Password"
        '
        'TEUsername
        '
        Me.TEUsername.Location = New System.Drawing.Point(142, 30)
        Me.TEUsername.Name = "TEUsername"
        Me.TEUsername.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEUsername.Properties.Appearance.Options.UseFont = True
        Me.TEUsername.Size = New System.Drawing.Size(266, 22)
        Me.TEUsername.TabIndex = 0
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(142, 9)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(55, 15)
        Me.LabelControl2.TabIndex = 42
        Me.LabelControl2.Text = "Username"
        '
        'EPUser
        '
        Me.EPUser.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EPUser.ContainerControl = Me
        '
        'PictureEditIcon
        '
        Me.PictureEditIcon.EditValue = CType(resources.GetObject("PictureEditIcon.EditValue"), Object)
        Me.PictureEditIcon.Location = New System.Drawing.Point(12, 24)
        Me.PictureEditIcon.Name = "PictureEditIcon"
        Me.PictureEditIcon.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEditIcon.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEditIcon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEditIcon.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureEditIcon.Size = New System.Drawing.Size(122, 113)
        Me.PictureEditIcon.TabIndex = 45
        '
        'FormAccount
        '
        Me.AcceptButton = Me.BtnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(433, 224)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureEditIcon)
        Me.Controls.Add(Me.TERepeatPassword)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.TEPassword)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TEUsername)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAccount"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Account"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.TERepeatPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEUsername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EPUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEditIcon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TERepeatPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEUsername As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents EPUser As System.Windows.Forms.ErrorProvider
    Friend WithEvents PictureEditIcon As DevExpress.XtraEditors.PictureEdit
End Class
