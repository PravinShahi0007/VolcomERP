<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAccountingJournalBrowse
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCredit = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDebit = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.SLEWHStockSum = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView14 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LEBilling = New DevExpress.XtraEditors.LookUpEdit()
        Me.GCJournalDet = New DevExpress.XtraGrid.GridControl()
        Me.GVJournalDet = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumnIdJurnal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnJurnalNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnJournalDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAccDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIsSelect = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEWHStockSum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEBilling.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCJournalDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVJournalDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCredit)
        Me.PanelControl1.Controls.Add(Me.BtnDebit)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 411)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(756, 45)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnCredit
        '
        Me.BtnCredit.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCredit.Location = New System.Drawing.Point(558, 2)
        Me.BtnCredit.Name = "BtnCredit"
        Me.BtnCredit.Size = New System.Drawing.Size(102, 41)
        Me.BtnCredit.TabIndex = 1
        Me.BtnCredit.Text = "Set as Credit"
        '
        'BtnDebit
        '
        Me.BtnDebit.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDebit.Location = New System.Drawing.Point(660, 2)
        Me.BtnDebit.Name = "BtnDebit"
        Me.BtnDebit.Size = New System.Drawing.Size(94, 41)
        Me.BtnDebit.TabIndex = 0
        Me.BtnDebit.Text = "Set as Debit"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.CheckEdit1)
        Me.PanelControl2.Controls.Add(Me.SLEWHStockSum)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.LEBilling)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(756, 47)
        Me.PanelControl2.TabIndex = 1
        '
        'CheckEdit1
        '
        Me.CheckEdit1.Location = New System.Drawing.Point(400, 14)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Caption = "Select All"
        Me.CheckEdit1.Size = New System.Drawing.Size(75, 19)
        Me.CheckEdit1.TabIndex = 9
        '
        'SLEWHStockSum
        '
        Me.SLEWHStockSum.Location = New System.Drawing.Point(228, 13)
        Me.SLEWHStockSum.Name = "SLEWHStockSum"
        Me.SLEWHStockSum.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEWHStockSum.Properties.Appearance.Options.UseFont = True
        Me.SLEWHStockSum.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEWHStockSum.Properties.View = Me.GridView14
        Me.SLEWHStockSum.Size = New System.Drawing.Size(166, 20)
        Me.SLEWHStockSum.TabIndex = 8
        '
        'GridView14
        '
        Me.GridView14.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView14.Name = "GridView14"
        Me.GridView14.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView14.OptionsView.ShowGroupPanel = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(138, 16)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Vendor/Customer"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Type"
        '
        'LEBilling
        '
        Me.LEBilling.Location = New System.Drawing.Point(42, 13)
        Me.LEBilling.Name = "LEBilling"
        Me.LEBilling.Properties.Appearance.Options.UseTextOptions = True
        Me.LEBilling.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEBilling.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LEBilling.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LEBilling.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LEBilling.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LEBilling.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEBilling.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_bill_type", "Id Billing Type", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bill_type", "Billing Type")})
        Me.LEBilling.Properties.NullText = ""
        Me.LEBilling.Properties.ShowFooter = False
        Me.LEBilling.Size = New System.Drawing.Size(90, 20)
        Me.LEBilling.TabIndex = 2
        '
        'GCJournalDet
        '
        Me.GCJournalDet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCJournalDet.Location = New System.Drawing.Point(0, 47)
        Me.GCJournalDet.MainView = Me.GVJournalDet
        Me.GCJournalDet.Name = "GCJournalDet"
        Me.GCJournalDet.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEdit2, Me.RepositoryItemCheckEdit1})
        Me.GCJournalDet.Size = New System.Drawing.Size(756, 364)
        Me.GCJournalDet.TabIndex = 13
        Me.GCJournalDet.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVJournalDet})
        '
        'GVJournalDet
        '
        Me.GVJournalDet.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumnIdJurnal, Me.GridColumnJurnalNumber, Me.GridColumnJournalDate, Me.GridColumnAccDesc, Me.GridColumnIsSelect})
        Me.GVJournalDet.GridControl = Me.GCJournalDet
        Me.GVJournalDet.GroupCount = 1
        Me.GVJournalDet.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debit", Me.GridColumn13, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "credit", Me.GridColumn14, "{0:N2}")})
        Me.GVJournalDet.Name = "GVJournalDet"
        Me.GVJournalDet.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVJournalDet.OptionsView.ShowFooter = True
        Me.GVJournalDet.OptionsView.ShowGroupedColumns = True
        Me.GVJournalDet.OptionsView.ShowGroupPanel = False
        Me.GVJournalDet.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnJurnalNumber, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "IDAcc"
        Me.GridColumn9.FieldName = "id_acc"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Id Trans"
        Me.GridColumn10.FieldName = "id_acc_trans_det"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.Width = 139
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Account"
        Me.GridColumn11.FieldName = "acc_name"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.OptionsColumn.ReadOnly = True
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 2
        Me.GridColumn11.Width = 160
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Note"
        Me.GridColumn12.FieldName = "note"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 4
        Me.GridColumn12.Width = 502
        '
        'GridColumn13
        '
        Me.GridColumn13.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn13.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn13.Caption = "Debit"
        Me.GridColumn13.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumn13.DisplayFormat.FormatString = "N2"
        Me.GridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn13.FieldName = "debit"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debit", "{0:N2}")})
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 5
        Me.GridColumn13.Width = 229
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatString = "N2"
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.EditFormat.FormatString = "N2"
        Me.RepositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.Mask.EditMask = "N2"
        Me.RepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn14.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn14.Caption = "Credit"
        Me.GridColumn14.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumn14.DisplayFormat.FormatString = "N2"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn14.FieldName = "credit"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "credit", "{0:N2}")})
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 6
        Me.GridColumn14.Width = 228
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.DisplayFormat.FormatString = "N2"
        Me.RepositoryItemTextEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit2.EditFormat.FormatString = "N2"
        Me.RepositoryItemTextEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit2.Mask.EditMask = "N2"
        Me.RepositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit2.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'GridColumnIdJurnal
        '
        Me.GridColumnIdJurnal.Caption = "Id Jurnal"
        Me.GridColumnIdJurnal.FieldName = "id_acc_trans"
        Me.GridColumnIdJurnal.Name = "GridColumnIdJurnal"
        Me.GridColumnIdJurnal.OptionsColumn.AllowEdit = False
        '
        'GridColumnJurnalNumber
        '
        Me.GridColumnJurnalNumber.Caption = "Journal Number"
        Me.GridColumnJurnalNumber.FieldName = "acc_trans_number"
        Me.GridColumnJurnalNumber.Name = "GridColumnJurnalNumber"
        Me.GridColumnJurnalNumber.OptionsColumn.AllowEdit = False
        Me.GridColumnJurnalNumber.Visible = True
        Me.GridColumnJurnalNumber.VisibleIndex = 0
        Me.GridColumnJurnalNumber.Width = 144
        '
        'GridColumnJournalDate
        '
        Me.GridColumnJournalDate.Caption = "Journal Date"
        Me.GridColumnJournalDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnJournalDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnJournalDate.FieldName = "date_created"
        Me.GridColumnJournalDate.Name = "GridColumnJournalDate"
        Me.GridColumnJournalDate.OptionsColumn.AllowEdit = False
        Me.GridColumnJournalDate.Visible = True
        Me.GridColumnJournalDate.VisibleIndex = 1
        Me.GridColumnJournalDate.Width = 155
        '
        'GridColumnAccDesc
        '
        Me.GridColumnAccDesc.Caption = "Acc. Description"
        Me.GridColumnAccDesc.FieldName = "acc_description"
        Me.GridColumnAccDesc.Name = "GridColumnAccDesc"
        Me.GridColumnAccDesc.OptionsColumn.AllowEdit = False
        Me.GridColumnAccDesc.Visible = True
        Me.GridColumnAccDesc.VisibleIndex = 3
        Me.GridColumnAccDesc.Width = 198
        '
        'GridColumnIsSelect
        '
        Me.GridColumnIsSelect.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnIsSelect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnIsSelect.Caption = "Select"
        Me.GridColumnIsSelect.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnIsSelect.FieldName = "is_select"
        Me.GridColumnIsSelect.Name = "GridColumnIsSelect"
        Me.GridColumnIsSelect.Visible = True
        Me.GridColumnIsSelect.VisibleIndex = 7
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'FormAccountingJournalBrowse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 456)
        Me.Controls.Add(Me.GCJournalDet)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAccountingJournalBrowse"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Browse Reference"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEWHStockSum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEBilling.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCJournalDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVJournalDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCredit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnDebit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LEBilling As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEWHStockSum As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView14 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCJournalDet As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVJournalDet As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumnIdJurnal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnJurnalNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnJournalDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAccDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsSelect As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
End Class
