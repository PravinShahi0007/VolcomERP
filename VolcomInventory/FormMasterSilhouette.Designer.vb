<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterSilhouette
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterSilhouette))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnMapping = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnExportToXLS = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnExportToXLS)
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Controls.Add(Me.BtnMapping)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(685, 45)
        Me.PanelControl1.TabIndex = 1
        '
        'BtnMapping
        '
        Me.BtnMapping.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnMapping.Image = CType(resources.GetObject("BtnMapping.Image"), System.Drawing.Image)
        Me.BtnMapping.Location = New System.Drawing.Point(597, 2)
        Me.BtnMapping.Name = "BtnMapping"
        Me.BtnMapping.Size = New System.Drawing.Size(86, 41)
        Me.BtnMapping.TabIndex = 0
        Me.BtnMapping.Text = "Setup"
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(515, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(82, 41)
        Me.BtnPrint.TabIndex = 1
        Me.BtnPrint.Text = "Print"
        '
        'BtnExportToXLS
        '
        Me.BtnExportToXLS.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnExportToXLS.Image = CType(resources.GetObject("BtnExportToXLS.Image"), System.Drawing.Image)
        Me.BtnExportToXLS.Location = New System.Drawing.Point(395, 2)
        Me.BtnExportToXLS.Name = "BtnExportToXLS"
        Me.BtnExportToXLS.Size = New System.Drawing.Size(120, 41)
        Me.BtnExportToXLS.TabIndex = 2
        Me.BtnExportToXLS.Text = "Export to XLS"
        '
        'FormMasterSilhouette
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(685, 491)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormMasterSilhouette"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Silhouette"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnis_select As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnid_code_detail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndisplay_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncode_detail_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnExportToXLS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnMapping As DevExpress.XtraEditors.SimpleButton
End Class
