<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProposePromo
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GCPromo = New DevExpress.XtraGrid.GridControl()
        Me.GVPromo = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCPromo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPromo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 94)
        Me.PanelControl1.TabIndex = 0
        '
        'GCPromo
        '
        Me.GCPromo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPromo.Location = New System.Drawing.Point(0, 94)
        Me.GCPromo.MainView = Me.GVPromo
        Me.GCPromo.Name = "GCPromo"
        Me.GCPromo.Size = New System.Drawing.Size(784, 467)
        Me.GCPromo.TabIndex = 1
        Me.GCPromo.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPromo})
        '
        'GVPromo
        '
        Me.GVPromo.GridControl = Me.GCPromo
        Me.GVPromo.Name = "GVPromo"
        '
        'FormProposePromo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCPromo)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormProposePromo"
        Me.Text = "Propose Promo"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCPromo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPromo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCPromo As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPromo As DevExpress.XtraGrid.Views.Grid.GridView
End Class
