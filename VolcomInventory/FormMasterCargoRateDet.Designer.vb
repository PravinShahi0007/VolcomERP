<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterCargoRateDet
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
        Me.SPC = New DevExpress.XtraEditors.SplitContainerControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GC = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.SPC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SPC.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SPC
        '
        Me.SPC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SPC.Horizontal = False
        Me.SPC.Location = New System.Drawing.Point(0, 0)
        Me.SPC.Name = "SPC"
        Me.SPC.Panel1.Controls.Add(Me.GC)
        Me.SPC.Panel1.Text = "Panel1"
        Me.SPC.Panel2.Controls.Add(Me.PanelControl1)
        Me.SPC.Panel2.Text = "Panel2"
        Me.SPC.Size = New System.Drawing.Size(736, 318)
        Me.SPC.SplitterPosition = 148
        Me.SPC.TabIndex = 0
        Me.SPC.Text = "SplitContainerControl1"
        '
        'PanelControl1
        '
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(736, 40)
        Me.PanelControl1.TabIndex = 1
        '
        'GC
        '
        Me.GC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GC.Location = New System.Drawing.Point(0, 0)
        Me.GC.MainView = Me.GridView1
        Me.GC.Name = "GC"
        Me.GC.Size = New System.Drawing.Size(736, 148)
        Me.GC.TabIndex = 0
        Me.GC.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GC
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'FormMasterCargoRateDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 318)
        Me.Controls.Add(Me.SPC)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterCargoRateDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cargo Rate"
        CType(Me.SPC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SPC.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SPC As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GC As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
