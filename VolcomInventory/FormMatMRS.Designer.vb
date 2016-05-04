<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMatMRS
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
        Me.XTCMRS = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPOther = New DevExpress.XtraTab.XtraTabPage()
        Me.GCMRS = New DevExpress.XtraGrid.GridControl()
        Me.GVMRS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdMRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdCompReqFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompReqFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdCompReqTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompReqTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMRSNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdReport = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColMRSType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemProgressBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.XTPWO = New DevExpress.XtraTab.XtraTabPage()
        Me.GCMRSWO = New DevExpress.XtraGrid.GridControl()
        Me.GVMRSWO = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdMRSTypeWO = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCMRS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCMRS.SuspendLayout()
        Me.XTPOther.SuspendLayout()
        CType(Me.GCMRS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMRS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPWO.SuspendLayout()
        CType(Me.GCMRSWO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMRSWO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCMRS
        '
        Me.XTCMRS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCMRS.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right
        Me.XTCMRS.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal
        Me.XTCMRS.Location = New System.Drawing.Point(0, 0)
        Me.XTCMRS.Name = "XTCMRS"
        Me.XTCMRS.SelectedTabPage = Me.XTPOther
        Me.XTCMRS.Size = New System.Drawing.Size(809, 362)
        Me.XTCMRS.TabIndex = 12
        Me.XTCMRS.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPWO, Me.XTPOther})
        '
        'XTPOther
        '
        Me.XTPOther.Controls.Add(Me.GCMRS)
        Me.XTPOther.Name = "XTPOther"
        Me.XTPOther.Size = New System.Drawing.Size(692, 356)
        Me.XTPOther.Text = "Other"
        '
        'GCMRS
        '
        Me.GCMRS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMRS.Location = New System.Drawing.Point(0, 0)
        Me.GCMRS.MainView = Me.GVMRS
        Me.GCMRS.Name = "GCMRS"
        Me.GCMRS.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemProgressBar1})
        Me.GCMRS.Size = New System.Drawing.Size(692, 356)
        Me.GCMRS.TabIndex = 10
        Me.GCMRS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMRS})
        '
        'GVMRS
        '
        Me.GVMRS.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdMRS, Me.GridColumnIdCompReqFrom, Me.GridColumnCompReqFrom, Me.GridColumnIdCompReqTo, Me.GridColumnCompReqTo, Me.GridColumnDate, Me.GridColumnStatus, Me.GridColumnMRSNumber, Me.GridColumnIdReport, Me.ColMRSType})
        Me.GVMRS.GridControl = Me.GCMRS
        Me.GVMRS.Name = "GVMRS"
        Me.GVMRS.OptionsBehavior.Editable = False
        Me.GVMRS.OptionsFind.AlwaysVisible = True
        Me.GVMRS.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdMRS
        '
        Me.GridColumnIdMRS.Caption = "Id MRS"
        Me.GridColumnIdMRS.FieldName = "id_prod_order_mrs"
        Me.GridColumnIdMRS.Name = "GridColumnIdMRS"
        '
        'GridColumnIdCompReqFrom
        '
        Me.GridColumnIdCompReqFrom.Caption = "Id Comp From"
        Me.GridColumnIdCompReqFrom.FieldName = "id_comp_name_req_from"
        Me.GridColumnIdCompReqFrom.Name = "GridColumnIdCompReqFrom"
        '
        'GridColumnCompReqFrom
        '
        Me.GridColumnCompReqFrom.Caption = "From"
        Me.GridColumnCompReqFrom.FieldName = "comp_name_req_from"
        Me.GridColumnCompReqFrom.Name = "GridColumnCompReqFrom"
        Me.GridColumnCompReqFrom.Visible = True
        Me.GridColumnCompReqFrom.VisibleIndex = 1
        Me.GridColumnCompReqFrom.Width = 214
        '
        'GridColumnIdCompReqTo
        '
        Me.GridColumnIdCompReqTo.Caption = "Id Comp To"
        Me.GridColumnIdCompReqTo.FieldName = "id_comp_name_req_to"
        Me.GridColumnIdCompReqTo.Name = "GridColumnIdCompReqTo"
        '
        'GridColumnCompReqTo
        '
        Me.GridColumnCompReqTo.Caption = "To"
        Me.GridColumnCompReqTo.FieldName = "comp_name_req_to"
        Me.GridColumnCompReqTo.Name = "GridColumnCompReqTo"
        Me.GridColumnCompReqTo.Visible = True
        Me.GridColumnCompReqTo.VisibleIndex = 2
        Me.GridColumnCompReqTo.Width = 214
        '
        'GridColumnDate
        '
        Me.GridColumnDate.Caption = "Date"
        Me.GridColumnDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDate.FieldName = "prod_order_mrs_date"
        Me.GridColumnDate.Name = "GridColumnDate"
        Me.GridColumnDate.Visible = True
        Me.GridColumnDate.VisibleIndex = 3
        Me.GridColumnDate.Width = 129
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 4
        Me.GridColumnStatus.Width = 96
        '
        'GridColumnMRSNumber
        '
        Me.GridColumnMRSNumber.Caption = "Number"
        Me.GridColumnMRSNumber.FieldName = "prod_order_mrs_number"
        Me.GridColumnMRSNumber.Name = "GridColumnMRSNumber"
        Me.GridColumnMRSNumber.Visible = True
        Me.GridColumnMRSNumber.VisibleIndex = 0
        Me.GridColumnMRSNumber.Width = 150
        '
        'GridColumnIdReport
        '
        Me.GridColumnIdReport.Caption = "Id Report Status"
        Me.GridColumnIdReport.FieldName = "id_report_status"
        Me.GridColumnIdReport.Name = "GridColumnIdReport"
        '
        'ColMRSType
        '
        Me.ColMRSType.Caption = "MRS Type"
        Me.ColMRSType.FieldName = "mrs_type"
        Me.ColMRSType.Name = "ColMRSType"
        '
        'RepositoryItemProgressBar1
        '
        Me.RepositoryItemProgressBar1.Appearance.BackColor = System.Drawing.Color.Lime
        Me.RepositoryItemProgressBar1.EndColor = System.Drawing.Color.Green
        Me.RepositoryItemProgressBar1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.RepositoryItemProgressBar1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.RepositoryItemProgressBar1.Name = "RepositoryItemProgressBar1"
        Me.RepositoryItemProgressBar1.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
        Me.RepositoryItemProgressBar1.ShowTitle = True
        Me.RepositoryItemProgressBar1.StartColor = System.Drawing.Color.Green
        Me.RepositoryItemProgressBar1.Step = 1
        '
        'XTPWO
        '
        Me.XTPWO.Controls.Add(Me.GCMRSWO)
        Me.XTPWO.Name = "XTPWO"
        Me.XTPWO.Size = New System.Drawing.Size(692, 356)
        Me.XTPWO.Text = "Material Work Order"
        '
        'GCMRSWO
        '
        Me.GCMRSWO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMRSWO.Location = New System.Drawing.Point(0, 0)
        Me.GCMRSWO.MainView = Me.GVMRSWO
        Me.GCMRSWO.Name = "GCMRSWO"
        Me.GCMRSWO.Size = New System.Drawing.Size(692, 356)
        Me.GCMRSWO.TabIndex = 11
        Me.GCMRSWO.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMRSWO})
        '
        'GVMRSWO
        '
        Me.GVMRSWO.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.ColIdMRSTypeWO})
        Me.GVMRSWO.GridControl = Me.GCMRSWO
        Me.GVMRSWO.Name = "GVMRSWO"
        Me.GVMRSWO.OptionsBehavior.Editable = False
        Me.GVMRSWO.OptionsFind.AlwaysVisible = True
        Me.GVMRSWO.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id MRS"
        Me.GridColumn1.FieldName = "id_prod_order_mrs"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Id Comp From"
        Me.GridColumn2.FieldName = "id_comp_name_req_from"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "From"
        Me.GridColumn3.FieldName = "comp_name_req_from"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 214
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Id Comp To"
        Me.GridColumn4.FieldName = "id_comp_name_req_to"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "To"
        Me.GridColumn5.FieldName = "comp_name_req_to"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        Me.GridColumn5.Width = 214
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Date"
        Me.GridColumn6.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn6.FieldName = "prod_order_mrs_date"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 3
        Me.GridColumn6.Width = 129
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Status"
        Me.GridColumn7.FieldName = "report_status"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 4
        Me.GridColumn7.Width = 96
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Number"
        Me.GridColumn8.FieldName = "prod_order_mrs_number"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 0
        Me.GridColumn8.Width = 150
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Id Report Status"
        Me.GridColumn9.FieldName = "id_report_status"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'ColIdMRSTypeWO
        '
        Me.ColIdMRSTypeWO.Caption = "MRS Type"
        Me.ColIdMRSTypeWO.FieldName = "mrs_type"
        Me.ColIdMRSTypeWO.Name = "ColIdMRSTypeWO"
        '
        'FormMatMRS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 362)
        Me.Controls.Add(Me.XTCMRS)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMatMRS"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Material Requisition"
        CType(Me.XTCMRS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCMRS.ResumeLayout(False)
        Me.XTPOther.ResumeLayout(False)
        CType(Me.GCMRS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMRS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPWO.ResumeLayout(False)
        CType(Me.GCMRSWO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMRSWO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCMRS As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPOther As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCMRS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMRS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdMRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCompReqFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompReqFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCompReqTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompReqTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMRSNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdReport As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMRSType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemProgressBar1 As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents XTPWO As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCMRSWO As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMRSWO As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdMRSTypeWO As DevExpress.XtraGrid.Columns.GridColumn
End Class
