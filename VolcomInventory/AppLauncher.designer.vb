<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AppLauncher
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
        Me.ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl
        Me.LVersion = New DevExpress.XtraEditors.LabelControl
        Me.BUpdate = New DevExpress.XtraEditors.SimpleButton
        Me.BLaunch = New DevExpress.XtraEditors.SimpleButton
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProgressBarControl1
        '
        Me.ProgressBarControl1.Location = New System.Drawing.Point(12, 380)
        Me.ProgressBarControl1.Name = "ProgressBarControl1"
        Me.ProgressBarControl1.Size = New System.Drawing.Size(300, 20)
        Me.ProgressBarControl1.TabIndex = 0
        '
        'LVersion
        '
        Me.LVersion.Dock = System.Windows.Forms.DockStyle.Left
        Me.LVersion.Location = New System.Drawing.Point(0, 0)
        Me.LVersion.Name = "LVersion"
        Me.LVersion.Size = New System.Drawing.Size(45, 13)
        Me.LVersion.TabIndex = 1
        Me.LVersion.Text = "Version : "
        '
        'BUpdate
        '
        Me.BUpdate.Location = New System.Drawing.Point(12, 352)
        Me.BUpdate.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BUpdate.Name = "BUpdate"
        Me.BUpdate.Size = New System.Drawing.Size(145, 22)
        Me.BUpdate.TabIndex = 2
        Me.BUpdate.Text = "Update"
        '
        'BLaunch
        '
        Me.BLaunch.Location = New System.Drawing.Point(163, 352)
        Me.BLaunch.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BLaunch.Name = "BLaunch"
        Me.BLaunch.Size = New System.Drawing.Size(149, 22)
        Me.BLaunch.TabIndex = 3
        Me.BLaunch.Text = "Launch"
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Location = New System.Drawing.Point(12, 12)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit1.Properties.NullText = " "
        Me.PictureEdit1.Properties.ReadOnly = True
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(300, 307)
        Me.PictureEdit1.TabIndex = 4
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.White
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelControl1.Controls.Add(Me.PanelControl2)
        Me.PanelControl1.Controls.Add(Me.BUpdate)
        Me.PanelControl1.Controls.Add(Me.PictureEdit1)
        Me.PanelControl1.Controls.Add(Me.ProgressBarControl1)
        Me.PanelControl1.Controls.Add(Me.BLaunch)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(325, 413)
        Me.PanelControl1.TabIndex = 5
        '
        'PanelControl2
        '
        Me.PanelControl2.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl2.Appearance.Options.UseBackColor = True
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.LVersion)
        Me.PanelControl2.Location = New System.Drawing.Point(12, 331)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(300, 15)
        Me.PanelControl2.TabIndex = 5
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(80, 100)
        Me.LayoutControlItem2.Text = "LayoutControlItem2"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(50, 20)
        Me.LayoutControlItem2.TextToControlDistance = 5
        '
        'AppLauncher
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(325, 413)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.LookAndFeel.SkinName = "Stardust"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "AppLauncher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Launcher"
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents LVersion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BUpdate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BLaunch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
End Class
