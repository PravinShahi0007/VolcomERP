<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProposePriceMKDExtendedEOS
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
        Me.BtnUpdate = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        Me.CEStatus = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.CEStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnUpdate.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnUpdate.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnUpdate.Appearance.Options.UseBackColor = True
        Me.BtnUpdate.Appearance.Options.UseFont = True
        Me.BtnUpdate.Appearance.Options.UseForeColor = True
        Me.BtnUpdate.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnUpdate.Location = New System.Drawing.Point(0, 96)
        Me.BtnUpdate.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnUpdate.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnUpdate.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnUpdate.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(290, 32)
        Me.BtnUpdate.TabIndex = 19
        Me.BtnUpdate.Text = "Update"
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Appearance.BackColor = System.Drawing.Color.Crimson
        Me.BtnDiscard.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnDiscard.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnDiscard.Appearance.Options.UseBackColor = True
        Me.BtnDiscard.Appearance.Options.UseFont = True
        Me.BtnDiscard.Appearance.Options.UseForeColor = True
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnDiscard.Location = New System.Drawing.Point(0, 128)
        Me.BtnDiscard.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnDiscard.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnDiscard.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnDiscard.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(290, 32)
        Me.BtnDiscard.TabIndex = 20
        Me.BtnDiscard.Text = "Discard"
        '
        'CEStatus
        '
        Me.CEStatus.Location = New System.Drawing.Point(17, 30)
        Me.CEStatus.Name = "CEStatus"
        Me.CEStatus.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CEStatus.Properties.Appearance.Options.UseFont = True
        Me.CEStatus.Properties.Caption = " Set as extended EOS"
        Me.CEStatus.Size = New System.Drawing.Size(276, 33)
        Me.CEStatus.TabIndex = 21
        '
        'FormProposePriceMKDExtendedEOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(290, 160)
        Me.Controls.Add(Me.CEStatus)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Controls.Add(Me.BtnDiscard)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProposePriceMKDExtendedEOS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Extended EOS Status"
        CType(Me.CEStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnUpdate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CEStatus As DevExpress.XtraEditors.CheckEdit
End Class
