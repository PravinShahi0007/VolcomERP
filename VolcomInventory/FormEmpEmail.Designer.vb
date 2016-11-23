<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpEmail
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
        Me.GCEmail = New DevExpress.XtraGrid.GridControl()
        Me.GVEmail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnExtEmail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnExtEmailPass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLocEmail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLocEmailPass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOther = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOtherPass = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCEmail
        '
        Me.GCEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCEmail.Location = New System.Drawing.Point(0, 0)
        Me.GCEmail.MainView = Me.GVEmail
        Me.GCEmail.Name = "GCEmail"
        Me.GCEmail.Size = New System.Drawing.Size(667, 383)
        Me.GCEmail.TabIndex = 1
        Me.GCEmail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVEmail})
        '
        'GVEmail
        '
        Me.GVEmail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumnExtEmail, Me.GridColumnExtEmailPass, Me.GridColumnLocEmail, Me.GridColumnLocEmailPass, Me.GridColumnOther, Me.GridColumnOtherPass})
        Me.GVEmail.GridControl = Me.GCEmail
        Me.GVEmail.GroupCount = 1
        Me.GVEmail.Name = "GVEmail"
        Me.GVEmail.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVEmail.OptionsBehavior.Editable = False
        Me.GVEmail.OptionsView.ShowGroupPanel = False
        Me.GVEmail.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn2, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Name"
        Me.GridColumn1.FieldName = "employee_name"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Departement"
        Me.GridColumn2.FieldName = "departement"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumnExtEmail
        '
        Me.GridColumnExtEmail.Caption = "External Email"
        Me.GridColumnExtEmail.FieldName = "email_external"
        Me.GridColumnExtEmail.Name = "GridColumnExtEmail"
        Me.GridColumnExtEmail.Visible = True
        Me.GridColumnExtEmail.VisibleIndex = 1
        '
        'GridColumnExtEmailPass
        '
        Me.GridColumnExtEmailPass.Caption = "External Password"
        Me.GridColumnExtEmailPass.FieldName = "email_external_pass"
        Me.GridColumnExtEmailPass.Name = "GridColumnExtEmailPass"
        Me.GridColumnExtEmailPass.Visible = True
        Me.GridColumnExtEmailPass.VisibleIndex = 2
        '
        'GridColumnLocEmail
        '
        Me.GridColumnLocEmail.Caption = "Local Email"
        Me.GridColumnLocEmail.FieldName = "email_lokal"
        Me.GridColumnLocEmail.Name = "GridColumnLocEmail"
        Me.GridColumnLocEmail.Visible = True
        Me.GridColumnLocEmail.VisibleIndex = 3
        '
        'GridColumnLocEmailPass
        '
        Me.GridColumnLocEmailPass.Caption = "Local Password"
        Me.GridColumnLocEmailPass.FieldName = "email_lokal_pass"
        Me.GridColumnLocEmailPass.Name = "GridColumnLocEmailPass"
        Me.GridColumnLocEmailPass.Visible = True
        Me.GridColumnLocEmailPass.VisibleIndex = 4
        '
        'GridColumnOther
        '
        Me.GridColumnOther.Caption = "Other Email"
        Me.GridColumnOther.FieldName = "email_other"
        Me.GridColumnOther.Name = "GridColumnOther"
        Me.GridColumnOther.Visible = True
        Me.GridColumnOther.VisibleIndex = 5
        '
        'GridColumnOtherPass
        '
        Me.GridColumnOtherPass.Caption = "Other Password"
        Me.GridColumnOtherPass.FieldName = "email_other_pass"
        Me.GridColumnOtherPass.Name = "GridColumnOtherPass"
        Me.GridColumnOtherPass.Visible = True
        Me.GridColumnOtherPass.VisibleIndex = 6
        '
        'FormEmpEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 383)
        Me.Controls.Add(Me.GCEmail)
        Me.Name = "FormEmpEmail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Email List"
        CType(Me.GCEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVEmail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCEmail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVEmail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnExtEmail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnExtEmailPass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLocEmail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLocEmailPass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOther As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOtherPass As DevExpress.XtraGrid.Columns.GridColumn
End Class
