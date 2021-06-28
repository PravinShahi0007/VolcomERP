<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStockTakeStorePeriodAccount
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
        Me.GCAccount = New DevExpress.XtraGrid.GridControl()
        Me.GVAccount = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCAccount
        '
        Me.GCAccount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAccount.Location = New System.Drawing.Point(0, 0)
        Me.GCAccount.MainView = Me.GVAccount
        Me.GCAccount.Name = "GCAccount"
        Me.GCAccount.Size = New System.Drawing.Size(284, 226)
        Me.GCAccount.TabIndex = 0
        Me.GCAccount.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAccount})
        '
        'GVAccount
        '
        Me.GVAccount.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.GVAccount.GridControl = Me.GCAccount
        Me.GVAccount.Name = "GVAccount"
        Me.GVAccount.OptionsBehavior.Editable = False
        Me.GVAccount.OptionsView.ShowGroupPanel = False
        '
        'SBSave
        '
        Me.SBSave.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SBSave.Location = New System.Drawing.Point(0, 226)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(284, 35)
        Me.SBSave.TabIndex = 1
        Me.SBSave.Text = "Save"
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "id_comp"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Account"
        Me.GridColumn2.FieldName = "comp_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'FormStockTakeStorePeriodAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.GCAccount)
        Me.Controls.Add(Me.SBSave)
        Me.Name = "FormStockTakeStorePeriodAccount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Account"
        CType(Me.GCAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAccount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCAccount As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAccount As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
End Class
