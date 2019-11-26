<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMailManagePendingInvoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMailManagePendingInvoice))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnViewDetail = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnViewDetail)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 404)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(687, 44)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnViewDetail
        '
        Me.BtnViewDetail.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnViewDetail.Image = CType(resources.GetObject("BtnViewDetail.Image"), System.Drawing.Image)
        Me.BtnViewDetail.Location = New System.Drawing.Point(578, 2)
        Me.BtnViewDetail.Name = "BtnViewDetail"
        Me.BtnViewDetail.Size = New System.Drawing.Size(107, 40)
        Me.BtnViewDetail.TabIndex = 0
        Me.BtnViewDetail.Text = "View Detail"
        '
        'FormMailManagePendingInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 448)
        Me.Controls.Add(Me.PanelControl1)
        Me.LookAndFeel.SkinName = "Office 2007 Pink"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MinimizeBox = False
        Me.Name = "FormMailManagePendingInvoice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pending Invoice (Store Group)"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnViewDetail As DevExpress.XtraEditors.SimpleButton
End Class
