<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccountingJournalAdj
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
        Me.GCAccTrans = New DevExpress.XtraGrid.GridControl
        Me.GVAccTrans = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdTrans = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.IdJournal = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColJournalNumber = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GCAccTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAccTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCAccTrans
        '
        Me.GCAccTrans.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAccTrans.Location = New System.Drawing.Point(0, 0)
        Me.GCAccTrans.MainView = Me.GVAccTrans
        Me.GCAccTrans.Name = "GCAccTrans"
        Me.GCAccTrans.Size = New System.Drawing.Size(774, 377)
        Me.GCAccTrans.TabIndex = 7
        Me.GCAccTrans.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAccTrans})
        '
        'GVAccTrans
        '
        Me.GVAccTrans.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.ColIdTrans, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.IdJournal, Me.ColJournalNumber})
        Me.GVAccTrans.GridControl = Me.GCAccTrans
        Me.GVAccTrans.Name = "GVAccTrans"
        Me.GVAccTrans.OptionsBehavior.Editable = False
        Me.GVAccTrans.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Trans"
        Me.GridColumn1.FieldName = "id_acc_trans_adj"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'ColIdTrans
        '
        Me.ColIdTrans.Caption = "ID Trans"
        Me.ColIdTrans.FieldName = "id_acc_trans"
        Me.ColIdTrans.Name = "ColIdTrans"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Number"
        Me.GridColumn2.FieldName = "acc_trans_adj_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 104
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Date Created"
        Me.GridColumn3.FieldName = "date_created"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 4
        Me.GridColumn3.Width = 90
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "User Entry"
        Me.GridColumn4.FieldName = "employee_name"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 90
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
        Me.GridColumn6.VisibleIndex = 5
        Me.GridColumn6.Width = 97
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Note"
        Me.GridColumn7.FieldName = "acc_trans_adj_note"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 2
        Me.GridColumn7.Width = 275
        '
        'IdJournal
        '
        Me.IdJournal.Caption = "Id Journal"
        Me.IdJournal.FieldName = "id_acc_trans"
        Me.IdJournal.Name = "IdJournal"
        '
        'ColJournalNumber
        '
        Me.ColJournalNumber.Caption = "Journal Reff Number"
        Me.ColJournalNumber.FieldName = "acc_trans_number"
        Me.ColJournalNumber.Name = "ColJournalNumber"
        Me.ColJournalNumber.Visible = True
        Me.ColJournalNumber.VisibleIndex = 1
        Me.ColJournalNumber.Width = 120
        '
        'FormAccountingJournalAdj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 377)
        Me.Controls.Add(Me.GCAccTrans)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAccountingJournalAdj"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Adjustment Journal"
        CType(Me.GCAccTrans, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAccTrans, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCAccTrans As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAccTrans As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IdJournal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColJournalNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdTrans As DevExpress.XtraGrid.Columns.GridColumn
End Class
