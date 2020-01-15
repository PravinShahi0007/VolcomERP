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
        Me.treeListBand4 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.TCIDAcc = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCIDAccParent = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLAccount = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLDescription = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLCreadit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLDebit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCAllChild = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.treeListBand1 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.treeListBand2 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPGeneralLedger = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPBalanceSheet = New DevExpress.XtraTab.XtraTabPage()
        Me.TLLedger = New DevExpress.XtraTreeList.TreeList()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TLBalanceSheet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPGeneralLedger.SuspendLayout()
        Me.XTPBalanceSheet.SuspendLayout()
        CType(Me.TLLedger, System.ComponentModel.ISupportInitialize).BeginInit()
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
        '
        'treeListBand4
        '
        Me.treeListBand4.Caption = "Amount"
        Me.treeListBand4.Name = "treeListBand4"
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
        'TCLAccount
        '
        Me.TCLAccount.Caption = "Account"
        Me.TCLAccount.FieldName = "acc_name"
        Me.TCLAccount.Name = "TCLAccount"
        Me.TCLAccount.Visible = True
        Me.TCLAccount.VisibleIndex = 0
        Me.TCLAccount.Width = 175
        '
        'TCLDescription
        '
        Me.TCLDescription.Caption = "Description"
        Me.TCLDescription.FieldName = "acc_description"
        Me.TCLDescription.Name = "TCLDescription"
        Me.TCLDescription.Visible = True
        Me.TCLDescription.VisibleIndex = 1
        Me.TCLDescription.Width = 175
        '
        'TCLCreadit
        '
        Me.TCLCreadit.Caption = "Credit"
        Me.TCLCreadit.FieldName = "credit"
        Me.TCLCreadit.Format.FormatString = "N2"
        Me.TCLCreadit.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TCLCreadit.Name = "TCLCreadit"
        Me.TCLCreadit.Visible = True
        Me.TCLCreadit.VisibleIndex = 3
        Me.TCLCreadit.Width = 175
        '
        'TCLDebit
        '
        Me.TCLDebit.Caption = "Debit"
        Me.TCLDebit.FieldName = "debit"
        Me.TCLDebit.Format.FormatString = "N2"
        Me.TCLDebit.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TCLDebit.Name = "TCLDebit"
        Me.TCLDebit.Visible = True
        Me.TCLDebit.VisibleIndex = 2
        Me.TCLDebit.Width = 175
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
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 54)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPGeneralLedger
        Me.XtraTabControl1.Size = New System.Drawing.Size(900, 466)
        Me.XtraTabControl1.TabIndex = 2
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPGeneralLedger, Me.XTPBalanceSheet})
        '
        'XTPGeneralLedger
        '
        Me.XTPGeneralLedger.Controls.Add(Me.TLLedger)
        Me.XTPGeneralLedger.Name = "XTPGeneralLedger"
        Me.XTPGeneralLedger.Size = New System.Drawing.Size(894, 438)
        Me.XTPGeneralLedger.Text = "Ledger"
        '
        'XTPBalanceSheet
        '
        Me.XTPBalanceSheet.Controls.Add(Me.TLBalanceSheet)
        Me.XTPBalanceSheet.Name = "XTPBalanceSheet"
        Me.XTPBalanceSheet.Size = New System.Drawing.Size(894, 438)
        Me.XTPBalanceSheet.Text = "Balance Sheet"
        '
        'TLLedger
        '
        Me.TLLedger.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLLedger.Location = New System.Drawing.Point(0, 0)
        Me.TLLedger.Name = "TLLedger"
        Me.TLLedger.Size = New System.Drawing.Size(894, 438)
        Me.TLLedger.TabIndex = 0
        '
        'FormReportBalanceSheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 520)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormReportBalanceSheet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Balance Sheet"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TLBalanceSheet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPGeneralLedger.ResumeLayout(False)
        Me.XTPBalanceSheet.ResumeLayout(False)
        CType(Me.TLLedger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TLBalanceSheet As DevExpress.XtraTreeList.TreeList
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
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
    Friend WithEvents treeListBand3 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents treeListBand4 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents TLLedger As DevExpress.XtraTreeList.TreeList
End Class
