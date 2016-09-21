<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpReview
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
        Me.XTCEmpReview = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPContract = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPAge = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.XTCEmpReview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCEmpReview.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCEmpReview
        '
        Me.XTCEmpReview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCEmpReview.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left
        Me.XTCEmpReview.Location = New System.Drawing.Point(0, 0)
        Me.XTCEmpReview.Name = "XTCEmpReview"
        Me.XTCEmpReview.SelectedTabPage = Me.XTPContract
        Me.XTCEmpReview.Size = New System.Drawing.Size(581, 262)
        Me.XTCEmpReview.TabIndex = 0
        Me.XTCEmpReview.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPContract, Me.XTPAge})
        '
        'XTPContract
        '
        Me.XTPContract.Name = "XTPContract"
        Me.XTPContract.Size = New System.Drawing.Size(552, 256)
        Me.XTPContract.Text = "Contract"
        '
        'XTPAge
        '
        Me.XTPAge.Name = "XTPAge"
        Me.XTPAge.Size = New System.Drawing.Size(294, 272)
        Me.XTPAge.Text = "Age"
        '
        'FormEmpReview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 262)
        Me.Controls.Add(Me.XTCEmpReview)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpReview"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employee Review"
        CType(Me.XTCEmpReview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCEmpReview.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCEmpReview As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPContract As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPAge As DevExpress.XtraTab.XtraTabPage
End Class
