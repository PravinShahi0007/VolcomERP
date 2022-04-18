<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormProductionKOApp
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProductionKOApp))
        Me.PCControl = New DevExpress.XtraEditors.PanelControl()
        Me.BMark = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.PCControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCControl.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PCControl
        '
        Me.PCControl.Controls.Add(Me.BMark)
        Me.PCControl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCControl.Location = New System.Drawing.Point(0, 466)
        Me.PCControl.Name = "PCControl"
        Me.PCControl.Size = New System.Drawing.Size(954, 41)
        Me.PCControl.TabIndex = 2
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BMark.Image = CType(resources.GetObject("BMark.Image"), System.Drawing.Image)
        Me.BMark.ImageIndex = 4
        Me.BMark.Location = New System.Drawing.Point(2, 2)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(96, 37)
        Me.BMark.TabIndex = 8913
        Me.BMark.Text = "Mark"
        '
        'PanelControl1
        '
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(954, 466)
        Me.PanelControl1.TabIndex = 3
        '
        'FormProductionKOApp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 507)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PCControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProductionKOApp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Revise SKO approval"
        CType(Me.PCControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCControl.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PCControl As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
End Class
