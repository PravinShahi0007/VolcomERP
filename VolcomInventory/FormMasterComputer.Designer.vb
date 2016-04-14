<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterComputer
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
        Me.GCComputer = New DevExpress.XtraGrid.GridControl()
        Me.GVComputer = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnCompName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCurrUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSpec = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdComputer = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCComputer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVComputer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCComputer
        '
        Me.GCComputer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCComputer.Location = New System.Drawing.Point(0, 0)
        Me.GCComputer.MainView = Me.GVComputer
        Me.GCComputer.Name = "GCComputer"
        Me.GCComputer.Size = New System.Drawing.Size(668, 353)
        Me.GCComputer.TabIndex = 1
        Me.GCComputer.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVComputer})
        '
        'GVComputer
        '
        Me.GVComputer.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCompName, Me.GridColumnCurrUser, Me.GridColumnIP, Me.GridColumnSpec, Me.GridColumnDept, Me.GridColumnIdComputer})
        Me.GVComputer.GridControl = Me.GCComputer
        Me.GVComputer.Name = "GVComputer"
        Me.GVComputer.OptionsBehavior.Editable = False
        Me.GVComputer.OptionsView.ShowGroupPanel = False
        Me.GVComputer.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnIdComputer, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnCompName
        '
        Me.GridColumnCompName.Caption = "PC Name"
        Me.GridColumnCompName.FieldName = "computer_name"
        Me.GridColumnCompName.Name = "GridColumnCompName"
        Me.GridColumnCompName.Visible = True
        Me.GridColumnCompName.VisibleIndex = 0
        '
        'GridColumnCurrUser
        '
        Me.GridColumnCurrUser.Caption = "Current User"
        Me.GridColumnCurrUser.FieldName = "computer_user"
        Me.GridColumnCurrUser.Name = "GridColumnCurrUser"
        Me.GridColumnCurrUser.Visible = True
        Me.GridColumnCurrUser.VisibleIndex = 1
        '
        'GridColumnIP
        '
        Me.GridColumnIP.Caption = "IP Address"
        Me.GridColumnIP.FieldName = "computer_ip"
        Me.GridColumnIP.Name = "GridColumnIP"
        Me.GridColumnIP.Visible = True
        Me.GridColumnIP.VisibleIndex = 2
        '
        'GridColumnSpec
        '
        Me.GridColumnSpec.Caption = "Spec"
        Me.GridColumnSpec.FieldName = "computer_spec"
        Me.GridColumnSpec.Name = "GridColumnSpec"
        Me.GridColumnSpec.Visible = True
        Me.GridColumnSpec.VisibleIndex = 3
        '
        'GridColumnDept
        '
        Me.GridColumnDept.Caption = "Dept"
        Me.GridColumnDept.FieldName = "computer_dept"
        Me.GridColumnDept.Name = "GridColumnDept"
        Me.GridColumnDept.Visible = True
        Me.GridColumnDept.VisibleIndex = 4
        '
        'GridColumnIdComputer
        '
        Me.GridColumnIdComputer.Caption = "Id Computer"
        Me.GridColumnIdComputer.FieldName = "id_computer"
        Me.GridColumnIdComputer.Name = "GridColumnIdComputer"
        '
        'FormMasterComputer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 353)
        Me.Controls.Add(Me.GCComputer)
        Me.Name = "FormMasterComputer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormMasterComputer"
        CType(Me.GCComputer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVComputer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCComputer As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVComputer As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCurrUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSpec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdComputer As DevExpress.XtraGrid.Columns.GridColumn
End Class
