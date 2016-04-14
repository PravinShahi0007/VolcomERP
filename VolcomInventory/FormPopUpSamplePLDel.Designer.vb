<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpSamplePLDel
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
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl
        Me.GroupControlPLList = New DevExpress.XtraEditors.GroupControl
        Me.GCPL = New DevExpress.XtraGrid.GridControl
        Me.GVPL = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdPLSample = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdContactFrom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdCompContactTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPLNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSRNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnFrom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPLDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPLNote = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GroupControlPLDetail = New DevExpress.XtraEditors.GroupControl
        Me.GCDrawer = New DevExpress.XtraGrid.GridControl
        Me.GVDrawer = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemSpinEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDivision = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupControlPLList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlPLList.SuspendLayout()
        CType(Me.GCPL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlPLDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlPLDetail.SuspendLayout()
        CType(Me.GCDrawer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDrawer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BtnCancel)
        Me.PanelControl2.Controls.Add(Me.BtnSave)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 425)
        Me.PanelControl2.LookAndFeel.SkinName = "Blue"
        Me.PanelControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1038, 44)
        Me.PanelControl2.TabIndex = 28
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(880, 9)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(70, 23)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(956, 9)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(70, 23)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Choose"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupControlPLList)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupControlPLDetail)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1038, 425)
        Me.SplitContainerControl1.SplitterPosition = 207
        Me.SplitContainerControl1.TabIndex = 29
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupControlPLList
        '
        Me.GroupControlPLList.Controls.Add(Me.GCPL)
        Me.GroupControlPLList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlPLList.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlPLList.Name = "GroupControlPLList"
        Me.GroupControlPLList.Size = New System.Drawing.Size(1038, 207)
        Me.GroupControlPLList.TabIndex = 0
        Me.GroupControlPLList.Text = "Packing List"
        '
        'GCPL
        '
        Me.GCPL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPL.Location = New System.Drawing.Point(2, 22)
        Me.GCPL.MainView = Me.GVPL
        Me.GCPL.Name = "GCPL"
        Me.GCPL.Size = New System.Drawing.Size(1034, 183)
        Me.GCPL.TabIndex = 2
        Me.GCPL.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPL})
        '
        'GVPL
        '
        Me.GVPL.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnIdPLSample, Me.GridColumnIdContactFrom, Me.GridColumnIdCompContactTo, Me.GridColumn1, Me.GridColumnPLNumber, Me.GridColumnSRNumber, Me.GridColumnFrom, Me.GridColumn19, Me.GridColumn20, Me.GridColumnTo, Me.GridColumnPLDate, Me.GridColumnPLNote, Me.GridColumnStatus, Me.GridColumn21, Me.GridColumn22, Me.GridColumnDivision})
        Me.GVPL.GridControl = Me.GCPL
        Me.GVPL.Name = "GVPL"
        Me.GVPL.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVPL.OptionsBehavior.Editable = False
        Me.GVPL.OptionsFind.AlwaysVisible = True
        Me.GVPL.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnNo.Width = 41
        '
        'GridColumnIdPLSample
        '
        Me.GridColumnIdPLSample.Caption = "Id PL Sample"
        Me.GridColumnIdPLSample.FieldName = "id_pl_sample_del"
        Me.GridColumnIdPLSample.Name = "GridColumnIdPLSample"
        Me.GridColumnIdPLSample.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdContactFrom
        '
        Me.GridColumnIdContactFrom.Caption = "GridColumnIdContacctFrom"
        Me.GridColumnIdContactFrom.FieldName = "id_comp_contact_from"
        Me.GridColumnIdContactFrom.Name = "GridColumnIdContactFrom"
        Me.GridColumnIdContactFrom.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdCompContactTo
        '
        Me.GridColumnIdCompContactTo.Caption = "GridColumnIdCompContactTo"
        Me.GridColumnIdCompContactTo.FieldName = "id_comp_contact_to"
        Me.GridColumnIdCompContactTo.Name = "GridColumnIdCompContactTo"
        Me.GridColumnIdCompContactTo.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "id_report_status"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumnPLNumber
        '
        Me.GridColumnPLNumber.Caption = "Number"
        Me.GridColumnPLNumber.FieldName = "pl_sample_del_number"
        Me.GridColumnPLNumber.Name = "GridColumnPLNumber"
        Me.GridColumnPLNumber.Visible = True
        Me.GridColumnPLNumber.VisibleIndex = 0
        Me.GridColumnPLNumber.Width = 97
        '
        'GridColumnSRNumber
        '
        Me.GridColumnSRNumber.Caption = "SRS Number"
        Me.GridColumnSRNumber.FieldName = "sample_requisition_number"
        Me.GridColumnSRNumber.Name = "GridColumnSRNumber"
        Me.GridColumnSRNumber.Visible = True
        Me.GridColumnSRNumber.VisibleIndex = 2
        '
        'GridColumnFrom
        '
        Me.GridColumnFrom.Caption = "From"
        Me.GridColumnFrom.FieldName = "comp_name_from"
        Me.GridColumnFrom.Name = "GridColumnFrom"
        Me.GridColumnFrom.Visible = True
        Me.GridColumnFrom.VisibleIndex = 3
        Me.GridColumnFrom.Width = 97
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "User To"
        Me.GridColumn19.FieldName = "employee_name"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 4
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Dept. To"
        Me.GridColumn20.FieldName = "departement"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 5
        '
        'GridColumnTo
        '
        Me.GridColumnTo.Caption = "Ship To"
        Me.GridColumnTo.FieldName = "comp_name_to"
        Me.GridColumnTo.Name = "GridColumnTo"
        Me.GridColumnTo.Visible = True
        Me.GridColumnTo.VisibleIndex = 6
        Me.GridColumnTo.Width = 97
        '
        'GridColumnPLDate
        '
        Me.GridColumnPLDate.Caption = "Created Date"
        Me.GridColumnPLDate.FieldName = "pl_sample_del_date"
        Me.GridColumnPLDate.Name = "GridColumnPLDate"
        Me.GridColumnPLDate.Visible = True
        Me.GridColumnPLDate.VisibleIndex = 7
        Me.GridColumnPLDate.Width = 97
        '
        'GridColumnPLNote
        '
        Me.GridColumnPLNote.Caption = "Note"
        Me.GridColumnPLNote.FieldName = "pl_sample_del_note"
        Me.GridColumnPLNote.Name = "GridColumnPLNote"
        Me.GridColumnPLNote.Visible = True
        Me.GridColumnPLNote.VisibleIndex = 8
        Me.GridColumnPLNote.Width = 97
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 9
        Me.GridColumnStatus.Width = 107
        '
        'GridColumn21
        '
        Me.GridColumn21.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn21.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn21.Caption = "Qty PL"
        Me.GridColumn21.DisplayFormat.FormatString = "N2"
        Me.GridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn21.FieldName = "qty_pl"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 10
        '
        'GridColumn22
        '
        Me.GridColumn22.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn22.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn22.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn22.Caption = "Qty Returned"
        Me.GridColumn22.DisplayFormat.FormatString = "N2"
        Me.GridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn22.FieldName = "qty_ret"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 11
        '
        'GroupControlPLDetail
        '
        Me.GroupControlPLDetail.Controls.Add(Me.GCDrawer)
        Me.GroupControlPLDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlPLDetail.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlPLDetail.Name = "GroupControlPLDetail"
        Me.GroupControlPLDetail.Size = New System.Drawing.Size(1038, 213)
        Me.GroupControlPLDetail.TabIndex = 0
        Me.GroupControlPLDetail.Text = "Detail"
        '
        'GCDrawer
        '
        Me.GCDrawer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDrawer.Location = New System.Drawing.Point(2, 22)
        Me.GCDrawer.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCDrawer.MainView = Me.GVDrawer
        Me.GCDrawer.Name = "GCDrawer"
        Me.GCDrawer.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit3})
        Me.GCDrawer.Size = New System.Drawing.Size(1034, 189)
        Me.GCDrawer.TabIndex = 25
        Me.GCDrawer.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDrawer})
        '
        'GVDrawer
        '
        Me.GVDrawer.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn7, Me.GridColumn17, Me.GridColumn3, Me.GridColumn4, Me.GridColumn6, Me.GridColumn14, Me.GridColumn11, Me.GridColumn12, Me.GridColumn5, Me.GridColumn18, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn13, Me.GridColumn15, Me.GridColumn16})
        Me.GVDrawer.GridControl = Me.GCDrawer
        Me.GVDrawer.Name = "GVDrawer"
        Me.GVDrawer.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVDrawer.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVDrawer.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDrawer.OptionsBehavior.Editable = False
        Me.GVDrawer.OptionsNavigation.AutoFocusNewRow = True
        Me.GVDrawer.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Code"
        Me.GridColumn2.FieldName = "code"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 77
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Name"
        Me.GridColumn7.FieldName = "name"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 1
        Me.GridColumn7.Width = 77
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "WH From"
        Me.GridColumn17.FieldName = "comp_name"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 2
        Me.GridColumn17.Width = 77
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Locator From"
        Me.GridColumn3.FieldName = "wh_locator"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        Me.GridColumn3.Width = 77
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Rack From"
        Me.GridColumn4.FieldName = "wh_rack"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 4
        Me.GridColumn4.Width = 77
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Drawer From"
        Me.GridColumn6.FieldName = "wh_drawer"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        Me.GridColumn6.Width = 77
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "UOM"
        Me.GridColumn14.FieldName = "uom"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 6
        Me.GridColumn14.Width = 77
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Qty Limit"
        Me.GridColumn11.FieldName = "qty_all_sample"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Remark"
        Me.GridColumn12.FieldName = "pl_sample_del_det_note"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.Width = 77
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Qty"
        Me.GridColumn5.ColumnEdit = Me.RepositoryItemSpinEdit3
        Me.GridColumn5.FieldName = "pl_sample_del_det_qty"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pl_sample_del_det_qty", "{0:n2}")})
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 7
        Me.GridColumn5.Width = 58
        '
        'RepositoryItemSpinEdit3
        '
        Me.RepositoryItemSpinEdit3.AutoHeight = False
        Me.RepositoryItemSpinEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RepositoryItemSpinEdit3.EditValueChangedDelay = 50
        Me.RepositoryItemSpinEdit3.IsFloatValue = False
        Me.RepositoryItemSpinEdit3.Mask.EditMask = "f2"
        Me.RepositoryItemSpinEdit3.MaxValue = New Decimal(New Integer() {1215752092, 23, 0, 131072})
        Me.RepositoryItemSpinEdit3.Name = "RepositoryItemSpinEdit3"
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Not yet returned"
        Me.GridColumn18.FieldName = "pl_sample_del_det_limit_qty"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 8
        Me.GridColumn18.Width = 100
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "id Pl Sample Det"
        Me.GridColumn8.FieldName = "id_pl_sample_del_det"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Id WH Drawer"
        Me.GridColumn9.FieldName = "id_wh_drawer"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Id Sample"
        Me.GridColumn10.FieldName = "id_sample"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "id sample requisition det"
        Me.GridColumn13.FieldName = "id_sample_requisition_det"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Id WH Locator"
        Me.GridColumn15.FieldName = "id_wh_locator"
        Me.GridColumn15.Name = "GridColumn15"
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Id WH Rack"
        Me.GridColumn16.FieldName = "id_wh_rack"
        Me.GridColumn16.Name = "GridColumn16"
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
        'FormPopUpSamplePLDel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1038, 469)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpSamplePLDel"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pop Up Packing List Delivery Sample "
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupControlPLList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlPLList.ResumeLayout(False)
        CType(Me.GCPL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlPLDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlPLDetail.ResumeLayout(False)
        CType(Me.GCDrawer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDrawer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlPLList As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCPL As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPL As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPLSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdContactFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCompContactTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSRNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControlPLDetail As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCDrawer As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDrawer As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDivision As DevExpress.XtraGrid.Columns.GridColumn
End Class
