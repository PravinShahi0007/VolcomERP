<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPolisRegPick
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
        Me.BRefreshPenawaran = New DevExpress.XtraEditors.SimpleButton()
        Me.BPick = New DevExpress.XtraEditors.SimpleButton()
        Me.GCPolisPPS = New DevExpress.XtraGrid.GridControl()
        Me.GVPolisPPS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCPolisPPS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPolisPPS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BRefreshPenawaran
        '
        Me.BRefreshPenawaran.Appearance.BackColor = System.Drawing.Color.LightSeaGreen
        Me.BRefreshPenawaran.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BRefreshPenawaran.Appearance.ForeColor = System.Drawing.Color.White
        Me.BRefreshPenawaran.Appearance.Options.UseBackColor = True
        Me.BRefreshPenawaran.Appearance.Options.UseFont = True
        Me.BRefreshPenawaran.Appearance.Options.UseForeColor = True
        Me.BRefreshPenawaran.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BRefreshPenawaran.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BRefreshPenawaran.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BRefreshPenawaran.Location = New System.Drawing.Point(0, 324)
        Me.BRefreshPenawaran.LookAndFeel.SkinName = "Metropolis"
        Me.BRefreshPenawaran.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BRefreshPenawaran.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BRefreshPenawaran.Name = "BRefreshPenawaran"
        Me.BRefreshPenawaran.Size = New System.Drawing.Size(526, 32)
        Me.BRefreshPenawaran.TabIndex = 144
        Me.BRefreshPenawaran.Text = "Refresh"
        '
        'BPick
        '
        Me.BPick.Appearance.BackColor = System.Drawing.Color.DarkBlue
        Me.BPick.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BPick.Appearance.ForeColor = System.Drawing.Color.White
        Me.BPick.Appearance.Options.UseBackColor = True
        Me.BPick.Appearance.Options.UseFont = True
        Me.BPick.Appearance.Options.UseForeColor = True
        Me.BPick.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BPick.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BPick.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BPick.Location = New System.Drawing.Point(0, 356)
        Me.BPick.LookAndFeel.SkinName = "Metropolis"
        Me.BPick.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BPick.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BPick.Name = "BPick"
        Me.BPick.Size = New System.Drawing.Size(526, 32)
        Me.BPick.TabIndex = 145
        Me.BPick.Text = "Pick"
        '
        'GCPolisPPS
        '
        Me.GCPolisPPS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPolisPPS.Location = New System.Drawing.Point(0, 0)
        Me.GCPolisPPS.MainView = Me.GVPolisPPS
        Me.GCPolisPPS.Name = "GCPolisPPS"
        Me.GCPolisPPS.Size = New System.Drawing.Size(526, 324)
        Me.GCPolisPPS.TabIndex = 146
        Me.GCPolisPPS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPolisPPS})
        '
        'GVPolisPPS
        '
        Me.GVPolisPPS.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn12, Me.GridColumn13, Me.GridColumn2, Me.GridColumn1, Me.GridColumn15})
        Me.GVPolisPPS.GridControl = Me.GCPolisPPS
        Me.GVPolisPPS.Name = "GVPolisPPS"
        Me.GVPolisPPS.OptionsBehavior.Editable = False
        Me.GVPolisPPS.OptionsBehavior.ReadOnly = True
        Me.GVPolisPPS.OptionsView.ShowGroupPanel = False
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "ID"
        Me.GridColumn12.FieldName = "id_polis_pps"
        Me.GridColumn12.Name = "GridColumn12"
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Number"
        Me.GridColumn13.FieldName = "number"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Created By"
        Me.GridColumn2.FieldName = "employee_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Created Date"
        Me.GridColumn1.FieldName = "created_date"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Report Status"
        Me.GridColumn15.FieldName = "report_status"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 3
        '
        'FormPolisRegPick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 388)
        Me.Controls.Add(Me.GCPolisPPS)
        Me.Controls.Add(Me.BRefreshPenawaran)
        Me.Controls.Add(Me.BPick)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPolisRegPick"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Proposal Number"
        CType(Me.GCPolisPPS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPolisPPS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BRefreshPenawaran As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPick As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCPolisPPS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPolisPPS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
