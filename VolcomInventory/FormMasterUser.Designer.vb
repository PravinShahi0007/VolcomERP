<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterUser
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
        Me.PCBack = New DevExpress.XtraEditors.PanelControl
        Me.GCUser = New DevExpress.XtraGrid.GridControl
        Me.GVUser = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.id_user = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnEmployeeCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnEmployeeName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.username = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnRole = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnDepartement = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIsChange = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.PCBack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCBack.SuspendLayout()
        CType(Me.GCUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PCBack
        '
        Me.PCBack.Controls.Add(Me.GCUser)
        Me.PCBack.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PCBack.Location = New System.Drawing.Point(0, 0)
        Me.PCBack.Name = "PCBack"
        Me.PCBack.Size = New System.Drawing.Size(649, 395)
        Me.PCBack.TabIndex = 0
        '
        'GCUser
        '
        Me.GCUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCUser.Location = New System.Drawing.Point(2, 2)
        Me.GCUser.MainView = Me.GVUser
        Me.GCUser.Name = "GCUser"
        Me.GCUser.Size = New System.Drawing.Size(645, 391)
        Me.GCUser.TabIndex = 4
        Me.GCUser.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVUser})
        '
        'GVUser
        '
        Me.GVUser.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.id_user, Me.ColumnEmployeeCode, Me.ColumnEmployeeName, Me.username, Me.ColumnRole, Me.ColumnDepartement, Me.GridColumnIsChange})
        Me.GVUser.GridControl = Me.GCUser
        Me.GVUser.Name = "GVUser"
        Me.GVUser.OptionsBehavior.Editable = False
        Me.GVUser.OptionsView.ShowGroupPanel = False
        '
        'id_user
        '
        Me.id_user.Caption = "ID"
        Me.id_user.FieldName = "id_user"
        Me.id_user.Name = "id_user"
        '
        'ColumnEmployeeCode
        '
        Me.ColumnEmployeeCode.Caption = "Employee Code"
        Me.ColumnEmployeeCode.FieldName = "employee_code"
        Me.ColumnEmployeeCode.Name = "ColumnEmployeeCode"
        Me.ColumnEmployeeCode.Visible = True
        Me.ColumnEmployeeCode.VisibleIndex = 0
        '
        'ColumnEmployeeName
        '
        Me.ColumnEmployeeName.Caption = "Employee Name"
        Me.ColumnEmployeeName.FieldName = "employee_name"
        Me.ColumnEmployeeName.Name = "ColumnEmployeeName"
        Me.ColumnEmployeeName.Visible = True
        Me.ColumnEmployeeName.VisibleIndex = 1
        '
        'username
        '
        Me.username.Caption = "Username"
        Me.username.FieldName = "username"
        Me.username.Name = "username"
        Me.username.Visible = True
        Me.username.VisibleIndex = 3
        Me.username.Width = 174
        '
        'ColumnRole
        '
        Me.ColumnRole.Caption = "Role"
        Me.ColumnRole.FieldName = "role"
        Me.ColumnRole.Name = "ColumnRole"
        Me.ColumnRole.Visible = True
        Me.ColumnRole.VisibleIndex = 4
        '
        'ColumnDepartement
        '
        Me.ColumnDepartement.Caption = "Departement"
        Me.ColumnDepartement.FieldName = "departement"
        Me.ColumnDepartement.Name = "ColumnDepartement"
        Me.ColumnDepartement.Visible = True
        Me.ColumnDepartement.VisibleIndex = 2
        '
        'GridColumnIsChange
        '
        Me.GridColumnIsChange.Caption = "Change Password"
        Me.GridColumnIsChange.FieldName = "answer"
        Me.GridColumnIsChange.Name = "GridColumnIsChange"
        Me.GridColumnIsChange.Visible = True
        Me.GridColumnIsChange.VisibleIndex = 5
        '
        'FormMasterUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(649, 395)
        Me.Controls.Add(Me.PCBack)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterUser"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Management "
        CType(Me.PCBack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCBack.ResumeLayout(False)
        CType(Me.GCUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PCBack As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCUser As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVUser As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents id_user As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnEmployeeCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnEmployeeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents username As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnRole As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsChange As DevExpress.XtraGrid.Columns.GridColumn
End Class
