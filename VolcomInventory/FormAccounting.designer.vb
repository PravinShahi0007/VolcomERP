<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccounting
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
        Me.components = New System.ComponentModel.Container()
        Me.XTCGeneral = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPAccount = New DevExpress.XtraTab.XtraTabPage()
        Me.GCAcc = New DevExpress.XtraGrid.GridControl()
        Me.GVAcc = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.id_company = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.company = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.address_primary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.is_active = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.is_active_company = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.XTPTreeList = New DevExpress.XtraTab.XtraTabPage()
        Me.TreeList1 = New DevExpress.XtraTreeList.TreeList()
        Me.id_acc = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.id_acc_parent = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.ColAccName = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.ColAccDesc = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.ColDebit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.ColCredit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.ColIdAllChild = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TreeListColumn1 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TreeListColumn2 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TreeListColumn3 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.BalanceMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SMViewTransaction = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.XTCGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCGeneral.SuspendLayout()
        Me.XTPAccount.SuspendLayout()
        CType(Me.GCAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.is_active_company, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPTreeList.SuspendLayout()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BalanceMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCGeneral
        '
        Me.XTCGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCGeneral.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right
        Me.XTCGeneral.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal
        Me.XTCGeneral.Location = New System.Drawing.Point(0, 0)
        Me.XTCGeneral.Name = "XTCGeneral"
        Me.XTCGeneral.SelectedTabPage = Me.XTPAccount
        Me.XTCGeneral.Size = New System.Drawing.Size(812, 366)
        Me.XTCGeneral.TabIndex = 0
        Me.XTCGeneral.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPAccount, Me.XTPTreeList})
        '
        'XTPAccount
        '
        Me.XTPAccount.Controls.Add(Me.GCAcc)
        Me.XTPAccount.Name = "XTPAccount"
        Me.XTPAccount.Size = New System.Drawing.Size(708, 360)
        Me.XTPAccount.Text = "Chart Of Account"
        '
        'GCAcc
        '
        Me.GCAcc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAcc.Location = New System.Drawing.Point(0, 0)
        Me.GCAcc.MainView = Me.GVAcc
        Me.GCAcc.Name = "GCAcc"
        Me.GCAcc.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.is_active_company, Me.RepositoryItemCheckEdit1})
        Me.GCAcc.Size = New System.Drawing.Size(708, 360)
        Me.GCAcc.TabIndex = 4
        Me.GCAcc.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAcc})
        '
        'GVAcc
        '
        Me.GVAcc.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.id_company, Me.company, Me.address_primary, Me.is_active, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GVAcc.GridControl = Me.GCAcc
        Me.GVAcc.Name = "GVAcc"
        Me.GVAcc.OptionsBehavior.Editable = False
        Me.GVAcc.OptionsFind.AlwaysVisible = True
        Me.GVAcc.OptionsView.ShowGroupPanel = False
        Me.GVAcc.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.company, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'id_company
        '
        Me.id_company.Caption = "ID"
        Me.id_company.FieldName = "id_acc"
        Me.id_company.Name = "id_company"
        '
        'company
        '
        Me.company.Caption = "Account"
        Me.company.FieldName = "acc_name"
        Me.company.Name = "company"
        Me.company.Visible = True
        Me.company.VisibleIndex = 0
        Me.company.Width = 237
        '
        'address_primary
        '
        Me.address_primary.Caption = "Description"
        Me.address_primary.FieldName = "acc_description"
        Me.address_primary.Name = "address_primary"
        Me.address_primary.Visible = True
        Me.address_primary.VisibleIndex = 1
        Me.address_primary.Width = 500
        '
        'is_active
        '
        Me.is_active.AppearanceHeader.Options.UseTextOptions = True
        Me.is_active.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.is_active.Caption = "Active"
        Me.is_active.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.is_active.FieldName = "id_status"
        Me.is_active.Name = "is_active"
        Me.is_active.Visible = True
        Me.is_active.VisibleIndex = 3
        Me.is_active.Width = 110
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit1.ValueGrayed = "0"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Cost Center"
        Me.GridColumn1.FieldName = "comp_name"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        Me.GridColumn1.Width = 333
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "CC Number"
        Me.GridColumn2.FieldName = "comp_number"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Id Comp"
        Me.GridColumn3.FieldName = "id_comp"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'is_active_company
        '
        Me.is_active_company.AutoHeight = False
        Me.is_active_company.DisplayValueChecked = "1"
        Me.is_active_company.DisplayValueUnchecked = "0"
        Me.is_active_company.Name = "is_active_company"
        '
        'XTPTreeList
        '
        Me.XTPTreeList.Controls.Add(Me.TreeList1)
        Me.XTPTreeList.Name = "XTPTreeList"
        Me.XTPTreeList.Size = New System.Drawing.Size(708, 360)
        Me.XTPTreeList.Text = "View Ledger"
        '
        'TreeList1
        '
        Me.TreeList1.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.id_acc, Me.id_acc_parent, Me.ColAccName, Me.ColAccDesc, Me.ColDebit, Me.ColCredit, Me.ColIdAllChild, Me.TreeListColumn1, Me.TreeListColumn2, Me.TreeListColumn3})
        Me.TreeList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeList1.KeyFieldName = "id_acc"
        Me.TreeList1.Location = New System.Drawing.Point(0, 0)
        Me.TreeList1.Name = "TreeList1"
        Me.TreeList1.OptionsBehavior.AutoPopulateColumns = False
        Me.TreeList1.OptionsBehavior.Editable = False
        Me.TreeList1.OptionsFind.AllowFindPanel = True
        Me.TreeList1.OptionsFind.AlwaysVisible = True
        Me.TreeList1.OptionsView.EnableAppearanceEvenRow = True
        Me.TreeList1.ParentFieldName = "id_acc_parent"
        Me.TreeList1.RootValue = "0"
        Me.TreeList1.Size = New System.Drawing.Size(708, 360)
        Me.TreeList1.TabIndex = 0
        '
        'id_acc
        '
        Me.id_acc.Caption = "id_acc"
        Me.id_acc.FieldName = "id_acc"
        Me.id_acc.Name = "id_acc"
        Me.id_acc.OptionsColumn.ReadOnly = True
        Me.id_acc.Width = 185
        '
        'id_acc_parent
        '
        Me.id_acc_parent.Caption = "id_acc_parent"
        Me.id_acc_parent.FieldName = "id_acc_parent"
        Me.id_acc_parent.Name = "id_acc_parent"
        Me.id_acc_parent.OptionsColumn.ReadOnly = True
        Me.id_acc_parent.Width = 186
        '
        'ColAccName
        '
        Me.ColAccName.Caption = "Account"
        Me.ColAccName.FieldName = "acc_name"
        Me.ColAccName.Name = "ColAccName"
        Me.ColAccName.OptionsColumn.ReadOnly = True
        Me.ColAccName.Visible = True
        Me.ColAccName.VisibleIndex = 0
        Me.ColAccName.Width = 165
        '
        'ColAccDesc
        '
        Me.ColAccDesc.Caption = "Description"
        Me.ColAccDesc.FieldName = "acc_description"
        Me.ColAccDesc.Name = "ColAccDesc"
        Me.ColAccDesc.OptionsColumn.ReadOnly = True
        Me.ColAccDesc.Visible = True
        Me.ColAccDesc.VisibleIndex = 1
        Me.ColAccDesc.Width = 227
        '
        'ColDebit
        '
        Me.ColDebit.AppearanceCell.Options.UseTextOptions = True
        Me.ColDebit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColDebit.AppearanceHeader.Options.UseTextOptions = True
        Me.ColDebit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColDebit.Caption = "Debit"
        Me.ColDebit.FieldName = "debit"
        Me.ColDebit.Format.FormatString = "N2"
        Me.ColDebit.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColDebit.Name = "ColDebit"
        Me.ColDebit.OptionsColumn.ReadOnly = True
        Me.ColDebit.Visible = True
        Me.ColDebit.VisibleIndex = 3
        Me.ColDebit.Width = 118
        '
        'ColCredit
        '
        Me.ColCredit.AppearanceCell.Options.UseTextOptions = True
        Me.ColCredit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColCredit.AppearanceHeader.Options.UseTextOptions = True
        Me.ColCredit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColCredit.Caption = "Credit"
        Me.ColCredit.FieldName = "credit"
        Me.ColCredit.Format.FormatString = "N2"
        Me.ColCredit.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColCredit.Name = "ColCredit"
        Me.ColCredit.OptionsColumn.ReadOnly = True
        Me.ColCredit.Visible = True
        Me.ColCredit.VisibleIndex = 4
        Me.ColCredit.Width = 116
        '
        'ColIdAllChild
        '
        Me.ColIdAllChild.Caption = "Child"
        Me.ColIdAllChild.FieldName = "id_all_child"
        Me.ColIdAllChild.Name = "ColIdAllChild"
        Me.ColIdAllChild.OptionsColumn.ReadOnly = True
        '
        'TreeListColumn1
        '
        Me.TreeListColumn1.Caption = "Cost Center"
        Me.TreeListColumn1.FieldName = "company_name"
        Me.TreeListColumn1.Name = "TreeListColumn1"
        Me.TreeListColumn1.OptionsColumn.ReadOnly = True
        Me.TreeListColumn1.Visible = True
        Me.TreeListColumn1.VisibleIndex = 2
        Me.TreeListColumn1.Width = 117
        '
        'TreeListColumn2
        '
        Me.TreeListColumn2.Caption = "Cost Center Number"
        Me.TreeListColumn2.FieldName = "company_number"
        Me.TreeListColumn2.Name = "TreeListColumn2"
        Me.TreeListColumn2.OptionsColumn.ReadOnly = True
        '
        'TreeListColumn3
        '
        Me.TreeListColumn3.Caption = "Id Company"
        Me.TreeListColumn3.FieldName = "id_comp"
        Me.TreeListColumn3.Name = "TreeListColumn3"
        Me.TreeListColumn3.OptionsColumn.ReadOnly = True
        '
        'BalanceMenu
        '
        Me.BalanceMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMViewTransaction})
        Me.BalanceMenu.Name = "ContextMenuStripYM"
        Me.BalanceMenu.Size = New System.Drawing.Size(136, 26)
        '
        'SMViewTransaction
        '
        Me.SMViewTransaction.Name = "SMViewTransaction"
        Me.SMViewTransaction.Size = New System.Drawing.Size(135, 22)
        Me.SMViewTransaction.Text = "Transaction"
        '
        'FormAccounting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(812, 366)
        Me.Controls.Add(Me.XTCGeneral)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAccounting"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Manage Account"
        CType(Me.XTCGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCGeneral.ResumeLayout(False)
        Me.XTPAccount.ResumeLayout(False)
        CType(Me.GCAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.is_active_company, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPTreeList.ResumeLayout(False)
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BalanceMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCGeneral As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPAccount As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCAcc As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAcc As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents id_company As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents company As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents address_primary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents is_active As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents is_active_company As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents XTPTreeList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TreeList1 As DevExpress.XtraTreeList.TreeList
    Friend WithEvents ColAccName As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents ColAccDesc As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents id_acc_parent As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents id_acc As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents ColDebit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents ColCredit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents BalanceMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SMViewTransaction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColIdAllChild As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TreeListColumn1 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TreeListColumn2 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TreeListColumn3 As DevExpress.XtraTreeList.Columns.TreeListColumn
End Class
