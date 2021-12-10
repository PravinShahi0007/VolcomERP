<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSOPIndex
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSOPIndex))
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPBySOP = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPByModul = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GCBySOP = New DevExpress.XtraGrid.GridControl()
        Me.GVBySOP = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BNewSOP = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPBySOP.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCBySOP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBySOP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 48)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPBySOP
        Me.XtraTabControl1.Size = New System.Drawing.Size(1046, 520)
        Me.XtraTabControl1.TabIndex = 0
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPBySOP, Me.XTPByModul})
        '
        'XTPBySOP
        '
        Me.XTPBySOP.Controls.Add(Me.GCBySOP)
        Me.XTPBySOP.Controls.Add(Me.BNewSOP)
        Me.XTPBySOP.Name = "XTPBySOP"
        Me.XTPBySOP.Size = New System.Drawing.Size(1040, 492)
        Me.XTPBySOP.Text = "By SOP"
        '
        'XTPByModul
        '
        Me.XTPByModul.Name = "XTPByModul"
        Me.XTPByModul.Size = New System.Drawing.Size(1040, 487)
        Me.XTPByModul.Text = "By Modul ERP"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BRefresh)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1046, 48)
        Me.PanelControl1.TabIndex = 1
        '
        'GCBySOP
        '
        Me.GCBySOP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBySOP.Location = New System.Drawing.Point(0, 0)
        Me.GCBySOP.MainView = Me.GVBySOP
        Me.GCBySOP.Name = "GCBySOP"
        Me.GCBySOP.Size = New System.Drawing.Size(1040, 452)
        Me.GCBySOP.TabIndex = 0
        Me.GCBySOP.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBySOP})
        '
        'GVBySOP
        '
        Me.GVBySOP.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn6, Me.GridColumn2, Me.GridColumn3, Me.GridColumn5, Me.GridColumn4})
        Me.GVBySOP.GridControl = Me.GCBySOP
        Me.GVBySOP.Name = "GVBySOP"
        Me.GVBySOP.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_sop"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "SOP"
        Me.GridColumn2.FieldName = "sop_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "File"
        Me.GridColumn3.FieldName = "doc_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Menu ERP"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Button Name ERP"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'BRefresh
        '
        Me.BRefresh.Dock = System.Windows.Forms.DockStyle.Right
        Me.BRefresh.Image = CType(resources.GetObject("BRefresh.Image"), System.Drawing.Image)
        Me.BRefresh.Location = New System.Drawing.Point(928, 2)
        Me.BRefresh.Name = "BRefresh"
        Me.BRefresh.Size = New System.Drawing.Size(116, 44)
        Me.BRefresh.TabIndex = 1
        Me.BRefresh.Text = "Refresh"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Departement"
        Me.GridColumn6.FieldName = "departement"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        '
        'BNewSOP
        '
        Me.BNewSOP.Appearance.BackColor = System.Drawing.Color.DarkBlue
        Me.BNewSOP.Appearance.ForeColor = System.Drawing.Color.White
        Me.BNewSOP.Appearance.Options.UseBackColor = True
        Me.BNewSOP.Appearance.Options.UseForeColor = True
        Me.BNewSOP.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BNewSOP.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BNewSOP.Location = New System.Drawing.Point(0, 452)
        Me.BNewSOP.Name = "BNewSOP"
        Me.BNewSOP.Size = New System.Drawing.Size(1040, 40)
        Me.BNewSOP.TabIndex = 7
        Me.BNewSOP.Text = "New SOP"
        '
        'FormSOPIndex
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1046, 568)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSOPIndex"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Index SOP"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPBySOP.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCBySOP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBySOP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPBySOP As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPByModul As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCBySOP As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBySOP As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BNewSOP As DevExpress.XtraEditors.SimpleButton
End Class
