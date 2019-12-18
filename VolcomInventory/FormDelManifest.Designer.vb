<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDelManifest
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
        Me.XTCDelManifest = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPList = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPDetail = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.XTCDelManifest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCDelManifest.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCDelManifest
        '
        Me.XTCDelManifest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCDelManifest.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCDelManifest.Location = New System.Drawing.Point(0, 0)
        Me.XTCDelManifest.Name = "XTCDelManifest"
        Me.XTCDelManifest.SelectedTabPage = Me.XTPList
        Me.XTCDelManifest.Size = New System.Drawing.Size(766, 502)
        Me.XTCDelManifest.TabIndex = 0
        Me.XTCDelManifest.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPList, Me.XTPDetail})
        '
        'XTPList
        '
        Me.XTPList.Name = "XTPList"
        Me.XTPList.Size = New System.Drawing.Size(760, 474)
        Me.XTPList.Text = "Created List"
        '
        'XTPDetail
        '
        Me.XTPDetail.Name = "XTPDetail"
        Me.XTPDetail.Size = New System.Drawing.Size(294, 272)
        Me.XTPDetail.Text = "Detail Manifest"
        '
        'FormDelManifest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 502)
        Me.Controls.Add(Me.XTCDelManifest)
        Me.Name = "FormDelManifest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Outbound Delivery Manifest"
        CType(Me.XTCDelManifest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCDelManifest.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCDelManifest As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPDetail As DevExpress.XtraTab.XtraTabPage
End Class
