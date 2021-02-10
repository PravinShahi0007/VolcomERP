<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStockCardDept
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
        Me.XTCStockCard = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPStockCard = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.XTPStockOnHand = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPStockOut = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.XTCStockCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCStockCard.SuspendLayout()
        Me.XTPStockCard.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPStockOnHand.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCStockCard
        '
        Me.XTCStockCard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCStockCard.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCStockCard.Location = New System.Drawing.Point(0, 0)
        Me.XTCStockCard.Name = "XTCStockCard"
        Me.XTCStockCard.SelectedTabPage = Me.XTPStockCard
        Me.XTCStockCard.Size = New System.Drawing.Size(1077, 539)
        Me.XTCStockCard.TabIndex = 0
        Me.XTCStockCard.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPStockOnHand, Me.XTPStockCard, Me.XTPStockOut})
        '
        'XTPStockCard
        '
        Me.XTPStockCard.Controls.Add(Me.PanelControl1)
        Me.XTPStockCard.Name = "XTPStockCard"
        Me.XTPStockCard.Size = New System.Drawing.Size(1071, 511)
        Me.XTPStockCard.Text = "Stock Card"
        '
        'PanelControl1
        '
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1071, 46)
        Me.PanelControl1.TabIndex = 0
        '
        'XTPStockOnHand
        '
        Me.XTPStockOnHand.Controls.Add(Me.PanelControl2)
        Me.XTPStockOnHand.Name = "XTPStockOnHand"
        Me.XTPStockOnHand.Size = New System.Drawing.Size(1071, 511)
        Me.XTPStockOnHand.Text = "Stock On Hand"
        '
        'XTPStockOut
        '
        Me.XTPStockOut.Name = "XTPStockOut"
        Me.XTPStockOut.Size = New System.Drawing.Size(1071, 511)
        Me.XTPStockOut.Text = "Out Stock"
        '
        'PanelControl2
        '
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1071, 46)
        Me.PanelControl2.TabIndex = 1
        '
        'FormStockCardDept
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1077, 539)
        Me.Controls.Add(Me.XTCStockCard)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormStockCardDept"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Stock Card"
        CType(Me.XTCStockCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCStockCard.ResumeLayout(False)
        Me.XTPStockCard.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPStockOnHand.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCStockCard As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPStockCard As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPStockOut As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents XTPStockOnHand As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
End Class
