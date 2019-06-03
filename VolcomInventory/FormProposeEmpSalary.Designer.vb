<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProposeEmpSalary
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
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCIdEmployeeSalPps = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEffectiveDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCCreatedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCCreatedAt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCType = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(0, 0)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.Size = New System.Drawing.Size(784, 561)
        Me.GCList.TabIndex = 0
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCIdEmployeeSalPps, Me.GCNumber, Me.GCType, Me.GCEffectiveDate, Me.GCNote, Me.GCStatus, Me.GCCreatedBy, Me.GCCreatedAt})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsBehavior.Editable = False
        Me.GVList.OptionsFind.AlwaysVisible = True
        Me.GVList.OptionsView.ShowGroupPanel = False
        '
        'GCIdEmployeeSalPps
        '
        Me.GCIdEmployeeSalPps.FieldName = "id_employee_sal_pps"
        Me.GCIdEmployeeSalPps.Name = "GCIdEmployeeSalPps"
        '
        'GCNumber
        '
        Me.GCNumber.Caption = "Number"
        Me.GCNumber.FieldName = "number"
        Me.GCNumber.Name = "GCNumber"
        Me.GCNumber.Visible = True
        Me.GCNumber.VisibleIndex = 0
        '
        'GCEffectiveDate
        '
        Me.GCEffectiveDate.Caption = "Effective Date"
        Me.GCEffectiveDate.FieldName = "effective_date"
        Me.GCEffectiveDate.Name = "GCEffectiveDate"
        Me.GCEffectiveDate.Visible = True
        Me.GCEffectiveDate.VisibleIndex = 2
        '
        'GCNote
        '
        Me.GCNote.Caption = "Note"
        Me.GCNote.FieldName = "note"
        Me.GCNote.Name = "GCNote"
        Me.GCNote.Visible = True
        Me.GCNote.VisibleIndex = 3
        '
        'GCStatus
        '
        Me.GCStatus.Caption = "Status"
        Me.GCStatus.FieldName = "report_status"
        Me.GCStatus.Name = "GCStatus"
        Me.GCStatus.Visible = True
        Me.GCStatus.VisibleIndex = 4
        '
        'GCCreatedBy
        '
        Me.GCCreatedBy.Caption = "Created By"
        Me.GCCreatedBy.FieldName = "created_by"
        Me.GCCreatedBy.Name = "GCCreatedBy"
        Me.GCCreatedBy.Visible = True
        Me.GCCreatedBy.VisibleIndex = 5
        '
        'GCCreatedAt
        '
        Me.GCCreatedAt.Caption = "Created At"
        Me.GCCreatedAt.FieldName = "created_at"
        Me.GCCreatedAt.Name = "GCCreatedAt"
        Me.GCCreatedAt.Visible = True
        Me.GCCreatedAt.VisibleIndex = 6
        '
        'GCType
        '
        Me.GCType.Caption = "Type"
        Me.GCType.FieldName = "sal_pps_type"
        Me.GCType.Name = "GCType"
        Me.GCType.Visible = True
        Me.GCType.VisibleIndex = 1
        '
        'FormProposeEmpSalary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCList)
        Me.Name = "FormProposeEmpSalary"
        Me.Text = "Propose Employee Salary"
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCIdEmployeeSalPps As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEffectiveDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCCreatedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCCreatedAt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCType As DevExpress.XtraGrid.Columns.GridColumn
End Class
