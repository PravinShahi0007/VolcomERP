<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccountingDraftJournal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAccountingDraftJournal))
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAcc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAccDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDebit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCredit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDraft = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.BtnDelete)
        Me.PanelControlNav.Controls.Add(Me.BtnAdd)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(834, 41)
        Me.PanelControlNav.TabIndex = 0
        '
        'BtnDelete
        '
        Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
        Me.BtnDelete.Location = New System.Drawing.Point(670, 2)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(81, 37)
        Me.BtnDelete.TabIndex = 3
        Me.BtnDelete.Text = "Delete"
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(751, 2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(81, 37)
        Me.BtnAdd.TabIndex = 2
        Me.BtnAdd.Text = "Add"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 41)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(834, 441)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnAcc, Me.GridColumnAccDesc, Me.GridColumnReportNumber, Me.GridColumnCompName, Me.GridColumnDebit, Me.GridColumnCredit, Me.GridColumnNote, Me.GridColumnIdDraft})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 59
        '
        'GridColumnAcc
        '
        Me.GridColumnAcc.Caption = "Account"
        Me.GridColumnAcc.FieldName = "acc_name"
        Me.GridColumnAcc.Name = "GridColumnAcc"
        Me.GridColumnAcc.Visible = True
        Me.GridColumnAcc.VisibleIndex = 1
        Me.GridColumnAcc.Width = 162
        '
        'GridColumnAccDesc
        '
        Me.GridColumnAccDesc.Caption = "Account Description"
        Me.GridColumnAccDesc.FieldName = "acc_description"
        Me.GridColumnAccDesc.Name = "GridColumnAccDesc"
        Me.GridColumnAccDesc.Visible = True
        Me.GridColumnAccDesc.VisibleIndex = 2
        Me.GridColumnAccDesc.Width = 269
        '
        'GridColumnReportNumber
        '
        Me.GridColumnReportNumber.Caption = "Ref."
        Me.GridColumnReportNumber.FieldName = "report_number"
        Me.GridColumnReportNumber.Name = "GridColumnReportNumber"
        Me.GridColumnReportNumber.OptionsColumn.AllowEdit = False
        Me.GridColumnReportNumber.Visible = True
        Me.GridColumnReportNumber.VisibleIndex = 3
        Me.GridColumnReportNumber.Width = 113
        '
        'GridColumnCompName
        '
        Me.GridColumnCompName.Caption = "Supplier/Customer"
        Me.GridColumnCompName.FieldName = "comp"
        Me.GridColumnCompName.Name = "GridColumnCompName"
        Me.GridColumnCompName.Visible = True
        Me.GridColumnCompName.VisibleIndex = 5
        Me.GridColumnCompName.Width = 151
        '
        'GridColumnDebit
        '
        Me.GridColumnDebit.Caption = "Debit"
        Me.GridColumnDebit.DisplayFormat.FormatString = "N2"
        Me.GridColumnDebit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDebit.FieldName = "debit"
        Me.GridColumnDebit.Name = "GridColumnDebit"
        Me.GridColumnDebit.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debit", "{0:N2}")})
        Me.GridColumnDebit.Visible = True
        Me.GridColumnDebit.VisibleIndex = 6
        Me.GridColumnDebit.Width = 238
        '
        'GridColumnCredit
        '
        Me.GridColumnCredit.Caption = "Credit"
        Me.GridColumnCredit.DisplayFormat.FormatString = "N2"
        Me.GridColumnCredit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCredit.FieldName = "credit"
        Me.GridColumnCredit.Name = "GridColumnCredit"
        Me.GridColumnCredit.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "credit", "{0:N2}")})
        Me.GridColumnCredit.Visible = True
        Me.GridColumnCredit.VisibleIndex = 7
        Me.GridColumnCredit.Width = 279
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "Note"
        Me.GridColumnNote.FieldName = "acc_trans_det_note"
        Me.GridColumnNote.Name = "GridColumnNote"
        Me.GridColumnNote.Visible = True
        Me.GridColumnNote.VisibleIndex = 4
        Me.GridColumnNote.Width = 361
        '
        'GridColumnIdDraft
        '
        Me.GridColumnIdDraft.Caption = "Id Draft"
        Me.GridColumnIdDraft.FieldName = "id_acc_trans_draft"
        Me.GridColumnIdDraft.Name = "GridColumnIdDraft"
        Me.GridColumnIdDraft.OptionsColumn.AllowEdit = False
        '
        'FormAccountingDraftJournal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 482)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControlNav)
        Me.MinimizeBox = False
        Me.Name = "FormAccountingDraftJournal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Draft Journal"
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAcc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAccDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDebit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCredit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnIdDraft As DevExpress.XtraGrid.Columns.GridColumn
End Class
