<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormODM
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SLUE3PL = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPManifestList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdWhAwbDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdCompGroup = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCollie = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCombinedNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDeliverySlip = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSDO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAWBNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStoreAccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStoreName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDestination = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnWeight = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDim = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFinal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BCreatePO = New DevExpress.XtraEditors.SimpleButton()
        Me.BReset = New DevExpress.XtraEditors.SimpleButton()
        Me.PCScan = New DevExpress.XtraEditors.PanelControl()
        Me.TEScan = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLUE3PL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPManifestList.SuspendLayout()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCScan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCScan.SuspendLayout()
        CType(Me.TEScan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SLUE3PL)
        Me.PanelControl1.Controls.Add(Me.BView)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1072, 44)
        Me.PanelControl1.TabIndex = 0
        '
        'SLUE3PL
        '
        Me.SLUE3PL.Location = New System.Drawing.Point(40, 13)
        Me.SLUE3PL.Name = "SLUE3PL"
        Me.SLUE3PL.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUE3PL.Properties.View = Me.SearchLookUpEdit1View
        Me.SLUE3PL.Size = New System.Drawing.Size(211, 20)
        Me.SLUE3PL.TabIndex = 10
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn9, Me.GridColumn10})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn9
        '
        Me.GridColumn9.FieldName = "id_comp"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "3PL"
        Me.GridColumn10.FieldName = "comp_name"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(257, 11)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(54, 23)
        Me.BView.TabIndex = 9
        Me.BView.Text = "view"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(14, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(20, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "3PL "
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPManifestList
        Me.XtraTabControl1.Size = New System.Drawing.Size(1078, 584)
        Me.XtraTabControl1.TabIndex = 1
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPManifestList})
        '
        'XTPManifestList
        '
        Me.XTPManifestList.Controls.Add(Me.GCList)
        Me.XTPManifestList.Controls.Add(Me.BCreatePO)
        Me.XTPManifestList.Controls.Add(Me.BReset)
        Me.XTPManifestList.Controls.Add(Me.PCScan)
        Me.XTPManifestList.Controls.Add(Me.PanelControl1)
        Me.XTPManifestList.Name = "XTPManifestList"
        Me.XTPManifestList.Size = New System.Drawing.Size(1072, 556)
        Me.XTPManifestList.Text = "List"
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(0, 94)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.Size = New System.Drawing.Size(1072, 398)
        Me.GCList.TabIndex = 16
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Appearance.GroupPanel.Font = New System.Drawing.Font("Tahoma", 1.0!)
        Me.GVList.Appearance.GroupPanel.Options.UseFont = True
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn2, Me.GridColumn1, Me.GridColumnIdWhAwbDet, Me.GridColumnIdCompGroup, Me.GridColumnCreatedDate, Me.GridColumnCollie, Me.GridColumnCombinedNumber, Me.GridColumnDeliverySlip, Me.GridColumnSDO, Me.GridColumnAWBNumber, Me.GridColumnStoreAccount, Me.GridColumnStoreName, Me.GridColumnQty, Me.GridColumnDestination, Me.GridColumnWeight, Me.GridColumnP, Me.GridColumnL, Me.GridColumnT, Me.GridColumnDim, Me.GridColumnFinal, Me.GridColumnRemark})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.GroupCount = 1
        Me.GVList.GroupFormat = ""
        Me.GVList.LevelIndent = 0
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVList.OptionsFind.AlwaysVisible = True
        Me.GVList.OptionsView.AllowCellMerge = True
        Me.GVList.OptionsView.ColumnAutoWidth = False
        Me.GVList.OptionsView.ShowFooter = True
        Me.GVList.OptionsView.ShowGroupedColumns = True
        Me.GVList.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.GVList.OptionsView.ShowGroupPanel = False
        Me.GVList.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn2, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.Caption = "Checklist"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "ODM Number"
        Me.GridColumn2.FieldName = "id_del_manifest"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Outbound Delivery Manifest"
        Me.GridColumn1.FieldName = "number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        Me.GridColumn1.Width = 176
        '
        'GridColumnIdWhAwbDet
        '
        Me.GridColumnIdWhAwbDet.FieldName = "id_wh_awb_det"
        Me.GridColumnIdWhAwbDet.Name = "GridColumnIdWhAwbDet"
        Me.GridColumnIdWhAwbDet.OptionsColumn.AllowEdit = False
        Me.GridColumnIdWhAwbDet.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumnIdCompGroup
        '
        Me.GridColumnIdCompGroup.FieldName = "id_comp_group"
        Me.GridColumnIdCompGroup.Name = "GridColumnIdCompGroup"
        Me.GridColumnIdCompGroup.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "awbill_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.OptionsColumn.AllowEdit = False
        Me.GridColumnCreatedDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 15
        '
        'GridColumnCollie
        '
        Me.GridColumnCollie.Caption = "Outbound Label Number"
        Me.GridColumnCollie.FieldName = "id_awbill"
        Me.GridColumnCollie.Name = "GridColumnCollie"
        Me.GridColumnCollie.OptionsColumn.AllowEdit = False
        Me.GridColumnCollie.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumnCollie.Visible = True
        Me.GridColumnCollie.VisibleIndex = 2
        Me.GridColumnCollie.Width = 141
        '
        'GridColumnCombinedNumber
        '
        Me.GridColumnCombinedNumber.Caption = "Delivery Slip"
        Me.GridColumnCombinedNumber.FieldName = "combine_number"
        Me.GridColumnCombinedNumber.Name = "GridColumnCombinedNumber"
        Me.GridColumnCombinedNumber.OptionsColumn.AllowEdit = False
        Me.GridColumnCombinedNumber.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumnCombinedNumber.Visible = True
        Me.GridColumnCombinedNumber.VisibleIndex = 3
        '
        'GridColumnDeliverySlip
        '
        Me.GridColumnDeliverySlip.Caption = "Delivery Slip"
        Me.GridColumnDeliverySlip.FieldName = "do_no"
        Me.GridColumnDeliverySlip.Name = "GridColumnDeliverySlip"
        Me.GridColumnDeliverySlip.OptionsColumn.AllowEdit = False
        Me.GridColumnDeliverySlip.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumnSDO
        '
        Me.GridColumnSDO.Caption = "No. SDO"
        Me.GridColumnSDO.FieldName = "pl_sales_order_del_number"
        Me.GridColumnSDO.Name = "GridColumnSDO"
        Me.GridColumnSDO.OptionsColumn.AllowEdit = False
        Me.GridColumnSDO.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumnAWBNumber
        '
        Me.GridColumnAWBNumber.Caption = "AWB Number"
        Me.GridColumnAWBNumber.FieldName = "awbill_no"
        Me.GridColumnAWBNumber.Name = "GridColumnAWBNumber"
        Me.GridColumnAWBNumber.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnAWBNumber.Visible = True
        Me.GridColumnAWBNumber.VisibleIndex = 4
        '
        'GridColumnStoreAccount
        '
        Me.GridColumnStoreAccount.Caption = "Store Account"
        Me.GridColumnStoreAccount.FieldName = "comp_number"
        Me.GridColumnStoreAccount.Name = "GridColumnStoreAccount"
        Me.GridColumnStoreAccount.OptionsColumn.AllowEdit = False
        Me.GridColumnStoreAccount.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnStoreAccount.Visible = True
        Me.GridColumnStoreAccount.VisibleIndex = 5
        Me.GridColumnStoreAccount.Width = 78
        '
        'GridColumnStoreName
        '
        Me.GridColumnStoreName.Caption = "Store Name"
        Me.GridColumnStoreName.FieldName = "comp_name"
        Me.GridColumnStoreName.Name = "GridColumnStoreName"
        Me.GridColumnStoreName.OptionsColumn.AllowEdit = False
        Me.GridColumnStoreName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnStoreName.Visible = True
        Me.GridColumnStoreName.VisibleIndex = 6
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.MaxWidth = 50
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowEdit = False
        Me.GridColumnQty.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 7
        Me.GridColumnQty.Width = 50
        '
        'GridColumnDestination
        '
        Me.GridColumnDestination.Caption = "Destination"
        Me.GridColumnDestination.FieldName = "city"
        Me.GridColumnDestination.Name = "GridColumnDestination"
        Me.GridColumnDestination.OptionsColumn.AllowEdit = False
        Me.GridColumnDestination.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumnDestination.Visible = True
        Me.GridColumnDestination.VisibleIndex = 8
        Me.GridColumnDestination.Width = 77
        '
        'GridColumnWeight
        '
        Me.GridColumnWeight.Caption = "Weight"
        Me.GridColumnWeight.DisplayFormat.FormatString = "N2"
        Me.GridColumnWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnWeight.FieldName = "weight"
        Me.GridColumnWeight.Name = "GridColumnWeight"
        Me.GridColumnWeight.OptionsColumn.AllowEdit = False
        Me.GridColumnWeight.Visible = True
        Me.GridColumnWeight.VisibleIndex = 9
        '
        'GridColumnP
        '
        Me.GridColumnP.Caption = "P"
        Me.GridColumnP.DisplayFormat.FormatString = "N2"
        Me.GridColumnP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnP.FieldName = "width"
        Me.GridColumnP.Name = "GridColumnP"
        Me.GridColumnP.OptionsColumn.AllowEdit = False
        Me.GridColumnP.Visible = True
        Me.GridColumnP.VisibleIndex = 10
        '
        'GridColumnL
        '
        Me.GridColumnL.Caption = "L"
        Me.GridColumnL.DisplayFormat.FormatString = "N2"
        Me.GridColumnL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnL.FieldName = "length"
        Me.GridColumnL.Name = "GridColumnL"
        Me.GridColumnL.OptionsColumn.AllowEdit = False
        Me.GridColumnL.Visible = True
        Me.GridColumnL.VisibleIndex = 11
        '
        'GridColumnT
        '
        Me.GridColumnT.Caption = "T"
        Me.GridColumnT.DisplayFormat.FormatString = "N2"
        Me.GridColumnT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnT.FieldName = "height"
        Me.GridColumnT.Name = "GridColumnT"
        Me.GridColumnT.OptionsColumn.AllowEdit = False
        Me.GridColumnT.Visible = True
        Me.GridColumnT.VisibleIndex = 12
        '
        'GridColumnDim
        '
        Me.GridColumnDim.Caption = "Dim"
        Me.GridColumnDim.DisplayFormat.FormatString = "N2"
        Me.GridColumnDim.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDim.FieldName = "volume"
        Me.GridColumnDim.Name = "GridColumnDim"
        Me.GridColumnDim.OptionsColumn.AllowEdit = False
        Me.GridColumnDim.Visible = True
        Me.GridColumnDim.VisibleIndex = 13
        '
        'GridColumnFinal
        '
        Me.GridColumnFinal.Caption = "Final Weight"
        Me.GridColumnFinal.DisplayFormat.FormatString = "N2"
        Me.GridColumnFinal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnFinal.FieldName = "c_weight"
        Me.GridColumnFinal.Name = "GridColumnFinal"
        Me.GridColumnFinal.OptionsColumn.AllowEdit = False
        Me.GridColumnFinal.Visible = True
        Me.GridColumnFinal.VisibleIndex = 14
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.OptionsColumn.AllowEdit = False
        Me.GridColumnRemark.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnRemark.Visible = True
        Me.GridColumnRemark.VisibleIndex = 16
        '
        'BCreatePO
        '
        Me.BCreatePO.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BCreatePO.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BCreatePO.Appearance.ForeColor = System.Drawing.Color.White
        Me.BCreatePO.Appearance.Options.UseBackColor = True
        Me.BCreatePO.Appearance.Options.UseFont = True
        Me.BCreatePO.Appearance.Options.UseForeColor = True
        Me.BCreatePO.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BCreatePO.Location = New System.Drawing.Point(0, 492)
        Me.BCreatePO.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BCreatePO.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BCreatePO.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BCreatePO.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BCreatePO.Name = "BCreatePO"
        Me.BCreatePO.Size = New System.Drawing.Size(1072, 32)
        Me.BCreatePO.TabIndex = 14
        Me.BCreatePO.Text = "COMPLETE + PRINT"
        '
        'BReset
        '
        Me.BReset.Appearance.BackColor = System.Drawing.Color.Tomato
        Me.BReset.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BReset.Appearance.ForeColor = System.Drawing.Color.White
        Me.BReset.Appearance.Options.UseBackColor = True
        Me.BReset.Appearance.Options.UseFont = True
        Me.BReset.Appearance.Options.UseForeColor = True
        Me.BReset.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BReset.Location = New System.Drawing.Point(0, 524)
        Me.BReset.LookAndFeel.SkinMaskColor = System.Drawing.Color.Red
        Me.BReset.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BReset.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BReset.Name = "BReset"
        Me.BReset.Size = New System.Drawing.Size(1072, 32)
        Me.BReset.TabIndex = 15
        Me.BReset.Text = "RESET"
        '
        'PCScan
        '
        Me.PCScan.Controls.Add(Me.TEScan)
        Me.PCScan.Controls.Add(Me.LabelControl2)
        Me.PCScan.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCScan.Location = New System.Drawing.Point(0, 44)
        Me.PCScan.Name = "PCScan"
        Me.PCScan.Size = New System.Drawing.Size(1072, 50)
        Me.PCScan.TabIndex = 1
        '
        'TEScan
        '
        Me.TEScan.Location = New System.Drawing.Point(203, 13)
        Me.TEScan.Name = "TEScan"
        Me.TEScan.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TEScan.Properties.Appearance.Options.UseFont = True
        Me.TEScan.Size = New System.Drawing.Size(473, 26)
        Me.TEScan.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.LabelControl2.Location = New System.Drawing.Point(14, 16)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(183, 19)
        Me.LabelControl2.TabIndex = 0
        Me.LabelControl2.Text = "SCAN OUTBOUND LABEL"
        '
        'FormODM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 584)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormODM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Outbound Delivery Manifest"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLUE3PL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPManifestList.ResumeLayout(False)
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCScan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCScan.ResumeLayout(False)
        Me.PCScan.PerformLayout()
        CType(Me.TEScan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPManifestList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PCScan As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEScan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BCreatePO As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BReset As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdWhAwbDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCompGroup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCollie As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCombinedNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDeliverySlip As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSDO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAWBNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStoreAccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStoreName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDestination As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWeight As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDim As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFinal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLUE3PL As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
