<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpSampleReq
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
        Me.components = New System.ComponentModel.Container
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl
        Me.GroupControlSampleReq = New DevExpress.XtraEditors.GroupControl
        Me.GCReq = New DevExpress.XtraGrid.GridControl
        Me.GVReq = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdSampleReq = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColRetOutNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnFromUser = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDepartement = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColShipFrom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColShipTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDuration = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColRecDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnNotes = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCreatedPL = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ToolTipControllerNew = New DevExpress.Utils.ToolTipController(Me.components)
        Me.GroupControlDetail = New DevExpress.XtraEditors.GroupControl
        Me.GCRetDetail = New DevExpress.XtraGrid.GridControl
        Me.GVRetDetail = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdReq = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSamplePurcDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Me.GridColumnDivision = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupControlSampleReq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlSampleReq.SuspendLayout()
        CType(Me.GCReq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVReq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlDetail.SuspendLayout()
        CType(Me.GCRetDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRetDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnChoose)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 433)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(860, 48)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(692, 13)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 24)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnChoose
        '
        Me.BtnChoose.Location = New System.Drawing.Point(773, 13)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(75, 23)
        Me.BtnChoose.TabIndex = 0
        Me.BtnChoose.Text = "Choose"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupControlSampleReq)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupControlDetail)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(860, 433)
        Me.SplitContainerControl1.SplitterPosition = 190
        Me.SplitContainerControl1.TabIndex = 1
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupControlSampleReq
        '
        Me.GroupControlSampleReq.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlSampleReq.Controls.Add(Me.GCReq)
        Me.GroupControlSampleReq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlSampleReq.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlSampleReq.Name = "GroupControlSampleReq"
        Me.GroupControlSampleReq.Size = New System.Drawing.Size(860, 190)
        Me.GroupControlSampleReq.TabIndex = 0
        Me.GroupControlSampleReq.Text = "Sample Requisition "
        '
        'GCReq
        '
        Me.GCReq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCReq.Location = New System.Drawing.Point(22, 2)
        Me.GCReq.MainView = Me.GVReq
        Me.GCReq.Name = "GCReq"
        Me.GCReq.Size = New System.Drawing.Size(836, 186)
        Me.GCReq.TabIndex = 5
        Me.GCReq.ToolTipController = Me.ToolTipControllerNew
        Me.GCReq.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVReq})
        '
        'GVReq
        '
        Me.GVReq.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdSampleReq, Me.ColRetOutNumber, Me.GridColumnFromUser, Me.GridColumnDepartement, Me.ColShipFrom, Me.ColShipTo, Me.ColDuration, Me.ColRecDate, Me.GridColumnNotes, Me.GridColumnStatus, Me.GridColumnCreatedPL, Me.GridColumnDivision})
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
        Me.ColRetOutNumber.Width = 84
        '
        'GridColumnFromUser
        '
        Me.GridColumnFromUser.Caption = "From"
        Me.GridColumnFromUser.FieldName = "employee_name"
        Me.GridColumnFromUser.Name = "GridColumnFromUser"
        Me.GridColumnFromUser.Visible = True
        Me.GridColumnFromUser.VisibleIndex = 2
        Me.GridColumnFromUser.Width = 62
        '
        'GridColumnDepartement
        '
        Me.GridColumnDepartement.Caption = "Departement"
        Me.GridColumnDepartement.FieldName = "departement"
        Me.GridColumnDepartement.Name = "GridColumnDepartement"
        Me.GridColumnDepartement.Visible = True
        Me.GridColumnDepartement.VisibleIndex = 3
        Me.GridColumnDepartement.Width = 62
        '
        'ColShipFrom
        '
        Me.ColShipFrom.Caption = "Ship To"
        Me.ColShipFrom.FieldName = "comp_from"
        Me.ColShipFrom.Name = "ColShipFrom"
        Me.ColShipFrom.Visible = True
        Me.ColShipFrom.VisibleIndex = 4
        Me.ColShipFrom.Width = 165
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
        Me.ColDuration.Width = 100
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
        Me.ColRecDate.Width = 142
        '
        'GridColumnNotes
        '
        Me.GridColumnNotes.Caption = "Notes"
        Me.GridColumnNotes.FieldName = "sample_requisition_note"
        Me.GridColumnNotes.Name = "GridColumnNotes"
        Me.GridColumnNotes.Visible = True
        Me.GridColumnNotes.VisibleIndex = 7
        Me.GridColumnNotes.Width = 101
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Width = 101
        '
        'GridColumnCreatedPL
        '
        Me.GridColumnCreatedPL.Caption = "Created PL"
        Me.GridColumnCreatedPL.FieldName = "tot_pl"
        Me.GridColumnCreatedPL.Name = "GridColumnCreatedPL"
        Me.GridColumnCreatedPL.Visible = True
        Me.GridColumnCreatedPL.VisibleIndex = 8
        Me.GridColumnCreatedPL.Width = 104
        '
        'ToolTipControllerNew
        '
        '
        'GroupControlDetail
        '
        Me.GroupControlDetail.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlDetail.Controls.Add(Me.GCRetDetail)
        Me.GroupControlDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlDetail.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlDetail.Name = "GroupControlDetail"
        Me.GroupControlDetail.Size = New System.Drawing.Size(860, 237)
        Me.GroupControlDetail.TabIndex = 1
        Me.GroupControlDetail.Text = "Detail"
        '
        'GCRetDetail
        '
        Me.GCRetDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRetDetail.Location = New System.Drawing.Point(22, 2)
        Me.GCRetDetail.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GCRetDetail.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCRetDetail.MainView = Me.GVRetDetail
        Me.GCRetDetail.Name = "GCRetDetail"
        Me.GCRetDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCRetDetail.Size = New System.Drawing.Size(836, 233)
        Me.GCRetDetail.TabIndex = 2
        Me.GCRetDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRetDetail})
        '
        'GVRetDetail
        '
        Me.GVRetDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnCode, Me.GridColumnIdReq, Me.GridColumnIdSamplePurcDet, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnUOM, Me.GridColumnRemark, Me.GridColumnQty})
        Me.GVRetDetail.GridControl = Me.GCRetDetail
        Me.GVRetDetail.Name = "GVRetDetail"
        Me.GVRetDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVRetDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVRetDetail.OptionsBehavior.Editable = False
        Me.GVRetDetail.OptionsView.ShowFooter = True
        Me.GVRetDetail.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 30
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        Me.GridColumnCode.Width = 80
        '
        'GridColumnIdReq
        '
        Me.GridColumnIdReq.Caption = "ID Req"
        Me.GridColumnIdReq.FieldName = "id_sample_requisition_det"
        Me.GridColumnIdReq.Name = "GridColumnIdReq"
        Me.GridColumnIdReq.OptionsColumn.AllowEdit = False
        '
        'GridColumnIdSamplePurcDet
        '
        Me.GridColumnIdSamplePurcDet.Caption = "Id Sample "
        Me.GridColumnIdSamplePurcDet.FieldName = "id_sample"
        Me.GridColumnIdSamplePurcDet.Name = "GridColumnIdSamplePurcDet"
        Me.GridColumnIdSamplePurcDet.OptionsColumn.AllowEdit = False
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 2
        Me.GridColumnName.Width = 80
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.OptionsColumn.AllowEdit = False
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 3
        Me.GridColumnSize.Width = 80
        '
        'GridColumnUOM
        '
        Me.GridColumnUOM.Caption = "UOM"
        Me.GridColumnUOM.FieldName = "uom"
        Me.GridColumnUOM.Name = "GridColumnUOM"
        Me.GridColumnUOM.OptionsColumn.AllowEdit = False
        Me.GridColumnUOM.Visible = True
        Me.GridColumnUOM.VisibleIndex = 4
        Me.GridColumnUOM.Width = 80
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.FieldName = "sample_requisition_det_note"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.Visible = True
        Me.GridColumnRemark.VisibleIndex = 5
        Me.GridColumnRemark.Width = 83
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Qty Requisition"
        Me.GridColumnQty.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumnQty.FieldName = "sample_requisition_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 6
        Me.GridColumnQty.Width = 80
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RepositoryItemSpinEdit1.EditValueChangedDelay = 50
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
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
        'FormPopUpSampleReq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 481)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpSampleReq"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pop Up Sample Requisition"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupControlSampleReq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlSampleReq.ResumeLayout(False)
        CType(Me.GCReq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVReq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlDetail.ResumeLayout(False)
        CType(Me.GCRetDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRetDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlSampleReq As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControlDetail As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCRetDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRetDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdReq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSamplePurcDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCReq As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVReq As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdSampleReq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRetOutNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFromUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDuration As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNotes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedPL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolTipControllerNew As DevExpress.Utils.ToolTipController
    Friend WithEvents GridColumnDivision As DevExpress.XtraGrid.Columns.GridColumn
End Class
