<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBankWithdrawalPPNTag
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
        Me.GCTag = New DevExpress.XtraGrid.GridControl()
        Me.GVTag = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCTag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVTag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCTag
        '
        Me.GCTag.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCTag.Location = New System.Drawing.Point(0, 0)
        Me.GCTag.MainView = Me.GVTag
        Me.GCTag.Name = "GCTag"
        Me.GCTag.Size = New System.Drawing.Size(284, 261)
        Me.GCTag.TabIndex = 0
        Me.GCTag.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVTag})
        '
        'GVTag
        '
        Me.GVTag.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.GVTag.GridControl = Me.GCTag
        Me.GVTag.Name = "GVTag"
        Me.GVTag.OptionsBehavior.Editable = False
        Me.GVTag.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "id_coa_tag"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Tag"
        Me.GridColumn2.FieldName = "tag"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'FormBankWithdrawalPPNTag
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.GCTag)
        Me.Name = "FormBankWithdrawalPPNTag"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Tag"
        CType(Me.GCTag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVTag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCTag As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVTag As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
End Class
