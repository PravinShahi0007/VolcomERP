<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterDesignLookUp
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
        Me.GCBrowse = New DevExpress.XtraGrid.GridControl()
        Me.GVBrowse = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCBrowse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBrowse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCBrowse
        '
        Me.GCBrowse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBrowse.Location = New System.Drawing.Point(0, 0)
        Me.GCBrowse.MainView = Me.GVBrowse
        Me.GCBrowse.Name = "GCBrowse"
        Me.GCBrowse.Size = New System.Drawing.Size(284, 261)
        Me.GCBrowse.TabIndex = 0
        Me.GCBrowse.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBrowse})
        '
        'GVBrowse
        '
        Me.GVBrowse.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1})
        Me.GVBrowse.GridControl = Me.GCBrowse
        Me.GVBrowse.Name = "GVBrowse"
        Me.GVBrowse.OptionsBehavior.Editable = False
        Me.GVBrowse.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Value"
        Me.GridColumn1.FieldName = "value"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'FormMasterDesignLookUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.GCBrowse)
        Me.Name = "FormMasterDesignLookUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Browse"
        CType(Me.GCBrowse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBrowse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCBrowse As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBrowse As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
