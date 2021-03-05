<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormODMPrint
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.TENumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.L3PL = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.GCListHistory = New DevExpress.XtraGrid.GridControl()
        Me.GVListHistory = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHChecklist = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHStoreAccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.GCListHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BPrint
        '
        Me.BPrint.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BPrint.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BPrint.Appearance.ForeColor = System.Drawing.Color.White
        Me.BPrint.Appearance.Options.UseBackColor = True
        Me.BPrint.Appearance.Options.UseFont = True
        Me.BPrint.Appearance.Options.UseForeColor = True
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BPrint.Location = New System.Drawing.Point(0, 523)
        Me.BPrint.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BPrint.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BPrint.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BPrint.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(1063, 32)
        Me.BPrint.TabIndex = 19
        Me.BPrint.Text = "PRINT"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.TENumber)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.PanelControl3)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1063, 44)
        Me.PanelControl2.TabIndex = 20
        '
        'TENumber
        '
        Me.TENumber.Location = New System.Drawing.Point(55, 13)
        Me.TENumber.Name = "TENumber"
        Me.TENumber.Properties.ReadOnly = True
        Me.TENumber.Size = New System.Drawing.Size(269, 20)
        Me.TENumber.TabIndex = 13
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl1.TabIndex = 12
        Me.LabelControl1.Text = "Number"
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.L3PL)
        Me.PanelControl3.Controls.Add(Me.LabelControl5)
        Me.PanelControl3.Controls.Add(Me.LabelControl4)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl3.Location = New System.Drawing.Point(755, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(306, 40)
        Me.PanelControl3.TabIndex = 11
        '
        'L3PL
        '
        Me.L3PL.Location = New System.Drawing.Point(46, 14)
        Me.L3PL.Name = "L3PL"
        Me.L3PL.Size = New System.Drawing.Size(0, 13)
        Me.L3PL.TabIndex = 3
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(36, 14)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl5.TabIndex = 2
        Me.LabelControl5.Text = ":"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(13, 14)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(17, 13)
        Me.LabelControl4.TabIndex = 1
        Me.LabelControl4.Text = "3PL"
        '
        'GCListHistory
        '
        Me.GCListHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListHistory.Location = New System.Drawing.Point(0, 44)
        Me.GCListHistory.MainView = Me.GVListHistory
        Me.GCListHistory.Name = "GCListHistory"
        Me.GCListHistory.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCListHistory.Size = New System.Drawing.Size(1063, 479)
        Me.GCListHistory.TabIndex = 21
        Me.GCListHistory.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListHistory})
        '
        'GVListHistory
        '
        Me.GVListHistory.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black
        Me.GVListHistory.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHChecklist, Me.GridColumn8, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GCHStoreAccount, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn1, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn29, Me.GridColumn30, Me.GridColumn31})
        Me.GVListHistory.GridControl = Me.GCListHistory
        Me.GVListHistory.GroupCount = 1
        Me.GVListHistory.GroupFormat = "[#image]{1} {2}"
        Me.GVListHistory.LevelIndent = 1
        Me.GVListHistory.Name = "GVListHistory"
        Me.GVListHistory.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVListHistory.OptionsBehavior.Editable = False
        Me.GVListHistory.OptionsBehavior.ReadOnly = True
        Me.GVListHistory.OptionsFind.AllowFindPanel = False
        Me.GVListHistory.OptionsView.AllowCellMerge = True
        Me.GVListHistory.OptionsView.ColumnAutoWidth = False
        Me.GVListHistory.OptionsView.ShowFooter = True
        Me.GVListHistory.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.GVListHistory.OptionsView.ShowGroupPanel = False
        Me.GVListHistory.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn8, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GCHChecklist
        '
        Me.GCHChecklist.AppearanceCell.Options.UseTextOptions = True
        Me.GCHChecklist.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GCHChecklist.AppearanceHeader.Options.UseTextOptions = True
        Me.GCHChecklist.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GCHChecklist.Caption = "Checklist"
        Me.GCHChecklist.FieldName = "is_check"
        Me.GCHChecklist.Name = "GCHChecklist"
        Me.GCHChecklist.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCHChecklist.Visible = True
        Me.GCHChecklist.VisibleIndex = 0
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "ODM Number"
        Me.GridColumn8.FieldName = "number"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Outbound Delivery Manifest"
        Me.GridColumn11.FieldName = "number"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 1
        Me.GridColumn11.Width = 176
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Report Status"
        Me.GridColumn12.FieldName = "report_status"
        Me.GridColumn12.Name = "GridColumn12"
        '
        'GridColumn13
        '
        Me.GridColumn13.FieldName = "id_wh_awb_det"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumn14
        '
        Me.GridColumn14.FieldName = "id_comp_group"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Created Date"
        Me.GridColumn15.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn15.FieldName = "awbill_date"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        Me.GridColumn15.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 16
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Outbound Label Number"
        Me.GridColumn16.FieldName = "ol_number"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.AllowEdit = False
        Me.GridColumn16.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 2
        Me.GridColumn16.Width = 141
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Delivery Slip"
        Me.GridColumn17.FieldName = "combine_number"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.AllowEdit = False
        Me.GridColumn17.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 3
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Delivery Slip"
        Me.GridColumn18.FieldName = "do_no"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.AllowEdit = False
        Me.GridColumn18.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "No. SDO"
        Me.GridColumn19.FieldName = "pl_sales_order_del_number"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.OptionsColumn.AllowEdit = False
        Me.GridColumn19.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "AWB Number"
        Me.GridColumn20.FieldName = "awbill_no"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 4
        '
        'GCHStoreAccount
        '
        Me.GCHStoreAccount.Caption = "Store Account"
        Me.GCHStoreAccount.FieldName = "comp_number"
        Me.GCHStoreAccount.Name = "GCHStoreAccount"
        Me.GCHStoreAccount.OptionsColumn.AllowEdit = False
        Me.GCHStoreAccount.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCHStoreAccount.Visible = True
        Me.GCHStoreAccount.VisibleIndex = 5
        Me.GCHStoreAccount.Width = 78
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Store Name"
        Me.GridColumn22.FieldName = "comp_name"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.OptionsColumn.AllowEdit = False
        Me.GridColumn22.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 6
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "Qty"
        Me.GridColumn23.FieldName = "qty"
        Me.GridColumn23.MaxWidth = 50
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.OptionsColumn.AllowEdit = False
        Me.GridColumn23.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn23.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)})
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 7
        Me.GridColumn23.Width = 50
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "Destination"
        Me.GridColumn24.FieldName = "city"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.OptionsColumn.AllowEdit = False
        Me.GridColumn24.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 8
        Me.GridColumn24.Width = 77
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "District"
        Me.GridColumn1.FieldName = "district"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 9
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Weight"
        Me.GridColumn25.DisplayFormat.FormatString = "N2"
        Me.GridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn25.FieldName = "weight"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.OptionsColumn.AllowEdit = False
        Me.GridColumn25.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 10
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "P"
        Me.GridColumn26.DisplayFormat.FormatString = "N2"
        Me.GridColumn26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn26.FieldName = "width"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.OptionsColumn.AllowEdit = False
        Me.GridColumn26.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 11
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "L"
        Me.GridColumn27.DisplayFormat.FormatString = "N2"
        Me.GridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn27.FieldName = "length"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.OptionsColumn.AllowEdit = False
        Me.GridColumn27.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 12
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "T"
        Me.GridColumn28.DisplayFormat.FormatString = "N2"
        Me.GridColumn28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn28.FieldName = "height"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.OptionsColumn.AllowEdit = False
        Me.GridColumn28.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 13
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Dim"
        Me.GridColumn29.DisplayFormat.FormatString = "N2"
        Me.GridColumn29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn29.FieldName = "volume"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.OptionsColumn.AllowEdit = False
        Me.GridColumn29.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 14
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "Final Weight"
        Me.GridColumn30.DisplayFormat.FormatString = "N2"
        Me.GridColumn30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn30.FieldName = "c_weight"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.OptionsColumn.AllowEdit = False
        Me.GridColumn30.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 15
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "Remark"
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.OptionsColumn.AllowEdit = False
        Me.GridColumn31.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn31.Visible = True
        Me.GridColumn31.VisibleIndex = 17
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "no"
        '
        'FormODMPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1063, 555)
        Me.Controls.Add(Me.GCListHistory)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.BPrint)
        Me.MinimizeBox = False
        Me.Name = "FormODMPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manifest Print"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.GCListHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents L3PL As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCListHistory As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListHistory As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHChecklist As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHStoreAccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents TENumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
