<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpScheduleTable
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
        Me.BSetSchedule = New DevExpress.XtraEditors.SimpleButton()
        Me.GCSchedule = New DevExpress.XtraGrid.GridControl()
        Me.GVSchedule = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BSetSchedule)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 240)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(734, 36)
        Me.PanelControl1.TabIndex = 0
        '
        'BSetSchedule
        '
        Me.BSetSchedule.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSetSchedule.Location = New System.Drawing.Point(623, 2)
        Me.BSetSchedule.Name = "BSetSchedule"
        Me.BSetSchedule.Size = New System.Drawing.Size(109, 32)
        Me.BSetSchedule.TabIndex = 0
        Me.BSetSchedule.Text = "Set Schedule"
        '
        'GCSchedule
        '
        Me.GCSchedule.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSchedule.Location = New System.Drawing.Point(0, 0)
        Me.GCSchedule.MainView = Me.GVSchedule
        Me.GCSchedule.Name = "GCSchedule"
        Me.GCSchedule.Size = New System.Drawing.Size(734, 240)
        Me.GCSchedule.TabIndex = 1
        Me.GCSchedule.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSchedule})
        '
        'GVSchedule
        '
        Me.GVSchedule.GridControl = Me.GCSchedule
        Me.GVSchedule.Name = "GVSchedule"
        Me.GVSchedule.OptionsView.ColumnAutoWidth = False
        Me.GVSchedule.OptionsView.ShowGroupPanel = False
        '
        'FormEmpScheduleTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 276)
        Me.Controls.Add(Me.GCSchedule)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormEmpScheduleTable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fast Schedule"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BSetSchedule As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCSchedule As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSchedule As DevExpress.XtraGrid.Views.Grid.GridView
End Class
