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
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPKO = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.PCControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCControl.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PCControl
        '
        Me.PCControl.Controls.Add(Me.BMark)
        Me.PCControl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCControl.Location = New System.Drawing.Point(0, 440)
        Me.PCControl.Name = "PCControl"
        Me.PCControl.Size = New System.Drawing.Size(909, 41)
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
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPKO
        Me.XtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.[False]
        Me.XtraTabControl1.Size = New System.Drawing.Size(909, 440)
        Me.XtraTabControl1.TabIndex = 3
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPKO})
        '
        'XTPKO
        '
        Me.XTPKO.Name = "XTPKO"
        Me.XTPKO.Size = New System.Drawing.Size(903, 434)
        Me.XTPKO.Text = "XtraTabPage1"
        '
        'FormProductionKOApp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 481)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.PCControl)
        Me.MinimizeBox = False
        Me.Name = "FormProductionKOApp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Revise SKO approval"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PCControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCControl.ResumeLayout(False)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PCControl As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPKO As DevExpress.XtraTab.XtraTabPage
End Class
