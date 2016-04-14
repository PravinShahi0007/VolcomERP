<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterComnputerDet
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
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtPCName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtCurrentUser = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtIPAddress = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtSpesification = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtDepartement = New DevExpress.XtraEditors.TextEdit()
        Me.BtnLogin = New DevExpress.XtraEditors.SimpleButton()
        Me.EPLogin = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.TxtPCName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCurrentUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtIPAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSpesification.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDepartement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EPLogin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 28)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "PC Name"
        '
        'TxtPCName
        '
        Me.TxtPCName.Location = New System.Drawing.Point(118, 25)
        Me.TxtPCName.Name = "TxtPCName"
        Me.TxtPCName.Size = New System.Drawing.Size(283, 20)
        Me.TxtPCName.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 54)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(62, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Current User"
        '
        'TxtCurrentUser
        '
        Me.TxtCurrentUser.Location = New System.Drawing.Point(118, 51)
        Me.TxtCurrentUser.Name = "TxtCurrentUser"
        Me.TxtCurrentUser.Size = New System.Drawing.Size(283, 20)
        Me.TxtCurrentUser.TabIndex = 3
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 80)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(52, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "IP Address"
        '
        'TxtIPAddress
        '
        Me.TxtIPAddress.Location = New System.Drawing.Point(118, 77)
        Me.TxtIPAddress.Name = "TxtIPAddress"
        Me.TxtIPAddress.Size = New System.Drawing.Size(283, 20)
        Me.TxtIPAddress.TabIndex = 5
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 106)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl4.TabIndex = 6
        Me.LabelControl4.Text = "Spesification"
        '
        'TxtSpesification
        '
        Me.TxtSpesification.Location = New System.Drawing.Point(118, 103)
        Me.TxtSpesification.Name = "TxtSpesification"
        Me.TxtSpesification.Size = New System.Drawing.Size(283, 20)
        Me.TxtSpesification.TabIndex = 7
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(12, 132)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl5.TabIndex = 8
        Me.LabelControl5.Text = "Departement"
        '
        'TxtDepartement
        '
        Me.TxtDepartement.Location = New System.Drawing.Point(118, 129)
        Me.TxtDepartement.Name = "TxtDepartement"
        Me.TxtDepartement.Size = New System.Drawing.Size(283, 20)
        Me.TxtDepartement.TabIndex = 9
        '
        'BtnLogin
        '
        Me.BtnLogin.Appearance.BackColor = System.Drawing.SystemColors.Highlight
        Me.BtnLogin.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLogin.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnLogin.Appearance.Options.UseBackColor = True
        Me.BtnLogin.Appearance.Options.UseFont = True
        Me.BtnLogin.Appearance.Options.UseForeColor = True
        Me.BtnLogin.Location = New System.Drawing.Point(326, 159)
        Me.BtnLogin.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnLogin.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Red
        Me.BtnLogin.LookAndFeel.SkinName = "Metropolis"
        Me.BtnLogin.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnLogin.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnLogin.Name = "BtnLogin"
        Me.BtnLogin.Size = New System.Drawing.Size(75, 24)
        Me.BtnLogin.TabIndex = 10
        Me.BtnLogin.Text = "Save"
        '
        'EPLogin
        '
        Me.EPLogin.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EPLogin.ContainerControl = Me
        '
        'FormMasterComnputerDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 195)
        Me.Controls.Add(Me.BtnLogin)
        Me.Controls.Add(Me.TxtDepartement)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.TxtSpesification)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.TxtIPAddress)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TxtCurrentUser)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TxtPCName)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.LookAndFeel.SkinName = "Metropolis"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterComnputerDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Computer Info"
        CType(Me.TxtPCName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCurrentUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtIPAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSpesification.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDepartement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EPLogin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtPCName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCurrentUser As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtIPAddress As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtSpesification As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtDepartement As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnLogin As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents EPLogin As ErrorProvider
End Class
