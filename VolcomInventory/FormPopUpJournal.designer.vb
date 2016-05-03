<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpJournal
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
        Me.GroupGeneral = New DevExpress.XtraEditors.GroupControl
        Me.GCAccTrans = New DevExpress.XtraGrid.GridControl
        Me.GVAccTrans = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCJournalDet = New DevExpress.XtraGrid.GridControl
        Me.GVJournalDet = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RTE1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RTE2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneral.SuspendLayout()
        CType(Me.GCAccTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAccTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCJournalDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVJournalDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RTE1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RTE2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.BtnCancel)
        Me.PanelControl2.Controls.Add(Me.BtnSave)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 370)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(818, 45)
        Me.PanelControl2.TabIndex = 33
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(663, 10)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(70, 23)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(739, 10)
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
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupGeneral)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GCJournalDet)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(818, 370)
        Me.SplitContainerControl1.SplitterPosition = 216
        Me.SplitContainerControl1.TabIndex = 32
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupGeneral
        '
        Me.GroupGeneral.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupGeneral.Controls.Add(Me.GCAccTrans)
        Me.GroupGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupGeneral.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneral.Name = "GroupGeneral"
        Me.GroupGeneral.Size = New System.Drawing.Size(818, 216)
        Me.GroupGeneral.TabIndex = 16
        Me.GroupGeneral.Text = "Entry Journal"
        '
        'GCAccTrans
        '
        Me.GCAccTrans.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAccTrans.Location = New System.Drawing.Point(2, 22)
        Me.GCAccTrans.MainView = Me.GVAccTrans
        Me.GCAccTrans.Name = "GCAccTrans"
        Me.GCAccTrans.Size = New System.Drawing.Size(814, 192)
        Me.GCAccTrans.TabIndex = 7
        Me.GCAccTrans.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAccTrans})
        '
        'GVAccTrans
        '
        Me.GVAccTrans.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.GVAccTrans.GridControl = Me.GCAccTrans
        Me.GVAccTrans.Name = "GVAccTrans"
        Me.GVAccTrans.OptionsBehavior.Editable = False
        Me.GVAccTrans.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Trans"
        Me.GridColumn1.FieldName = "id_acc_trans"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Number"
        Me.GridColumn2.FieldName = "acc_trans_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 108
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Date Created"
        Me.GridColumn3.FieldName = "date_created"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        Me.GridColumn3.Width = 99
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "User Entry"
        Me.GridColumn4.FieldName = "employee_name"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 99
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Id report Status"
        Me.GridColumn5.FieldName = "id_report_status"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Status"
        Me.GridColumn6.FieldName = "report_status"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 102
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Note"
        Me.GridColumn7.FieldName = "acc_trans_note"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 1
        Me.GridColumn7.Width = 300
        '
        'GCJournalDet
        '
        Me.GCJournalDet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCJournalDet.Location = New System.Drawing.Point(0, 0)
        Me.GCJournalDet.MainView = Me.GVJournalDet
        Me.GCJournalDet.Name = "GCJournalDet"
        Me.GCJournalDet.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RTE1, Me.RTE2})
        Me.GCJournalDet.Size = New System.Drawing.Size(818, 149)
        Me.GCJournalDet.TabIndex = 12
        Me.GCJournalDet.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVJournalDet})
        '
        'GVJournalDet
        '
        Me.GVJournalDet.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14})
        Me.GVJournalDet.GridControl = Me.GCJournalDet
        Me.GVJournalDet.Name = "GVJournalDet"
        Me.GVJournalDet.OptionsBehavior.ReadOnly = True
        Me.GVJournalDet.OptionsView.ShowFooter = True
        Me.GVJournalDet.OptionsView.ShowGroupPanel = False
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn8.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn8.Caption = "No."
        Me.GridColumn8.FieldName = "no"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 0
        Me.GridColumn8.Width = 40
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
        Me.GridColumn11.Width = 100
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Note"
        Me.GridColumn12.FieldName = "note"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 2
        Me.GridColumn12.Width = 300
        '
        'GridColumn13
        '
        Me.GridColumn13.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn13.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn13.Caption = "Debit"
        Me.GridColumn13.ColumnEdit = Me.RTE1
        Me.GridColumn13.DisplayFormat.FormatString = "N2"
        Me.GridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn13.FieldName = "debit"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debit", "{0:N2}")})
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 3
        Me.GridColumn13.Width = 138
        '
        'RTE1
        '
        Me.RTE1.AutoHeight = False
        Me.RTE1.DisplayFormat.FormatString = "N2"
        Me.RTE1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RTE1.EditFormat.FormatString = "N2"
        Me.RTE1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RTE1.Mask.EditMask = "N2"
        Me.RTE1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RTE1.Mask.UseMaskAsDisplayFormat = True
        Me.RTE1.Name = "RTE1"
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn14.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn14.Caption = "Credit"
        Me.GridColumn14.ColumnEdit = Me.RTE2
        Me.GridColumn14.DisplayFormat.FormatString = "N2"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn14.FieldName = "credit"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "credit", "{0:N2}")})
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 4
        Me.GridColumn14.Width = 134
        '
        'RTE2
        '
        Me.RTE2.AutoHeight = False
        Me.RTE2.DisplayFormat.FormatString = "N2"
        Me.RTE2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RTE2.EditFormat.FormatString = "N2"
        Me.RTE2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RTE2.Mask.EditMask = "N2"
        Me.RTE2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RTE2.Mask.UseMaskAsDisplayFormat = True
        Me.RTE2.Name = "RTE2"
        '
        'FormPopUpJournal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 415)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpJournal"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Entry"
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneral.ResumeLayout(False)
        CType(Me.GCAccTrans, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAccTrans, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCJournalDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVJournalDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RTE1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RTE2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupGeneral As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCAccTrans As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAccTrans As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCJournalDet As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVJournalDet As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RTE1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RTE2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
End Class
