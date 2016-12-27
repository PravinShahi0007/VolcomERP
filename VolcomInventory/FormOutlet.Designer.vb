<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOutlet
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
        Me.components = New System.ComponentModel.Container()
        Me.GCOutlet = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CloneCompanyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVOutlet = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CloneEmployeeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.GCOutlet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GVOutlet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCOutlet
        '
        Me.GCOutlet.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCOutlet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOutlet.Location = New System.Drawing.Point(0, 0)
        Me.GCOutlet.MainView = Me.GVOutlet
        Me.GCOutlet.Name = "GCOutlet"
        Me.GCOutlet.Size = New System.Drawing.Size(637, 287)
        Me.GCOutlet.TabIndex = 0
        Me.GCOutlet.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOutlet})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloneCompanyToolStripMenuItem, Me.CloneEmployeeToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(161, 70)
        '
        'CloneCompanyToolStripMenuItem
        '
        Me.CloneCompanyToolStripMenuItem.Name = "CloneCompanyToolStripMenuItem"
        Me.CloneCompanyToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.CloneCompanyToolStripMenuItem.Text = "Clone company"
        '
        'GVOutlet
        '
        Me.GVOutlet.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.GVOutlet.GridControl = Me.GCOutlet
        Me.GVOutlet.Name = "GVOutlet"
        Me.GVOutlet.OptionsBehavior.Editable = False
        Me.GVOutlet.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Conn"
        Me.GridColumn1.FieldName = "id_store_conn"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Id Outlet"
        Me.GridColumn2.FieldName = "id_outlet"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Outlet"
        Me.GridColumn3.FieldName = "outlet"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Host"
        Me.GridColumn4.FieldName = "host"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Username"
        Me.GridColumn5.FieldName = "username"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Password"
        Me.GridColumn6.FieldName = "pass"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 3
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "DB"
        Me.GridColumn7.FieldName = "db"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 4
        '
        'CloneEmployeeToolStripMenuItem
        '
        Me.CloneEmployeeToolStripMenuItem.Name = "CloneEmployeeToolStripMenuItem"
        Me.CloneEmployeeToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.CloneEmployeeToolStripMenuItem.Text = "Clone employee"
        '
        'FormOutlet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(637, 287)
        Me.Controls.Add(Me.GCOutlet)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormOutlet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Outlet"
        CType(Me.GCOutlet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GVOutlet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCOutlet As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOutlet As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CloneCompanyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CloneEmployeeToolStripMenuItem As ToolStripMenuItem
End Class
