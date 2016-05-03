<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGDistSchemeDet
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
        Me.GCDistScheme = New DevExpress.XtraGrid.GridControl
        Me.GVDistScheme = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        CType(Me.GCDistScheme, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDistScheme, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCDistScheme
        '
        Me.GCDistScheme.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GCDistScheme.Location = New System.Drawing.Point(0, 441)
        Me.GCDistScheme.MainView = Me.GVDistScheme
        Me.GCDistScheme.Name = "GCDistScheme"
        Me.GCDistScheme.Size = New System.Drawing.Size(746, 53)
        Me.GCDistScheme.TabIndex = 0
        Me.GCDistScheme.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDistScheme})
        '
        'GVDistScheme
        '
        Me.GVDistScheme.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4})
        Me.GVDistScheme.GridControl = Me.GCDistScheme
        Me.GVDistScheme.Name = "GVDistScheme"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Planet Surf"
        Me.GridColumn1.FieldName = "15"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Tag = "15"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "SOGO"
        Me.GridColumn2.FieldName = "16"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Tag = "16"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 2
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "MATA"
        Me.GridColumn3.FieldName = "23"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Tag = "23"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Description"
        Me.GridColumn4.FieldName = "description"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SimpleButton1.Location = New System.Drawing.Point(0, 418)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(746, 23)
        Me.SimpleButton1.TabIndex = 1
        Me.SimpleButton1.Text = "SimpleButton1"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(746, 418)
        Me.DataGridView1.TabIndex = 2
        '
        'FormFGDistSchemeDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 494)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.GCDistScheme)
        Me.Name = "FormFGDistSchemeDet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Distribution Scheme"
        CType(Me.GCDistScheme, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDistScheme, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCDistScheme As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDistScheme As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
