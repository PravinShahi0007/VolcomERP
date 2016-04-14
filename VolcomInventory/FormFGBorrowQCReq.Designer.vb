<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGBorrowQCReq
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
        Me.GCBorrowReq = New DevExpress.XtraGrid.GridControl()
        Me.GVBorrowReq = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBorrowReqQCNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBorrowReqUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBorrowReqNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBorrowReqDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBorrowReQDateRet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBorrowReqStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnApplicant = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnApplicantDept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDuration = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCBorrowReq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBorrowReq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCBorrowReq
        '
        Me.GCBorrowReq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBorrowReq.Location = New System.Drawing.Point(0, 0)
        Me.GCBorrowReq.MainView = Me.GVBorrowReq
        Me.GCBorrowReq.Name = "GCBorrowReq"
        Me.GCBorrowReq.Size = New System.Drawing.Size(764, 386)
        Me.GCBorrowReq.TabIndex = 0
        Me.GCBorrowReq.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBorrowReq})
        '
        'GVBorrowReq
        '
        Me.GVBorrowReq.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumnBorrowReqQCNote, Me.GridColumnBorrowReqUser, Me.GridColumnBorrowReqNumber, Me.GridColumnBorrowReqDate, Me.GridColumnBorrowReQDateRet, Me.GridColumnBorrowReqStatus, Me.GridColumnApplicant, Me.GridColumnApplicantDept, Me.GridColumnDuration})
        Me.GVBorrowReq.GridControl = Me.GCBorrowReq
        Me.GVBorrowReq.Name = "GVBorrowReq"
        Me.GVBorrowReq.OptionsView.ShowGroupPanel = False
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "Id Borrow Req"
        Me.GridColumnId.FieldName = "id_borrow_qc_req"
        Me.GridColumnId.Name = "GridColumnId"
        '
        'GridColumnBorrowReqQCNote
        '
        Me.GridColumnBorrowReqQCNote.Caption = "Note"
        Me.GridColumnBorrowReqQCNote.FieldName = "borrow_qc_rec_note"
        Me.GridColumnBorrowReqQCNote.Name = "GridColumnBorrowReqQCNote"
        '
        'GridColumnBorrowReqUser
        '
        Me.GridColumnBorrowReqUser.Caption = "User"
        Me.GridColumnBorrowReqUser.FieldName = "borrow_qc_req_user"
        Me.GridColumnBorrowReqUser.Name = "GridColumnBorrowReqUser"
        '
        'GridColumnBorrowReqNumber
        '
        Me.GridColumnBorrowReqNumber.Caption = "Number"
        Me.GridColumnBorrowReqNumber.FieldName = "borrow_qc_req_number"
        Me.GridColumnBorrowReqNumber.Name = "GridColumnBorrowReqNumber"
        Me.GridColumnBorrowReqNumber.Visible = True
        Me.GridColumnBorrowReqNumber.VisibleIndex = 0
        '
        'GridColumnBorrowReqDate
        '
        Me.GridColumnBorrowReqDate.Caption = "Date"
        Me.GridColumnBorrowReqDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnBorrowReqDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnBorrowReqDate.FieldName = "borrow_qc_req_date"
        Me.GridColumnBorrowReqDate.Name = "GridColumnBorrowReqDate"
        Me.GridColumnBorrowReqDate.Visible = True
        Me.GridColumnBorrowReqDate.VisibleIndex = 4
        '
        'GridColumnBorrowReQDateRet
        '
        Me.GridColumnBorrowReQDateRet.Caption = "Return Date"
        Me.GridColumnBorrowReQDateRet.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnBorrowReQDateRet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnBorrowReQDateRet.FieldName = "borrow_qc_req_date_ret"
        Me.GridColumnBorrowReQDateRet.Name = "GridColumnBorrowReQDateRet"
        Me.GridColumnBorrowReQDateRet.Visible = True
        Me.GridColumnBorrowReQDateRet.VisibleIndex = 5
        '
        'GridColumnBorrowReqStatus
        '
        Me.GridColumnBorrowReqStatus.Caption = "Status"
        Me.GridColumnBorrowReqStatus.FieldName = "report_status"
        Me.GridColumnBorrowReqStatus.FieldNameSortGroup = "id_report_status"
        Me.GridColumnBorrowReqStatus.Name = "GridColumnBorrowReqStatus"
        Me.GridColumnBorrowReqStatus.Visible = True
        Me.GridColumnBorrowReqStatus.VisibleIndex = 6
        '
        'GridColumnApplicant
        '
        Me.GridColumnApplicant.Caption = "Applicant"
        Me.GridColumnApplicant.FieldName = "employee_name"
        Me.GridColumnApplicant.Name = "GridColumnApplicant"
        Me.GridColumnApplicant.Visible = True
        Me.GridColumnApplicant.VisibleIndex = 1
        '
        'GridColumnApplicantDept
        '
        Me.GridColumnApplicantDept.Caption = "Applicant Dept."
        Me.GridColumnApplicantDept.FieldName = "departement"
        Me.GridColumnApplicantDept.FieldNameSortGroup = "id_departement"
        Me.GridColumnApplicantDept.Name = "GridColumnApplicantDept"
        Me.GridColumnApplicantDept.Visible = True
        Me.GridColumnApplicantDept.VisibleIndex = 2
        '
        'GridColumnDuration
        '
        Me.GridColumnDuration.Caption = "Duration (day)"
        Me.GridColumnDuration.FieldName = "borrow_qc_req_duration"
        Me.GridColumnDuration.Name = "GridColumnDuration"
        Me.GridColumnDuration.Visible = True
        Me.GridColumnDuration.VisibleIndex = 3
        '
        'FormFGBorrowQCReq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 386)
        Me.Controls.Add(Me.GCBorrowReq)
        Me.Name = "FormFGBorrowQCReq"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Borrow Request"
        CType(Me.GCBorrowReq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBorrowReq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCBorrowReq As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBorrowReq As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBorrowReqQCNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBorrowReqUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBorrowReqNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBorrowReqDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBorrowReQDateRet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBorrowReqStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnApplicant As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnApplicantDept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDuration As DevExpress.XtraGrid.Columns.GridColumn
End Class
