<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDesignColumnBrowse
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GVBrowse = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCBrowse = New DevExpress.XtraGrid.GridControl()
        CType(Me.GVBrowse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCBrowse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GVBrowse
        '
        Me.GVBrowse.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnValue})
        Me.GVBrowse.GridControl = Me.GCBrowse
        Me.GVBrowse.Name = "GVBrowse"
        Me.GVBrowse.OptionsBehavior.Editable = False
        Me.GVBrowse.OptionsView.ShowGroupPanel = False
        '
        'GridColumnValue
        '
        Me.GridColumnValue.Caption = "Value"
        Me.GridColumnValue.FieldName = "value"
        Me.GridColumnValue.Name = "GridColumnValue"
        Me.GridColumnValue.Visible = True
        Me.GridColumnValue.VisibleIndex = 0
        '
        'GCBrowse
        '
        Me.GCBrowse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBrowse.Location = New System.Drawing.Point(0, 0)
        Me.GCBrowse.MainView = Me.GVBrowse
        Me.GCBrowse.Name = "GCBrowse"
        Me.GCBrowse.Size = New System.Drawing.Size(284, 461)
        Me.GCBrowse.TabIndex = 0
        Me.GCBrowse.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBrowse})
        '
        'FormDesignColumnBrowse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 461)
        Me.Controls.Add(Me.GCBrowse)
        Me.Name = "FormDesignColumnBrowse"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Design Column Browse"
        CType(Me.GVBrowse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCBrowse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GVBrowse As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCBrowse As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridColumnValue As DevExpress.XtraGrid.Columns.GridColumn
End Class
