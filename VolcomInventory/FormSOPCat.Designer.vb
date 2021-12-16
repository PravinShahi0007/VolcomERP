<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSOPCat
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
        Me.XTCCat = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPProsedur = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.XTPSubProsedur = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.XTCCat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCCat.SuspendLayout()
        Me.XTPProsedur.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCCat
        '
        Me.XTCCat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCCat.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCCat.Location = New System.Drawing.Point(0, 0)
        Me.XTCCat.Name = "XTCCat"
        Me.XTCCat.SelectedTabPage = Me.XTPProsedur
        Me.XTCCat.Size = New System.Drawing.Size(1054, 519)
        Me.XTCCat.TabIndex = 0
        Me.XTCCat.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPProsedur, Me.XTPSubProsedur})
        '
        'XTPProsedur
        '
        Me.XTPProsedur.Controls.Add(Me.GridControl1)
        Me.XTPProsedur.Controls.Add(Me.PanelControl1)
        Me.XTPProsedur.Name = "XTPProsedur"
        Me.XTPProsedur.Size = New System.Drawing.Size(1048, 491)
        Me.XTPProsedur.Text = "Master Prosedur"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 52)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1048, 439)
        Me.GridControl1.TabIndex = 1
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'PanelControl1
        '
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1048, 52)
        Me.PanelControl1.TabIndex = 0
        '
        'XTPSubProsedur
        '
        Me.XTPSubProsedur.Name = "XTPSubProsedur"
        Me.XTPSubProsedur.Size = New System.Drawing.Size(1048, 491)
        Me.XTPSubProsedur.Text = "Master Sub Prosedur"
        '
        'FormSOPCat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 519)
        Me.Controls.Add(Me.XTCCat)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormSOPCat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SOP Data Master Prosedur - Sub Prosedur"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.XTCCat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCCat.ResumeLayout(False)
        Me.XTPProsedur.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCCat As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPProsedur As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents XTPSubProsedur As DevExpress.XtraTab.XtraTabPage
End Class
