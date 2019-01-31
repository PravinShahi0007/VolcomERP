<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormOpt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOpt))
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPGen = New DevExpress.XtraTab.XtraTabPage()
        Me.XSCGen = New DevExpress.XtraEditors.XtraScrollableControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPGen.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPGen
        Me.XtraTabControl1.Size = New System.Drawing.Size(974, 447)
        Me.XtraTabControl1.TabIndex = 0
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPGen})
        '
        'XTPGen
        '
        Me.XTPGen.Controls.Add(Me.XSCGen)
        Me.XTPGen.Controls.Add(Me.GroupControl2)
        Me.XTPGen.Controls.Add(Me.GroupControl1)
        Me.XTPGen.Name = "XTPGen"
        Me.XTPGen.Size = New System.Drawing.Size(968, 419)
        Me.XTPGen.Text = "General"
        '
        'XSCGen
        '
        Me.XSCGen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XSCGen.Location = New System.Drawing.Point(0, 41)
        Me.XSCGen.Name = "XSCGen"
        Me.XSCGen.Padding = New System.Windows.Forms.Padding(10)
        Me.XSCGen.Size = New System.Drawing.Size(968, 337)
        Me.XSCGen.TabIndex = 0
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(968, 41)
        Me.GroupControl2.TabIndex = 1
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.SBSave)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl1.Location = New System.Drawing.Point(0, 378)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(968, 41)
        Me.GroupControl1.TabIndex = 0
        '
        'SBSave
        '
        Me.SBSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBSave.Image = CType(resources.GetObject("SBSave.Image"), System.Drawing.Image)
        Me.SBSave.Location = New System.Drawing.Point(881, 2)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(85, 37)
        Me.SBSave.TabIndex = 0
        Me.SBSave.Text = "Save"
        '
        'FormOpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 447)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Name = "FormOpt"
        Me.Text = "OPT"
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPGen.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPGen As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XSCGen As DevExpress.XtraEditors.XtraScrollableControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
End Class
