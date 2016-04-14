<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccountingTrs
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
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl
        Me.CEShowAdj = New DevExpress.XtraEditors.CheckEdit
        Me.TEAcc = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.TEDesc = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.GCJournalDet = New DevExpress.XtraGrid.GridControl
        Me.GVJournalDet = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Me.GridColumnIdJurnal = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnJurnalNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnJournalDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdReport = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnAdjNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnEntry = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.DETo = New DevExpress.XtraEditors.DateEdit
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit
        Me.BView = New DevExpress.XtraEditors.SimpleButton
        Me.BalanceMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SMViewTransaction = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.CEShowAdj.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEAcc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCJournalDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVJournalDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.DETo.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DETo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BalanceMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl5)
        Me.PanelControl1.Controls.Add(Me.CEShowAdj)
        Me.PanelControl1.Controls.Add(Me.TEAcc)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.TEDesc)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(878, 90)
        Me.PanelControl1.TabIndex = 0
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(15, 66)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl5.TabIndex = 12
        Me.LabelControl5.Text = "Option"
        '
        'CEShowAdj
        '
        Me.CEShowAdj.EditValue = True
        Me.CEShowAdj.Location = New System.Drawing.Point(79, 63)
        Me.CEShowAdj.Name = "CEShowAdj"
        Me.CEShowAdj.Properties.Caption = "Full Entry"
        Me.CEShowAdj.Size = New System.Drawing.Size(81, 19)
        Me.CEShowAdj.TabIndex = 10
        '
        'TEAcc
        '
        Me.TEAcc.Location = New System.Drawing.Point(81, 8)
        Me.TEAcc.Name = "TEAcc"
        Me.TEAcc.Properties.ReadOnly = True
        Me.TEAcc.Size = New System.Drawing.Size(217, 20)
        Me.TEAcc.TabIndex = 11
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(15, 11)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl4.TabIndex = 10
        Me.LabelControl4.Text = "Account"
        '
        'TEDesc
        '
        Me.TEDesc.Location = New System.Drawing.Point(81, 37)
        Me.TEDesc.Name = "TEDesc"
        Me.TEDesc.Properties.ReadOnly = True
        Me.TEDesc.Size = New System.Drawing.Size(315, 20)
        Me.TEDesc.TabIndex = 9
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(15, 40)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl1.TabIndex = 8
        Me.LabelControl1.Text = "Description"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.GCJournalDet)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 90)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(878, 249)
        Me.PanelControl2.TabIndex = 1
        '
        'GCJournalDet
        '
        Me.GCJournalDet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCJournalDet.Location = New System.Drawing.Point(2, 2)
        Me.GCJournalDet.MainView = Me.GVJournalDet
        Me.GCJournalDet.Name = "GCJournalDet"
        Me.GCJournalDet.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEdit2})
        Me.GCJournalDet.Size = New System.Drawing.Size(874, 245)
        Me.GCJournalDet.TabIndex = 13
        Me.GCJournalDet.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVJournalDet})
        '
        'GVJournalDet
        '
        Me.GVJournalDet.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumnIdJurnal, Me.GridColumnJurnalNumber, Me.GridColumnJournalDate, Me.GridColumnIdReport, Me.GridColumnAdjNumber, Me.GridColumnEntry})
        Me.GVJournalDet.GridControl = Me.GCJournalDet
        Me.GVJournalDet.GroupCount = 1
        Me.GVJournalDet.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debit", Me.GridColumn13, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "credit", Me.GridColumn14, "{0:N2}")})
        Me.GVJournalDet.Name = "GVJournalDet"
        Me.GVJournalDet.OptionsBehavior.Editable = False
        Me.GVJournalDet.OptionsView.ShowFooter = True
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
        Me.GridColumn11.OptionsColumn.ReadOnly = True
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 1
        Me.GridColumn11.Width = 66
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Note"
        Me.GridColumn12.FieldName = "note"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 3
        Me.GridColumn12.Width = 207
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
        Me.GridColumn13.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debit", "{0:N2}")})
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 4
        Me.GridColumn13.Width = 94
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
        Me.GridColumn14.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "credit", "{0:N2}")})
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 5
        Me.GridColumn14.Width = 97
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
        '
        'GridColumnJurnalNumber
        '
        Me.GridColumnJurnalNumber.Caption = "Journal Number"
        Me.GridColumnJurnalNumber.FieldName = "acc_trans_number"
        Me.GridColumnJurnalNumber.Name = "GridColumnJurnalNumber"
        Me.GridColumnJurnalNumber.Width = 98
        '
        'GridColumnJournalDate
        '
        Me.GridColumnJournalDate.Caption = "Journal Date"
        Me.GridColumnJournalDate.FieldName = "date_created"
        Me.GridColumnJournalDate.Name = "GridColumnJournalDate"
        Me.GridColumnJournalDate.Visible = True
        Me.GridColumnJournalDate.VisibleIndex = 0
        Me.GridColumnJournalDate.Width = 63
        '
        'GridColumnIdReport
        '
        Me.GridColumnIdReport.Caption = "Id Report"
        Me.GridColumnIdReport.FieldName = "id_report"
        Me.GridColumnIdReport.Name = "GridColumnIdReport"
        '
        'GridColumnAdjNumber
        '
        Me.GridColumnAdjNumber.Caption = "Adjustment"
        Me.GridColumnAdjNumber.FieldName = "number_adj"
        Me.GridColumnAdjNumber.Name = "GridColumnAdjNumber"
        Me.GridColumnAdjNumber.Visible = True
        Me.GridColumnAdjNumber.VisibleIndex = 2
        Me.GridColumnAdjNumber.Width = 76
        '
        'GridColumnEntry
        '
        Me.GridColumnEntry.Caption = "Entry"
        Me.GridColumnEntry.FieldName = "entry"
        Me.GridColumnEntry.Name = "GridColumnEntry"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BPrint)
        Me.PanelControl3.Controls.Add(Me.LabelControl2)
        Me.PanelControl3.Controls.Add(Me.LabelControl3)
        Me.PanelControl3.Controls.Add(Me.DETo)
        Me.PanelControl3.Controls.Add(Me.DEFrom)
        Me.PanelControl3.Controls.Add(Me.BView)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 339)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(878, 41)
        Me.PanelControl3.TabIndex = 2
        '
        'BPrint
        '
        Me.BPrint.Location = New System.Drawing.Point(588, 9)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(79, 22)
        Me.BPrint.TabIndex = 10
        Me.BPrint.Text = "Print"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(245, 13)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(17, 13)
        Me.LabelControl2.TabIndex = 9
        Me.LabelControl2.Text = "to :"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(23, 13)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl3.TabIndex = 8
        Me.LabelControl3.Text = "From :"
        '
        'DETo
        '
        Me.DETo.EditValue = Nothing
        Me.DETo.Location = New System.Drawing.Point(273, 10)
        Me.DETo.Name = "DETo"
        Me.DETo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETo.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.DETo.Size = New System.Drawing.Size(172, 20)
        Me.DETo.TabIndex = 7
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(60, 10)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.DEFrom.Size = New System.Drawing.Size(172, 20)
        Me.DEFrom.TabIndex = 6
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(463, 9)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(119, 22)
        Me.BView.TabIndex = 5
        Me.BView.Text = "View Transaction"
        '
        'BalanceMenu
        '
        Me.BalanceMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMViewTransaction})
        Me.BalanceMenu.Name = "ContextMenuStripYM"
        Me.BalanceMenu.Size = New System.Drawing.Size(130, 26)
        '
        'SMViewTransaction
        '
        Me.SMViewTransaction.Name = "SMViewTransaction"
        Me.SMViewTransaction.Size = New System.Drawing.Size(129, 22)
        Me.SMViewTransaction.Text = "View Entry"
        '
        'FormAccoutningTrs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(878, 380)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormAccoutningTrs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transaction"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.CEShowAdj.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEAcc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCJournalDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVJournalDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.DETo.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DETo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BalanceMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEAcc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDesc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
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
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DETo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnIdReport As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAdjNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CEShowAdj As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BalanceMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SMViewTransaction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GridColumnEntry As DevExpress.XtraGrid.Columns.GridColumn
End Class
