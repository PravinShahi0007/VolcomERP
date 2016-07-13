<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterEmployee
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
        Me.GCEmployee = New DevExpress.XtraGrid.GridControl()
        Me.GVEmployee = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnLevel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnReligion = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnEmployeeStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnJoinDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDegree = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnEmployeeDOB = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnAge = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBandGeneral = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCEmployee
        '
        Me.GCEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCEmployee.Location = New System.Drawing.Point(0, 0)
        Me.GCEmployee.MainView = Me.GVEmployee
        Me.GCEmployee.Name = "GCEmployee"
        Me.GCEmployee.Size = New System.Drawing.Size(734, 499)
        Me.GCEmployee.TabIndex = 0
        Me.GCEmployee.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVEmployee})
        '
        'GVEmployee
        '
        Me.GVEmployee.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBandGeneral})
        Me.GVEmployee.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumn2, Me.GridColumn1, Me.GridColumn3, Me.GridColumn4, Me.BandedGridColumnLevel, Me.BandedGridColumnReligion, Me.BandedGridColumnEmployeeStatus, Me.BandedGridColumnJoinDate, Me.BandedGridColumnDegree, Me.BandedGridColumnEmployeeDOB, Me.BandedGridColumnAge})
        Me.GVEmployee.GridControl = Me.GCEmployee
        Me.GVEmployee.Name = "GVEmployee"
        Me.GVEmployee.OptionsBehavior.ReadOnly = True
        Me.GVEmployee.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Code"
        Me.GridColumn2.FieldName = "employee_code"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.Width = 83
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Name"
        Me.GridColumn1.FieldName = "employee_name"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.Width = 83
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Sex"
        Me.GridColumn3.FieldName = "sex"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.Width = 83
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Departement"
        Me.GridColumn4.FieldName = "departement"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.Width = 83
        '
        'BandedGridColumnLevel
        '
        Me.BandedGridColumnLevel.Caption = "Level"
        Me.BandedGridColumnLevel.FieldName = "employee_level"
        Me.BandedGridColumnLevel.Name = "BandedGridColumnLevel"
        Me.BandedGridColumnLevel.Visible = True
        Me.BandedGridColumnLevel.Width = 83
        '
        'BandedGridColumnReligion
        '
        Me.BandedGridColumnReligion.Caption = "Religion"
        Me.BandedGridColumnReligion.FieldName = "religion"
        Me.BandedGridColumnReligion.Name = "BandedGridColumnReligion"
        Me.BandedGridColumnReligion.Visible = True
        Me.BandedGridColumnReligion.Width = 83
        '
        'BandedGridColumnEmployeeStatus
        '
        Me.BandedGridColumnEmployeeStatus.Caption = "Employee Status"
        Me.BandedGridColumnEmployeeStatus.FieldName = "employee_status"
        Me.BandedGridColumnEmployeeStatus.Name = "BandedGridColumnEmployeeStatus"
        Me.BandedGridColumnEmployeeStatus.Visible = True
        Me.BandedGridColumnEmployeeStatus.Width = 92
        '
        'BandedGridColumnJoinDate
        '
        Me.BandedGridColumnJoinDate.Caption = "Join Date"
        Me.BandedGridColumnJoinDate.FieldName = "employee_join_date"
        Me.BandedGridColumnJoinDate.Name = "BandedGridColumnJoinDate"
        Me.BandedGridColumnJoinDate.Visible = True
        '
        'BandedGridColumnDegree
        '
        Me.BandedGridColumnDegree.Caption = "Degree"
        Me.BandedGridColumnDegree.FieldName = "education"
        Me.BandedGridColumnDegree.Name = "BandedGridColumnDegree"
        Me.BandedGridColumnDegree.Visible = True
        '
        'BandedGridColumnEmployeeDOB
        '
        Me.BandedGridColumnEmployeeDOB.Caption = "DOB"
        Me.BandedGridColumnEmployeeDOB.FieldName = "employee_dob"
        Me.BandedGridColumnEmployeeDOB.Name = "BandedGridColumnEmployeeDOB"
        Me.BandedGridColumnEmployeeDOB.Visible = True
        '
        'BandedGridColumnAge
        '
        Me.BandedGridColumnAge.Caption = "Age"
        Me.BandedGridColumnAge.FieldName = "age"
        Me.BandedGridColumnAge.Name = "BandedGridColumnAge"
        Me.BandedGridColumnAge.Visible = True
        '
        'GridBandGeneral
        '
        Me.GridBandGeneral.Caption = "General"
        Me.GridBandGeneral.Columns.Add(Me.GridColumn2)
        Me.GridBandGeneral.Columns.Add(Me.GridColumn1)
        Me.GridBandGeneral.Columns.Add(Me.GridColumn3)
        Me.GridBandGeneral.Columns.Add(Me.GridColumn4)
        Me.GridBandGeneral.Columns.Add(Me.BandedGridColumnLevel)
        Me.GridBandGeneral.Columns.Add(Me.BandedGridColumnReligion)
        Me.GridBandGeneral.Columns.Add(Me.BandedGridColumnEmployeeStatus)
        Me.GridBandGeneral.Columns.Add(Me.BandedGridColumnJoinDate)
        Me.GridBandGeneral.Columns.Add(Me.BandedGridColumnDegree)
        Me.GridBandGeneral.Columns.Add(Me.BandedGridColumnEmployeeDOB)
        Me.GridBandGeneral.Columns.Add(Me.BandedGridColumnAge)
        Me.GridBandGeneral.Name = "GridBandGeneral"
        Me.GridBandGeneral.VisibleIndex = 0
        Me.GridBandGeneral.Width = 890
        '
        'FormMasterEmployee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 499)
        Me.Controls.Add(Me.GCEmployee)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterEmployee"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employee"
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCEmployee As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVEmployee As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBandGeneral As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnLevel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnReligion As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnEmployeeStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJoinDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDegree As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnEmployeeDOB As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnAge As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
