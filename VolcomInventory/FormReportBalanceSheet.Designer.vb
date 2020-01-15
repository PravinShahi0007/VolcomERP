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
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPGeneralLedger = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPBalanceSheet = New DevExpress.XtraTab.XtraTabPage()
        Me.TCIDAcc = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCAccount = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCDescription = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCThisMonth = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCPrevMonth = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.treeListBand1 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.treeListBand2 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TLBalanceSheet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
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
        Me.TLBalanceSheet.Bands.AddRange(New DevExpress.XtraTreeList.Columns.TreeListBand() {Me.treeListBand1, Me.treeListBand2})
        Me.TLBalanceSheet.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.TCIDAcc, Me.TCAccount, Me.TCDescription, Me.TCThisMonth, Me.TCPrevMonth})
        Me.TLBalanceSheet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLBalanceSheet.Location = New System.Drawing.Point(0, 0)
        Me.TLBalanceSheet.Name = "TLBalanceSheet"
        Me.TLBalanceSheet.Size = New System.Drawing.Size(894, 438)
        Me.TLBalanceSheet.TabIndex = 1
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
        'TCIDAcc
        '
        Me.TCIDAcc.Caption = "ID"
        Me.TCIDAcc.FieldName = "id_acc"
        Me.TCIDAcc.Name = "TCIDAcc"
        '
        'TCAccount
        '
        Me.TCAccount.Caption = "Account"
        Me.TCAccount.FieldName = "acc_name"
        Me.TCAccount.Name = "TCAccount"
        Me.TCAccount.Visible = True
        Me.TCAccount.VisibleIndex = 0
        Me.TCAccount.Width = 175
        '
        'TCDescription
        '
        Me.TCDescription.Caption = "Description"
        Me.TCDescription.FieldName = "acc_description"
        Me.TCDescription.Name = "TCDescription"
        Me.TCDescription.Visible = True
        Me.TCDescription.VisibleIndex = 1
        Me.TCDescription.Width = 175
        '
        'TCThisMonth
        '
        Me.TCThisMonth.Caption = "This Month"
        Me.TCThisMonth.FieldName = "credit"
        Me.TCThisMonth.Name = "TCThisMonth"
        Me.TCThisMonth.Visible = True
        Me.TCThisMonth.VisibleIndex = 3
        Me.TCThisMonth.Width = 175
        '
        'TCPrevMonth
        '
        Me.TCPrevMonth.Caption = "Previous Month"
        Me.TCPrevMonth.FieldName = "debit"
        Me.TCPrevMonth.Name = "TCPrevMonth"
        Me.TCPrevMonth.Visible = True
        Me.TCPrevMonth.VisibleIndex = 2
        Me.TCPrevMonth.Width = 175
        '
        'treeListBand1
        '
        Me.treeListBand1.Caption = "Account"
        Me.treeListBand1.Columns.Add(Me.TCAccount)
        Me.treeListBand1.Columns.Add(Me.TCDescription)
        Me.treeListBand1.Name = "treeListBand1"
        '
        'treeListBand2
        '
        Me.treeListBand2.Caption = "Amount"
        Me.treeListBand2.Columns.Add(Me.TCPrevMonth)
        Me.treeListBand2.Columns.Add(Me.TCThisMonth)
        Me.treeListBand2.Name = "treeListBand2"
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
        Me.XTPBalanceSheet.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TLBalanceSheet As DevExpress.XtraTreeList.TreeList
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPGeneralLedger As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPBalanceSheet As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents treeListBand1 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents TCAccount As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCDescription As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents treeListBand2 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents TCPrevMonth As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCThisMonth As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCIDAcc As DevExpress.XtraTreeList.Columns.TreeListColumn
End Class
