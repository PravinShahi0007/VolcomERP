<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportBalanceTaxSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormReportBalanceTaxSummary))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SBNewSummary = New DevExpress.XtraEditors.SimpleButton()
        Me.GCSummary = New DevExpress.XtraGrid.GridControl()
        Me.GVSummary = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBNewSummary)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 49)
        Me.PanelControl1.TabIndex = 0
        '
        'SBNewSummary
        '
        Me.SBNewSummary.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBNewSummary.Image = CType(resources.GetObject("SBNewSummary.Image"), System.Drawing.Image)
        Me.SBNewSummary.Location = New System.Drawing.Point(650, 2)
        Me.SBNewSummary.Name = "SBNewSummary"
        Me.SBNewSummary.Size = New System.Drawing.Size(132, 45)
        Me.SBNewSummary.TabIndex = 0
        Me.SBNewSummary.Text = "New Summary"
        '
        'GCSummary
        '
        Me.GCSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSummary.Location = New System.Drawing.Point(0, 49)
        Me.GCSummary.MainView = Me.GVSummary
        Me.GCSummary.Name = "GCSummary"
        Me.GCSummary.Size = New System.Drawing.Size(784, 512)
        Me.GCSummary.TabIndex = 2
        Me.GCSummary.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSummary})
        '
        'GVSummary
        '
        Me.GVSummary.GridControl = Me.GCSummary
        Me.GVSummary.Name = "GVSummary"
        Me.GVSummary.OptionsView.ShowGroupPanel = False
        '
        'FormReportBalanceTaxSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCSummary)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormReportBalanceTaxSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tax Summary"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCSummary As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSummary As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SBNewSummary As DevExpress.XtraEditors.SimpleButton
End Class
