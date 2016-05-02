<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSampleReq
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
        Me.GCReq = New DevExpress.XtraGrid.GridControl()
        Me.GVReq = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdSampleReq = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRetOutNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFromUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColShipFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColShipTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDuration = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRecDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNotes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProgress = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PBCProg = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.GridColumnDivision = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCReq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVReq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBCProg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCReq
        '
        Me.GCReq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCReq.Location = New System.Drawing.Point(0, 0)
        Me.GCReq.MainView = Me.GVReq
        Me.GCReq.Name = "GCReq"
        Me.GCReq.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.PBCProg})
        Me.GCReq.Size = New System.Drawing.Size(775, 437)
        Me.GCReq.TabIndex = 4
        Me.GCReq.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVReq})
        '
        'GVReq
        '
        Me.GVReq.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdSampleReq, Me.ColRetOutNumber, Me.GridColumnFromUser, Me.GridColumnDepartement, Me.ColShipFrom, Me.ColShipTo, Me.ColDuration, Me.ColRecDate, Me.GridColumnNotes, Me.GridColumnStatus, Me.GridColumnProgress, Me.GridColumnDivision})
        Me.GVReq.GridControl = Me.GCReq
        Me.GVReq.Name = "GVReq"
        Me.GVReq.OptionsBehavior.Editable = False
        Me.GVReq.OptionsView.ShowGroupPanel = False
        '
        'ColIdSampleReq
        '
        Me.ColIdSampleReq.Caption = "ID Sample Req"
        Me.ColIdSampleReq.FieldName = "id_sample_requisition"
        Me.ColIdSampleReq.Name = "ColIdSampleReq"
        '
        'ColRetOutNumber
        '
        Me.ColRetOutNumber.Caption = "Number"
        Me.ColRetOutNumber.FieldName = "sample_requisition_number"
        Me.ColRetOutNumber.Name = "ColRetOutNumber"
        Me.ColRetOutNumber.Visible = True
        Me.ColRetOutNumber.VisibleIndex = 0
        Me.ColRetOutNumber.Width = 101
        '
        'GridColumnFromUser
        '
        Me.GridColumnFromUser.Caption = "From"
        Me.GridColumnFromUser.FieldName = "employee_name"
        Me.GridColumnFromUser.Name = "GridColumnFromUser"
        Me.GridColumnFromUser.Visible = True
        Me.GridColumnFromUser.VisibleIndex = 2
        '
        'GridColumnDepartement
        '
        Me.GridColumnDepartement.Caption = "Departement"
        Me.GridColumnDepartement.FieldName = "departement"
        Me.GridColumnDepartement.Name = "GridColumnDepartement"
        Me.GridColumnDepartement.Visible = True
        Me.GridColumnDepartement.VisibleIndex = 3
        '
        'ColShipFrom
        '
        Me.ColShipFrom.Caption = "Ship To"
        Me.ColShipFrom.FieldName = "comp_from"
        Me.ColShipFrom.Name = "ColShipFrom"
        Me.ColShipFrom.Visible = True
        Me.ColShipFrom.VisibleIndex = 4
        Me.ColShipFrom.Width = 197
        '
        'ColShipTo
        '
        Me.ColShipTo.Caption = "To"
        Me.ColShipTo.FieldName = "comp_to"
        Me.ColShipTo.Name = "ColShipTo"
        Me.ColShipTo.Width = 142
        '
        'ColDuration
        '
        Me.ColDuration.Caption = "Duration of use (day)"
        Me.ColDuration.FieldName = "sample_requisition_duration"
        Me.ColDuration.Name = "ColDuration"
        Me.ColDuration.Visible = True
        Me.ColDuration.VisibleIndex = 5
        Me.ColDuration.Width = 120
        '
        'ColRecDate
        '
        Me.ColRecDate.Caption = "Created Date"
        Me.ColRecDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.ColRecDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColRecDate.FieldName = "sample_requisition_date"
        Me.ColRecDate.Name = "ColRecDate"
        Me.ColRecDate.Visible = True
        Me.ColRecDate.VisibleIndex = 6
        Me.ColRecDate.Width = 170
        '
        'GridColumnNotes
        '
        Me.GridColumnNotes.Caption = "Notes"
        Me.GridColumnNotes.FieldName = "sample_requisition_note"
        Me.GridColumnNotes.Name = "GridColumnNotes"
        Me.GridColumnNotes.Visible = True
        Me.GridColumnNotes.VisibleIndex = 7
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 8
        Me.GridColumnStatus.Width = 101
        '
        'GridColumnProgress
        '
        Me.GridColumnProgress.Caption = "Completness"
        Me.GridColumnProgress.ColumnEdit = Me.PBCProg
        Me.GridColumnProgress.FieldName = "progress_req"
        Me.GridColumnProgress.Name = "GridColumnProgress"
        Me.GridColumnProgress.Visible = True
        Me.GridColumnProgress.VisibleIndex = 9
        '
        'PBCProg
        '
        Me.PBCProg.LookAndFeel.SkinName = "The Asphalt World"
        Me.PBCProg.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PBCProg.Name = "PBCProg"
        Me.PBCProg.ShowTitle = True
        Me.PBCProg.StartColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'GridColumnDivision
        '
        Me.GridColumnDivision.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnDivision.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnDivision.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnDivision.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnDivision.Caption = "Division"
        Me.GridColumnDivision.FieldName = "division"
        Me.GridColumnDivision.Name = "GridColumnDivision"
        Me.GridColumnDivision.Visible = True
        Me.GridColumnDivision.VisibleIndex = 1
        '
        'FormSampleReq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(775, 437)
        Me.Controls.Add(Me.GCReq)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSampleReq"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sample Borrow Requisition"
        CType(Me.GCReq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVReq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBCProg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCReq As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVReq As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdSampleReq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRetOutNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDuration As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFromUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNotes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProgress As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PBCProg As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents GridColumnDivision As DevExpress.XtraGrid.Columns.GridColumn
End Class
