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
        Me.GridColumnGroup = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MEValue = New DevExpress.XtraEditors.MemoEdit()
        Me.SBAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        CType(Me.GCBrowse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBrowse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEValue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GCBrowse
        '
        Me.GCBrowse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBrowse.Location = New System.Drawing.Point(2, 20)
        Me.GCBrowse.MainView = Me.GVBrowse
        Me.GCBrowse.Name = "GCBrowse"
        Me.GCBrowse.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit})
        Me.GCBrowse.Size = New System.Drawing.Size(580, 325)
        Me.GCBrowse.TabIndex = 0
        Me.GCBrowse.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBrowse})
        '
        'GVBrowse
        '
        Me.GVBrowse.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnGroup, Me.GridColumnValue})
        Me.GVBrowse.GridControl = Me.GCBrowse
        Me.GVBrowse.Name = "GVBrowse"
        Me.GVBrowse.OptionsBehavior.Editable = False
        Me.GVBrowse.OptionsView.RowAutoHeight = True
        Me.GVBrowse.OptionsView.ShowGroupPanel = False
        '
        'GridColumnGroup
        '
        Me.GridColumnGroup.Caption = "Column Group"
        Me.GridColumnGroup.FieldName = "column_group"
        Me.GridColumnGroup.Name = "GridColumnGroup"
        Me.GridColumnGroup.Visible = True
        Me.GridColumnGroup.VisibleIndex = 0
        '
        'GridColumnValue
        '
        Me.GridColumnValue.Caption = "Value"
        Me.GridColumnValue.ColumnEdit = Me.RepositoryItemMemoEdit
        Me.GridColumnValue.FieldName = "value"
        Me.GridColumnValue.Name = "GridColumnValue"
        Me.GridColumnValue.Visible = True
        Me.GridColumnValue.VisibleIndex = 1
        '
        'RepositoryItemMemoEdit
        '
        Me.RepositoryItemMemoEdit.Name = "RepositoryItemMemoEdit"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Value"
        '
        'MEValue
        '
        Me.MEValue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MEValue.Location = New System.Drawing.Point(12, 57)
        Me.MEValue.Name = "MEValue"
        Me.MEValue.Size = New System.Drawing.Size(560, 116)
        Me.MEValue.TabIndex = 1
        '
        'SBAdd
        '
        Me.SBAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBAdd.Location = New System.Drawing.Point(497, 179)
        Me.SBAdd.Name = "SBAdd"
        Me.SBAdd.Size = New System.Drawing.Size(75, 23)
        Me.SBAdd.TabIndex = 2
        Me.SBAdd.Text = "Add"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.SBAdd)
        Me.GroupControl1.Controls.Add(Me.MEValue)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl1.Location = New System.Drawing.Point(0, 347)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(584, 214)
        Me.GroupControl1.TabIndex = 2
        Me.GroupControl1.Text = "New Value"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.GCBrowse)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(584, 347)
        Me.GroupControl2.TabIndex = 3
        Me.GroupControl2.Text = "Default Value"
        '
        'FormMasterDesignLookUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 561)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "FormMasterDesignLookUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Browse"
        CType(Me.GCBrowse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBrowse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEValue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCBrowse As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBrowse As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents GridColumnGroup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SBAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents MEValue As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
End Class
