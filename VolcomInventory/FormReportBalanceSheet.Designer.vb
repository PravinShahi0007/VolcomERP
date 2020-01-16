<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportBalanceSheet
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
        Me.TLBalanceSheet = New DevExpress.XtraTreeList.TreeList()
        Me.treeListBand3 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.TCLAccount = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLDescription = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.treeListBand4 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.TCLDebit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLCreadit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCIDAcc = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCIDAccParent = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCAllChild = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.treeListBand1 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.treeListBand2 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.XTCBalanceSheet = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPGeneralLedger = New DevExpress.XtraTab.XtraTabPage()
        Me.TLLedger = New DevExpress.XtraTreeList.TreeList()
        Me.treeListBand5 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.TCLAccName = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLAccDescription = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.treeListBand6 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.TCLedDebit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLedCredit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLIDAcc = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLIdAccParent = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLedIDAllChild = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.XTPBalanceSheet = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TLBalanceSheet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCBalanceSheet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCBalanceSheet.SuspendLayout()
        Me.XTPGeneralLedger.SuspendLayout()
        CType(Me.TLLedger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPBalanceSheet.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(900, 54)
        Me.PanelControl1.TabIndex = 0
        '
        'TLBalanceSheet
        '
        Me.TLBalanceSheet.Bands.AddRange(New DevExpress.XtraTreeList.Columns.TreeListBand() {Me.treeListBand3, Me.treeListBand4})
        Me.TLBalanceSheet.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.TCIDAcc, Me.TCIDAccParent, Me.TCLAccount, Me.TCLDescription, Me.TCLCreadit, Me.TCLDebit, Me.TCAllChild})
        Me.TLBalanceSheet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLBalanceSheet.Location = New System.Drawing.Point(0, 0)
        Me.TLBalanceSheet.Name = "TLBalanceSheet"
        Me.TLBalanceSheet.OptionsBehavior.EnableFiltering = True
        Me.TLBalanceSheet.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Smart
        Me.TLBalanceSheet.OptionsFilter.ShowAllValuesInFilterPopup = True
        Me.TLBalanceSheet.OptionsFind.AllowFindPanel = True
        Me.TLBalanceSheet.OptionsView.ShowBandsMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.TLBalanceSheet.Size = New System.Drawing.Size(894, 438)
        Me.TLBalanceSheet.TabIndex = 1
        '
        'treeListBand3
        '
        Me.treeListBand3.Caption = "Account"
        Me.treeListBand3.Name = "treeListBand3"
        Me.treeListBand3.Width = 423
        '
        'TCLAccount
        '
        Me.TCLAccount.Caption = "Account"
        Me.TCLAccount.FieldName = "acc_name"
        Me.TCLAccount.Name = "TCLAccount"
        Me.TCLAccount.Visible = True
        Me.TCLAccount.VisibleIndex = 0
        Me.TCLAccount.Width = 211
        '
        'TCLDescription
        '
        Me.TCLDescription.Caption = "Description"
        Me.TCLDescription.FieldName = "acc_description"
        Me.TCLDescription.Name = "TCLDescription"
        Me.TCLDescription.Visible = True
        Me.TCLDescription.VisibleIndex = 1
        Me.TCLDescription.Width = 212
        '
        'treeListBand4
        '
        Me.treeListBand4.Caption = "Amount"
        Me.treeListBand4.Name = "treeListBand4"
        Me.treeListBand4.Width = 453
        '
        'TCLDebit
        '
        Me.TCLDebit.Caption = "Previous Month"
        Me.TCLDebit.FieldName = "debit"
        Me.TCLDebit.Format.FormatString = "N2"
        Me.TCLDebit.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TCLDebit.Name = "TCLDebit"
        Me.TCLDebit.Visible = True
        Me.TCLDebit.VisibleIndex = 2
        Me.TCLDebit.Width = 227
        '
        'TCLCreadit
        '
        Me.TCLCreadit.Caption = "This Month"
        Me.TCLCreadit.FieldName = "credit"
        Me.TCLCreadit.Format.FormatString = "N2"
        Me.TCLCreadit.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TCLCreadit.Name = "TCLCreadit"
        Me.TCLCreadit.Visible = True
        Me.TCLCreadit.VisibleIndex = 3
        Me.TCLCreadit.Width = 226
        '
        'TCIDAcc
        '
        Me.TCIDAcc.Caption = "ID"
        Me.TCIDAcc.FieldName = "id_acc"
        Me.TCIDAcc.Name = "TCIDAcc"
        '
        'TCIDAccParent
        '
        Me.TCIDAccParent.Caption = "ID Acc Parent"
        Me.TCIDAccParent.FieldName = "id_acc_parent"
        Me.TCIDAccParent.Name = "TCIDAccParent"
        '
        'TCAllChild
        '
        Me.TCAllChild.Caption = "ID All Child"
        Me.TCAllChild.FieldName = "id_all_child"
        Me.TCAllChild.Name = "TCAllChild"
        '
        'treeListBand1
        '
        Me.treeListBand1.Caption = "Account"
        Me.treeListBand1.Columns.Add(Me.TCLAccount)
        Me.treeListBand1.Columns.Add(Me.TCLDescription)
        Me.treeListBand1.Name = "treeListBand1"
        '
        'treeListBand2
        '
        Me.treeListBand2.Caption = "Amount"
        Me.treeListBand2.Columns.Add(Me.TCLDebit)
        Me.treeListBand2.Columns.Add(Me.TCLCreadit)
        Me.treeListBand2.Name = "treeListBand2"
        '
        'XTCBalanceSheet
        '
        Me.XTCBalanceSheet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCBalanceSheet.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCBalanceSheet.Location = New System.Drawing.Point(0, 54)
        Me.XTCBalanceSheet.Name = "XTCBalanceSheet"
        Me.XTCBalanceSheet.SelectedTabPage = Me.XTPGeneralLedger
        Me.XTCBalanceSheet.Size = New System.Drawing.Size(900, 466)
        Me.XTCBalanceSheet.TabIndex = 2
        Me.XTCBalanceSheet.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPGeneralLedger, Me.XTPBalanceSheet})
        '
        'XTPGeneralLedger
        '
        Me.XTPGeneralLedger.Controls.Add(Me.TLLedger)
        Me.XTPGeneralLedger.Name = "XTPGeneralLedger"
        Me.XTPGeneralLedger.Size = New System.Drawing.Size(894, 438)
        Me.XTPGeneralLedger.Text = "Ledger"
        '
        'TLLedger
        '
        Me.TLLedger.Bands.AddRange(New DevExpress.XtraTreeList.Columns.TreeListBand() {Me.treeListBand5, Me.treeListBand6})
        Me.TLLedger.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.TCLIDAcc, Me.TCLIdAccParent, Me.TCLAccName, Me.TCLAccDescription, Me.TCLedDebit, Me.TCLedCredit, Me.TCLedIDAllChild})
        Me.TLLedger.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLLedger.Location = New System.Drawing.Point(0, 0)
        Me.TLLedger.Name = "TLLedger"
        Me.TLLedger.OptionsBehavior.EnableFiltering = True
        Me.TLLedger.OptionsFind.AllowFindPanel = True
        Me.TLLedger.Size = New System.Drawing.Size(894, 438)
        Me.TLLedger.TabIndex = 0
        '
        'treeListBand5
        '
        Me.treeListBand5.Caption = "Account"
        Me.treeListBand5.Columns.Add(Me.TCLAccName)
        Me.treeListBand5.Columns.Add(Me.TCLAccDescription)
        Me.treeListBand5.Name = "treeListBand5"
        Me.treeListBand5.Width = 427
        '
        'TCLAccName
        '
        Me.TCLAccName.Caption = "Account"
        Me.TCLAccName.FieldName = "acc_name"
        Me.TCLAccName.Name = "TCLAccName"
        Me.TCLAccName.Visible = True
        Me.TCLAccName.VisibleIndex = 0
        Me.TCLAccName.Width = 213
        '
        'TCLAccDescription
        '
        Me.TCLAccDescription.Caption = "Description"
        Me.TCLAccDescription.FieldName = "acc_description"
        Me.TCLAccDescription.Name = "TCLAccDescription"
        Me.TCLAccDescription.Visible = True
        Me.TCLAccDescription.VisibleIndex = 1
        Me.TCLAccDescription.Width = 214
        '
        'treeListBand6
        '
        Me.treeListBand6.Caption = "Amount"
        Me.treeListBand6.Columns.Add(Me.TCLedDebit)
        Me.treeListBand6.Columns.Add(Me.TCLedCredit)
        Me.treeListBand6.Name = "treeListBand6"
        Me.treeListBand6.Width = 449
        '
        'TCLedDebit
        '
        Me.TCLedDebit.Caption = "Debit"
        Me.TCLedDebit.FieldName = "debit"
        Me.TCLedDebit.Format.FormatString = "N2"
        Me.TCLedDebit.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TCLedDebit.Name = "TCLedDebit"
        Me.TCLedDebit.Visible = True
        Me.TCLedDebit.VisibleIndex = 2
        Me.TCLedDebit.Width = 226
        '
        'TCLedCredit
        '
        Me.TCLedCredit.Caption = "Credit"
        Me.TCLedCredit.FieldName = "credit"
        Me.TCLedCredit.Format.FormatString = "N2"
        Me.TCLedCredit.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TCLedCredit.Name = "TCLedCredit"
        Me.TCLedCredit.Visible = True
        Me.TCLedCredit.VisibleIndex = 3
        Me.TCLedCredit.Width = 223
        '
        'TCLIDAcc
        '
        Me.TCLIDAcc.Caption = "ID Acc"
        Me.TCLIDAcc.FieldName = "id_acc"
        Me.TCLIDAcc.Name = "TCLIDAcc"
        '
        'TCLIdAccParent
        '
        Me.TCLIdAccParent.Caption = "ID Acc Parent"
        Me.TCLIdAccParent.FieldName = "id_acc_parent"
        Me.TCLIdAccParent.Name = "TCLIdAccParent"
        '
        'TCLedIDAllChild
        '
        Me.TCLedIDAllChild.Caption = "ID All Child"
        Me.TCLedIDAllChild.FieldName = "id_all_child"
        Me.TCLedIDAllChild.Name = "TCLedIDAllChild"
        '
        'XTPBalanceSheet
        '
        Me.XTPBalanceSheet.Controls.Add(Me.TLBalanceSheet)
        Me.XTPBalanceSheet.Name = "XTPBalanceSheet"
        Me.XTPBalanceSheet.Size = New System.Drawing.Size(894, 438)
        Me.XTPBalanceSheet.Text = "Balance Sheet"
        '
        'FormReportBalanceSheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 520)
        Me.Controls.Add(Me.XTCBalanceSheet)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormReportBalanceSheet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Balance Sheet"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TLBalanceSheet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCBalanceSheet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCBalanceSheet.ResumeLayout(False)
        Me.XTPGeneralLedger.ResumeLayout(False)
        CType(Me.TLLedger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPBalanceSheet.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TLBalanceSheet As DevExpress.XtraTreeList.TreeList
    Friend WithEvents XTCBalanceSheet As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPGeneralLedger As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPBalanceSheet As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents treeListBand1 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents TCLAccount As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLDescription As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents treeListBand2 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents TCLDebit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLCreadit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCIDAcc As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCIDAccParent As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCAllChild As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TLLedger As DevExpress.XtraTreeList.TreeList
    Friend WithEvents treeListBand5 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents TCLAccName As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLAccDescription As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents treeListBand6 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents TCLedDebit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLedCredit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLIDAcc As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLIdAccParent As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents treeListBand3 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents treeListBand4 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents TCLedIDAllChild As DevExpress.XtraTreeList.Columns.TreeListColumn
End Class
