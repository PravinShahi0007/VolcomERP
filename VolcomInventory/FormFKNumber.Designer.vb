<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFKNumber
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
        Me.Txtno1 = New DevExpress.XtraEditors.TextEdit()
        Me.Txtno2 = New DevExpress.XtraEditors.TextEdit()
        Me.Txtno3 = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnLogin = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.Txtno1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txtno2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txtno3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Txtno1
        '
        Me.Txtno1.EditValue = "010"
        Me.Txtno1.Enabled = False
        Me.Txtno1.Location = New System.Drawing.Point(16, 43)
        Me.Txtno1.Name = "Txtno1"
        Me.Txtno1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtno1.Properties.Appearance.Options.UseFont = True
        Me.Txtno1.Size = New System.Drawing.Size(68, 36)
        Me.Txtno1.TabIndex = 0
        '
        'Txtno2
        '
        Me.Txtno2.EditValue = ""
        Me.Txtno2.Location = New System.Drawing.Point(104, 43)
        Me.Txtno2.Name = "Txtno2"
        Me.Txtno2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtno2.Properties.Appearance.Options.UseFont = True
        Me.Txtno2.Size = New System.Drawing.Size(138, 36)
        Me.Txtno2.TabIndex = 1
        '
        'Txtno3
        '
        Me.Txtno3.EditValue = ""
        Me.Txtno3.Location = New System.Drawing.Point(262, 43)
        Me.Txtno3.Name = "Txtno3"
        Me.Txtno3.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtno3.Properties.Appearance.Options.UseFont = True
        Me.Txtno3.Size = New System.Drawing.Size(177, 36)
        Me.Txtno3.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(84, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 29)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(242, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 29)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Start From"
        '
        'BtnLogin
        '
        Me.BtnLogin.Appearance.BackColor = System.Drawing.SystemColors.Highlight
        Me.BtnLogin.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLogin.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnLogin.Appearance.Options.UseBackColor = True
        Me.BtnLogin.Appearance.Options.UseFont = True
        Me.BtnLogin.Appearance.Options.UseForeColor = True
        Me.BtnLogin.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnLogin.Location = New System.Drawing.Point(0, 104)
        Me.BtnLogin.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnLogin.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Red
        Me.BtnLogin.LookAndFeel.SkinName = "Metropolis"
        Me.BtnLogin.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnLogin.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnLogin.Name = "BtnLogin"
        Me.BtnLogin.Size = New System.Drawing.Size(451, 24)
        Me.BtnLogin.TabIndex = 6
        Me.BtnLogin.Text = "Confirm"
        '
        'FormFKNumber
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 128)
        Me.Controls.Add(Me.BtnLogin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txtno3)
        Me.Controls.Add(Me.Txtno2)
        Me.Controls.Add(Me.Txtno1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFKNumber"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Set Nomer Faktur"
        CType(Me.Txtno1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txtno2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txtno3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Txtno1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Txtno2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Txtno3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnLogin As DevExpress.XtraEditors.SimpleButton
End Class
