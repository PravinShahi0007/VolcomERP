<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDisplayAlloc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDisplayAlloc))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnClassGroup = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnExportToXLS = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnLog = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnClassGroup)
        Me.PanelControl1.Controls.Add(Me.BtnExportToXLS)
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Controls.Add(Me.BtnLog)
        Me.PanelControl1.Controls.Add(Me.BtnRefresh)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(717, 45)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnClassGroup
        '
        Me.BtnClassGroup.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnClassGroup.Image = CType(resources.GetObject("BtnClassGroup.Image"), System.Drawing.Image)
        Me.BtnClassGroup.Location = New System.Drawing.Point(2, 2)
        Me.BtnClassGroup.Name = "BtnClassGroup"
        Me.BtnClassGroup.Size = New System.Drawing.Size(114, 41)
        Me.BtnClassGroup.TabIndex = 3
        Me.BtnClassGroup.Text = "Class Group"
        '
        'BtnExportToXLS
        '
        Me.BtnExportToXLS.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnExportToXLS.Image = CType(resources.GetObject("BtnExportToXLS.Image"), System.Drawing.Image)
        Me.BtnExportToXLS.Location = New System.Drawing.Point(298, 2)
        Me.BtnExportToXLS.Name = "BtnExportToXLS"
        Me.BtnExportToXLS.Size = New System.Drawing.Size(119, 41)
        Me.BtnExportToXLS.TabIndex = 1
        Me.BtnExportToXLS.Text = "Export to XLS"
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(417, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(87, 41)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print"
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnRefresh.Image = CType(resources.GetObject("BtnRefresh.Image"), System.Drawing.Image)
        Me.BtnRefresh.Location = New System.Drawing.Point(618, 2)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(97, 41)
        Me.BtnRefresh.TabIndex = 2
        Me.BtnRefresh.Text = "Refresh"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 45)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(717, 407)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'BtnLog
        '
        Me.BtnLog.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnLog.Image = CType(resources.GetObject("BtnLog.Image"), System.Drawing.Image)
        Me.BtnLog.Location = New System.Drawing.Point(504, 2)
        Me.BtnLog.Name = "BtnLog"
        Me.BtnLog.Size = New System.Drawing.Size(114, 41)
        Me.BtnLog.TabIndex = 4
        Me.BtnLog.Text = "Log Update"
        '
        'FormDisplayAlloc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 452)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormDisplayAlloc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Display Capacity"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnExportToXLS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnClassGroup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnLog As DevExpress.XtraEditors.SimpleButton
End Class
